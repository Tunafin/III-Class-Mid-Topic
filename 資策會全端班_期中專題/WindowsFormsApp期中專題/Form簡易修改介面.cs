using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; //ADO.net元件


namespace WindowsFormsApp期中專題
{
    public partial class Form簡易修改介面 : Form
    {
        List<ListBox> list_ListBox集合 = new List<ListBox>();
        List<List<int>> 當前菜單IDs = new List<List<int>>();

        public Form簡易修改介面()
        {
            InitializeComponent();
        }

        

        private void Form簡易修改介面_Load(object sender, EventArgs e)
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
                listBox.Size = new System.Drawing.Size(tabControl1.Width - 20, 300);
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
            

            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();

            string strSQL = @"UPDATE[訂單明細] SET [餐點ID]=@餐ID, [數量]=@數量 WHERE[訂單明細ID]=@細ID";
            SqlCommand cmd = new SqlCommand(strSQL, con);
 
            cmd.Parameters.AddWithValue("@餐ID", 當前菜單IDs[tabControl1.SelectedIndex][list_ListBox集合[tabControl1.SelectedIndex].SelectedIndex]);
            cmd.Parameters.AddWithValue("@數量", numericUpDown1.Value);
            cmd.Parameters.AddWithValue("@細ID", G全域變數.明細SelID);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("修改成功!");
            this.Close();

        }
    }
}
