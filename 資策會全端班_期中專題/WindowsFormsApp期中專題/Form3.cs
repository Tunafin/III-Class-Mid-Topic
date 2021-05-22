using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient; //ADO.net元件
using System.Windows.Forms;


namespace WindowsFormsApp期中專題
{
    public partial class Form3 : Form
    {
        bool closingMessage = true;
        List<ListBox> list_ListBox集合 = new List<ListBox>();
        List<List<int>> 當前菜單IDs = new List<List<int>>();
        List<int> 當前學生IDs = new List<int>();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            tabControl1.TabPages.Clear();

            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();

            string tempstr = $@"
SELECT  [分類], 
(
    SELECT TOP 1[餐點ID]
    FROM[菜單] AS T2
    WHERE T2.[分類] = T1.[分類]
    GROUP BY[餐點ID]
) AS[餐點ID]
FROM[菜單] AS T1
where[店家ID] = {G全域變數.店家ID}
GROUP BY[分類]
ORDER BY[餐點ID]";
            SqlCommand cmd = new SqlCommand(tempstr, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tabControl1.TabPages.Add($"{reader["分類"]}");
            }
            reader.Close();

            #region 顯示菜單分頁內的listbox
            for (int i = 0; i < tabControl1.TabCount; i++)
            {
                tempstr = $"select * from [菜單] where [店家ID]={G全域變數.店家ID} and [分類]='{tabControl1.TabPages[i].Text}' order by[餐點ID]";
                //Console.WriteLine(tabControl1.TabPages[i].Text);
                cmd = new SqlCommand(tempstr, con);
                reader = cmd.ExecuteReader();


                //listView.FormattingEnabled = true;
                //listView.ItemHeight = 20;
                ListBox listBox = new ListBox();

                listBox.Location = new System.Drawing.Point(6, 6);
                listBox.Name = "XXX";
                listBox.Size = new System.Drawing.Size(tabControl1.Width-20, 300);
                listBox.TabIndex = 0;
                listBox.SelectedIndexChanged += new System.EventHandler(SubPriceGoChanged);

                List<int> templist = new List<int>();
                while (reader.Read())
                {
                    templist.Add((int)reader["餐點ID"]);

                    //Console.WriteLine($"{reader["餐點名稱"]}");
                    listBox.Items.Add($"[ {reader["單價"],3}元 ] {reader["餐點名稱"]}");
                }
                tabControl1.TabPages[i].Controls.Add(listBox);
                list_ListBox集合.Add(listBox);
                當前菜單IDs.Add(templist);

            }
            reader.Close();
            #endregion


            tempstr = $"select * from [學生] where [班級ID]={G全域變數.班級ID} order by[學生ID]";
            cmd = new SqlCommand(tempstr, con);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                comboBoxStName.Items.Add(reader["姓名"]);
                當前學生IDs.Add((int)reader["學生ID"]);
            }
            reader.Close();
            con.Close();

