using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace field_of_miracles
{
    public partial class Form4 : Form
    {
        private string was_in = "";
        public Form4(string was_in_ans)
        {
            was_in = was_in_ans;
            InitializeComponent();
            Fill_the_textbox();
        }

        public void Fill_the_textbox()
        {
            textBox1.Text = " ";
            if (was_in.Length != 0)
            {
                string chh = "";
                for (int i = 0; i < was_in.Length; i++)
                {
                    chh += was_in[i] + ",";
                }
                textBox1.Text = chh.Substring(0, chh.Length - 1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
