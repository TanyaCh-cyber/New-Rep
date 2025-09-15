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
    public partial class Form3 : Form
    {
        public string prize_name;
        public Form3(string prr)
        {
            prize_name = prr;
            InitializeComponent();
            fill_prize();
        }

        private void fill_prize()
        {
            char chh = '@';
            label2.Text = prize_name.Split(chh)[1];
            label3.Text = prize_name.Split(chh)[2];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
