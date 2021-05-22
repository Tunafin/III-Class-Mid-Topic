using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp期中專題
{
    class G全域變數
    {
        public static string myDBname = "mySharkDB";
        public static string myDBConnectionString = $"Data Source=.;Initial Catalog={myDBname};Integrated Security=True;MultipleActiveResultSets=True";

        public static int 班級ID = -1;
        public static string 主訂購人姓名 = "";
        public static int 店家ID = -1;
        public static int 訂單ID = -1;
        public static int 明細SelID = -1;
        public static int totalAll = 0;






    }


    /*
     Form3 form3 = new Form3();
                form3.FormBorderStyle = FormBorderStyle.None;
                form3.TopLevel = false;
                form3.Visible = true;

                panel1.Controls.Add(form3);
    */
}