            comboBoxStName.SelectedIndex = 0;
            //Style00.SetStyle(dataGridViewX);
            產生DataGridView資料();
            產生DataGridViewX2資料();
        }

        private void SubPriceGoChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(list_ListBox[tabControl1.SelectedIndex].SelectedItem.ToString());
            if (list_ListBox集合[tabControl1.SelectedIndex].SelectedItems.Count == 1)
            {
                SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
                con.Open();

                SqlCommand cmd = new SqlCommand($"select [單價] from [菜單] where [餐點ID]={當前菜單IDs[tabControl1.SelectedIndex][list_ListBox集合[tabControl1.SelectedIndex].SelectedIndex]}", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    label小計.Text = $"{(int)reader["單價"] * numericUpDown1.Value}元";
                }
                reader.Close();
                con.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (list_ListBox集合[tabControl1.SelectedIndex].SelectedIndex < 0)
            {
                MessageBox.Show("請選擇品項!");
                return;
            }
            if (comboBoxStName.SelectedIndex < 0)
            {
                MessageBox.Show("請選擇姓名!");
                return;
            }

            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();

            //string strSQL = "INSERT [訂單明細] ([訂單ID], [學生ID], [餐點ID], [數量]) VALUES (@單ID, @生ID, @餐ID, @數量);";
            string strSQL = @"
                if exists(select * from[訂單明細] where[訂單ID] = @單ID and[學生ID] = @生ID and[餐點ID] = @餐ID)
                    begin
                        UPDATE[訂單明細] SET[數量] =[數量] + 1 WHERE[訂單ID] = @單ID and[學生ID] = @生ID and[餐點ID] = @餐ID;
                    end
                else
                    begin
                        INSERT[訂單明細] ([訂單ID], [學生ID], [餐點ID], [數量]) VALUES(@單ID, @生ID, @餐ID, @數量);
                    end";
            SqlCommand cmd = new SqlCommand(strSQL, con);

            cmd.Parameters.AddWithValue("@單ID", G全域變數.訂單ID);
            cmd.Parameters.AddWithValue("@生ID", 當前學生IDs[comboBoxStName.SelectedIndex]);
            cmd.Parameters.AddWithValue("@餐ID", 當前菜單IDs[tabControl1.SelectedIndex][list_ListBox集合[tabControl1.SelectedIndex].SelectedIndex]);
            cmd.Parameters.AddWithValue("@數量", numericUpDown1.Value);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("新增完畢");
            產生DataGridView資料();
            產生DataGridViewX2資料();
        }



        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var item in list_ListBox集合)
            {
                item.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }


        void 產生DataGridView資料()
        {
            
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            string strSQL = @"
                select 訂單明細ID, st.學生ID as 學號, 姓名, 餐點名稱, convert(nvarchar, 單價)+'元' as 單價, 數量, convert(nvarchar, 單價*數量)+'元' as 小計,(單價*數量) as subTotal from [訂單明細] as od
                    inner join [訂單] as ouo on ouo.訂單ID = od.訂單ID
                    inner join [學生] as st on st.學生ID = od.學生ID
                    inner join [菜單] as me on me.餐點ID = od.餐點ID
                    where ouo.訂單ID = @單ID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@單ID", G全域變數.訂單ID);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                panel1.Visible = false;
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewX.DataSource = dt;
                
                dataGridViewX.Columns[1].Width = 30;
                dataGridViewX.Columns[3].Width = 150;
                dataGridViewX.Columns[4].Width = 50;
                dataGridViewX.Columns[5].Width = 30;
                dataGridViewX.ClearSelection();


                dataGridViewX.Columns["訂單明細ID"].Visible = false;
                dataGridViewX.Columns["subTotal"].Visible = false;
                G全域變數.totalAll = Int32.Parse(dt.Compute("Sum(subTotal)", null).ToString());
                labelTotalAll.Text = G全域變數.totalAll + "元";


            }
            else
            {
                dataGridViewX.DataSource = null;
                dataGridViewX2.DataSource = null;
                labelTotalAll.Text = $"總價: {0,5}元";

                panel1.Visible = true;
            }


            reader.Close();
            con.Close();

            dataGridViewX.ClearSelection();
            labelPen.Text = $"總筆數: {dataGridViewX.Rows.Count,3}筆";


        }

        private void groupBox2_Leave(object sender, EventArgs e)
        {
            dataGridViewX.ClearSelection();
        }

        private void panel2_Leave(object sender, EventArgs e)
        {
            list_ListBox集合[tabControl1.SelectedIndex].ClearSelected();
        }

        void 產生DataGridViewX2資料()
        {
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            string strSQL = @"
                select 餐點名稱, convert(nvarchar, 單價)+'元' as 單價, sum([數量]) as [數量], convert(nvarchar, sum([單價]*[數量]))+'元' as 小計 from [訂單明細] as od
                    inner join [訂單] as ouo on ouo.訂單ID = od.訂單ID
                    inner join [菜單] as me on me.餐點ID = od.餐點ID
                    where ouo.訂單ID = @單ID
                    group by [餐點名稱],[單價];";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@單ID", G全域變數.訂單ID);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewX2.DataSource = dt;
                dataGridViewX2.Columns[0].Width = 120;
            }

            reader.Close();
            con.Close();

            dataGridViewX2.ClearSelection();



        }

        

        private void dataGridViewX2_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewX2.ClearSelection();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewX.SelectedRows.Count == 0)
            {
                MessageBox.Show("無選擇項目!");
                return;
            }
            
            G全域變數.明細SelID = (int)dataGridViewX.SelectedRows[0].Cells[0].Value;
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();

            string strSQL = @"DELETE FROM 訂單明細 WHERE 訂單明細ID=@細ID;";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@細ID", G全域變數.明細SelID);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("刪除完畢");
            產生DataGridView資料();
            產生DataGridViewX2資料();
        }

        private void buttonChange_Click(object sender, EventArgs e)
        {
            if (dataGridViewX.SelectedRows.Count == 0)
            {
                MessageBox.Show("無選擇項目!");
                return;
            }
            G全域變數.明細SelID = (int)dataGridViewX.SelectedRows[0].Cells[0].Value;
            Form簡易修改介面 formY = new Form簡易修改介面();
            formY.ShowDialog(this);
            產生DataGridView資料();
            產生DataGridViewX2資料();

        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closingMessage)
            {
                if (DialogResult.Yes == MessageBox.Show("確定要關閉嗎", "訊息", MessageBoxButtons.YesNo))
                    e.Cancel = false;
                else
                    e.Cancel = true;
            }
            
        }
        

        private void button4_Click(object sender, EventArgs e)
        {
            if (G全域變數.totalAll < 200)
            {
                MessageBox.Show("總金額必須滿200元才可成立訂單!");
                return;
            }
            
            string strSQL = @"UPDATE 訂單 SET 最後修改時間=@時,已鎖定=1 WHERE 訂單ID=@訂ID;";
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@時", DateTime.Now);
            cmd.Parameters.AddWithValue("@訂ID", G全域變數.訂單ID);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("訂單送出完成!");
            closingMessage = false;
            this.Close();
            

            

        }
    }


    
}
