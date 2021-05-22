using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp期中專題
{
    class Style00
    {
        public static void SetStyle(System.Windows.Forms.DataGridView QQ)
        {



            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleA = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyleA.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyleA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyleA.Font = new System.Drawing.Font("微軟正黑體", 9.267326F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyleA.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyleA.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            dataGridViewCellStyleA.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyleA.WrapMode = System.Windows.Forms.DataGridViewTriState.False;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleB = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyleB.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyleB.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyleB.Font = new System.Drawing.Font("微軟正黑體", 9.267326F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyleB.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyleB.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyleB.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyleB.WrapMode = System.Windows.Forms.DataGridViewTriState.True;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyleC = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyleC.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyleC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(253)))), ((int)(((byte)(117)))));
            dataGridViewCellStyleC.Font = new System.Drawing.Font("微軟正黑體", 9.267326F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyleC.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyleC.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyleC.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyleC.WrapMode = System.Windows.Forms.DataGridViewTriState.False;




            QQ.AlternatingRowsDefaultCellStyle = dataGridViewCellStyleA;
            QQ.ColumnHeadersDefaultCellStyle = dataGridViewCellStyleB;
            QQ.DefaultCellStyle = dataGridViewCellStyleC;

            QQ.Cursor = default;

        }
    }
}
