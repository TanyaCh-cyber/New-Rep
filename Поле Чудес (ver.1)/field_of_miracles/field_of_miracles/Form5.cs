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
    public partial class Form5 : Form
    {
        private string ques = "";
        public Form5(string quest)
        {
            ques = quest;
            InitializeComponent();
            fill_the_quests();

        }

        private void fill_the_quests()
        {
            if (ques.Contains("~"))
            {
                label1.Text = ques.Split('~')[0];
                label2.Text = ques.Split('~')[1];
            }
            else
            {
                label1.Text = ques;
                label1.Location = new Point(300, 109);
                label2.Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
