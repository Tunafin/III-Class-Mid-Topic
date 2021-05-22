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
    public partial class Form2 : Form
    {
        List<int> 店家IDs = new List<int>(); //儲存店家序號, 本 list index 與 listbox index連結


        public Form2()
        {
            InitializeComponent();
        }

        private void Form選擇店家_Load(object sender, EventArgs e)
        {
            textBoxMyClass.Text = G全域變數.班級ID.ToString();
            textBoxOrderer.Text = G全域變數.主訂購人姓名;
            
            
            SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select [店家ID], [店家名稱] from 店家", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                店家IDs.Add((int)reader["店家ID"]);
                listBox1.Items.Add(reader["店家名稱"]);
            }
            reader.Close();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count == 0) MessageBox.Show("請選擇店家!");
            else
            {
                G全域變數.店家ID = 店家IDs[listBox1.SelectedIndex];

                SqlConnection con = new SqlConnection(G全域變數.myDBConnectionString);
                con.Open();
                string strSQL = "INSERT [訂單] ([班級ID], [店家ID], [訂購人], [日期]) VALUES (@班ID, @店ID, @訂人名, @今天日期);";
                SqlCommand cmd = new SqlCommand(strSQL, con);
                cmd.Parameters.AddWithValue("@班ID", G全域變數.班級ID);
                cmd.Parameters.AddWithValue("@店ID", G全域變數.店家ID);
                cmd.Parameters.AddWithValue("@訂人名", textBoxOrderer.Text);
                cmd.Parameters.AddWithValue("@今天日期", DateTime.Today);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("新增完畢");

                con.Open();
                cmd = new SqlCommand("SELECT MAX(訂單ID) as 喵 FROM [訂單];", con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                G全域變數.訂單ID = (int)reader["喵"];
                reader.Close();

                con.Close();

                
                
                this.Visible = false;
                Form3 form3 = new Form3();//產生Form的物件
                form3.ShowDialog(this);     //新表單進入點
                this.Visible = true;
                
            }
        }
    }
}
