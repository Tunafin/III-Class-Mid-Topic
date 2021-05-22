using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp期中專題
{
    public partial class Form管理介面 : Form
    {
        int tempbtnon = 0;
        string tempSearch = "";
        public Form管理介面()
        {
            InitializeComponent();
        }

        private void Form管理介面_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridViewX.DataSource = null;

            tempbtnon = 1;
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            string strSQL = @"
                select  訂單ID, 最後修改時間 as 訂單送出時間, 訂購人, 班級名稱, 店家名稱  from [訂單] as ouo
                    inner join [班級] as cl on cl.班級ID = ouo.班級ID
                    inner join [店家] as st on st.店家ID = ouo.店家ID
                    where 最後修改時間 is not null
                    order by 最後修改時間 desc";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@單ID", G全域變數.訂單ID);

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewX.DataSource = dt;


                dataGridViewX.Columns["訂單送出時間"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


                dataGridViewX.ClearSelection();
                
                



                dataGridViewX.Columns["訂單ID"].Visible = false;
                


            }
            else
            {
                dataGridViewX.DataSource = null;
                
            }


            reader.Close();
            con.Close();

            dataGridViewX.ClearSelection();
        }

        void 產生DataGridViewB資料_訂單明細()
        {
            tempSearch = "select * from [#Temp]";
            if (textBox1.Text != "")
            {
                //tempSearch = $" and {comboBox1.Text} like '%{textBox1.Text}%'";
                tempSearch += $" where {comboBox1.Text} like '%{textBox1.Text}%';";
            }
            tempSearch += "DROP TABLE if exists [#Temp];";
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            string strSQL = $@"
                DROP TABLE if exists [#Temp];
                select 訂單明細ID, st.學生ID as '學號', 姓名, 餐點名稱, convert(nvarchar, 單價)+'元' as 單價, 數量, convert(nvarchar, 單價*數量)+'元' as 小計,(單價*數量) as subTotal into [#Temp] from [訂單明細] as od
                    inner join [訂單] as ou on ou.訂單ID = od.訂單ID
                    inner join [學生] as st on st.學生ID = od.學生ID
                    inner join [菜單] as me on me.餐點ID = od.餐點ID
                    where ou.訂單ID = @單ID;
                {tempSearch}";
            Console.WriteLine(strSQL);
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@單ID", dataGridViewX.SelectedRows[0].Cells[0].Value);
//此處有BUG/

/*
    * select 訂單明細ID, st.學生ID, 姓名, 餐點名稱, convert(nvarchar, 單價)+'元' as 單價, 數量, convert(nvarchar, 單價*數量)+'元' as 小計,(單價*數量) as subTotal from [訂單明細] as od
                    inner join [訂單] as ouo on ouo.訂單ID = od.訂單ID
                    inner join [學生] as st on st.學生ID = od.學生ID
                    inner join [菜單] as me on me.餐點ID = od.餐點ID
                    where ouo.訂單ID = 5 and st.學生ID like '%1%'
    * */
            

            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewB.DataSource = dt;
                dataGridViewB.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                /*
                dataGridViewB.Columns[1].Width = 30;
                dataGridViewB.Columns[3].Width = 150;
                dataGridViewB.Columns[4].Width = 50;
                dataGridViewB.Columns[5].Width = 30;
                */
                dataGridViewB.ClearSelection();
                if (textBox1.Text == "")
                {
                    comboBox1.Items.Clear();
                    comboBox1.Items.Add("學號");
                    comboBox1.Items.Add("姓名");
                    comboBox1.Items.Add("餐點名稱");
                    comboBox1.SelectedIndex = 0;
                }



                dataGridViewB.Columns["訂單明細ID"].Visible = false;
                dataGridViewB.Columns["subTotal"].Visible = false;
                G全域變數.totalAll = Int32.Parse(dt.Compute("Sum(subTotal)", null).ToString());


            }
            else
            {
                dataGridViewB.DataSource = null;

            }


            reader.Close();
            con.Close();

            dataGridViewB.ClearSelection();



        }

        void 產生DataGridViewB資料_學生()
        {
            tempSearch = "";
            
            if (textBox1.Text != "")
            {
                tempSearch = $" and {comboBox1.Text} like '%{textBox1.Text}%'";
            }
            

            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            string strSQL = $@"
                select 學生ID,姓名,主修,在學中 from [學生] as st
                    where st.班級ID = @班ID {tempSearch}";
            Console.WriteLine(strSQL);
            SqlCommand cmd = new SqlCommand(strSQL, con);
            cmd.Parameters.AddWithValue("@班ID", dataGridViewX.SelectedRows[0].Cells["班級ID"].Value);



            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewB.DataSource = dt;
                dataGridViewB.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dataGridViewB.ClearSelection();

                if(textBox1.Text == "")
                {
                    comboBox1.Items.Clear();
                    
                    comboBox1.Items.Add("姓名");
                    comboBox1.Items.Add("學生ID");
                    comboBox1.Items.Add("主修");


                    comboBox1.SelectedIndex = 0;
                }
                
            }
            else
            {
                dataGridViewB.DataSource = null;


            }



        }

        private void dataGridViewX_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";

            switch (tempbtnon)
            {
                case 1:
                    if(dataGridViewX.SelectedRows.Count == 1)
                        產生DataGridViewB資料_訂單明細();
                    else
                    {
                        dataGridViewB.DataSource = null;
                        comboBox1.Items.Clear();
                        comboBox1.Text = "";
                    }
                        
                    break;
                case 2:
                    if (dataGridViewX.SelectedRows.Count == 1)
                        產生DataGridViewB資料_學生();
                    else
                    {
                        dataGridViewB.DataSource = null;
                        comboBox1.Items.Clear();
                        comboBox1.Text = "";
                    }
                        
                    break;
                default:
                    break;
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridViewX.DataSource = null;

            tempbtnon = 2;
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            string strSQL = @"
                select  班級ID, 班級名稱 from [班級]
                    order by 班級名稱";
            SqlCommand cmd = new SqlCommand(strSQL, con);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {

                DataTable dt = new DataTable();
                dt.Load(reader);
                dataGridViewX.DataSource = dt;


                dataGridViewX.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dataGridViewX.ClearSelection();




            }
            else
            {
                dataGridViewX.DataSource = null;

            }


            reader.Close();
            con.Close();

            dataGridViewX.ClearSelection();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Items.Count == 0)
            {
                Console.WriteLine("幹");
                return;
            }
            switch (tempbtnon)
            {
                case 1:
                    產生DataGridViewB資料_訂單明細();
                    break;
                case 2:
                    產生DataGridViewB資料_學生();
                    break;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            if (comboBox1.Items.Count == 0)
            {
                Console.WriteLine("幹#");
                return;
            }
            
            switch (tempbtnon)
            {
                case 1:
                    產生DataGridViewB資料_訂單明細();
                    break;
                case 2:
                    產生DataGridViewB資料_學生();
                    break;

            }

        }
    }
}
