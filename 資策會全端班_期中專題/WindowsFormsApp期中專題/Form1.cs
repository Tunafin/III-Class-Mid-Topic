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
    public partial class Form1 : Form
    {
        SqlConnectionStringBuilder scsb;
        string myDBConnectionString = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            scsb = new SqlConnectionStringBuilder(); ;
            scsb.DataSource = @".";//機器名稱
            scsb.InitialCatalog = $"{G全域變數.myDBname}";//資料庫名稱
            scsb.IntegratedSecurity = true;
            myDBConnectionString = scsb.ToString();

            //產生DataGridView資料();
        }

//***參考用********************************************************
        //void 產生DataGridView資料()
        //{
        //    SqlConnection con = new SqlConnection(myDBConnectionString);
        //    con.Open();
        //    string strSQL = "select * from 學生 where 班級ID = 101";
        //    SqlCommand cmd = new SqlCommand(strSQL, con);
        //    SqlDataReader reader = cmd.ExecuteReader();

        //    if (reader.HasRows)
        //    {
        //        DataTable dt = new DataTable();
        //        dt.Load(reader);

                
        //    }

        //    reader.Close();
        //    con.Close();
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBoxAccount.Text == "") MessageBox.Show("請輸入帳號!", "訊息");
            else if(textBoxPassword.Text == "") MessageBox.Show("請輸入密碼!", "訊息");
            else
            {
                int tempAcc;
                if(Int32.TryParse(textBoxAccount.Text, out tempAcc))
                {
                    SqlConnection con = new SqlConnection(myDBConnectionString);
                    con.Open();
                    string strSQL = $"select * from 學生 where 學生ID = {tempAcc}";
                    SqlCommand cmd = new SqlCommand(strSQL, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        if((string)reader["密碼"] == textBoxPassword.Text)
                        {
                            G全域變數.班級ID = (int)reader["班級ID"];
                            G全域變數.主訂購人姓名 = (string)reader["姓名"];
                            reader.Close();
                            con.Close();
                            MessageBox.Show($"登入成功!", "訊息");
                            this.Visible = false;

                            Form2 form2 = new Form2();//產生Form的物件，才可以使用它所提供的Method
                            form2.ShowDialog(this);     //新表單進入點

                            textBoxPassword.Clear();
                            this.Visible = true;

                        }
                        else MessageBox.Show($"密碼錯誤!", "訊息");
                    }
                    else MessageBox.Show($"查無此帳號!!", "訊息");
                    reader.Close();
                    con.Close();
                }
                else
                {
                    MessageBox.Show("查無此帳號!", "訊息");
                }

                

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            /*
            if (textBoxAccount.Text!="doge"||textBoxPassword.Text!="cat")
            {
                MessageBox.Show("帳號或密碼錯誤!","訊息");
                return;
            }*/
            this.Visible = false;
            Form管理介面 formAD = new Form管理介面();//產生Form的物件，才可以使用它所提供的Method
            formAD.ShowDialog(this);     //新表單進入點
            textBoxPassword.Clear();
            this.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {

            
        }
    }
}
