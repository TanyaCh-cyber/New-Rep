using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace field_of_miracles
{
    public partial class Form2 : Form
    {
        public event Action Enter_letter;
        private string Was_a = "";
        public Form2(string was_in_ans)
        {
            Was_a = was_in_ans;
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.ToString().Length == 0)
            {
                MessageBox.Show("Поле нельзя оставлять пустым!", "Введите что-нибудь!", MessageBoxButtons.OK);
            }
            else if (Was_a.Contains(maskedTextBox1.Text.ToString().ToLower()))
            {
                MessageBox.Show("Эта буква уже была!!", "Повтор буквы!", MessageBoxButtons.OK);
            }
            else
            {
                using (StreamWriter writer = new StreamWriter("letter.txt", false))
                {
                    writer.WriteLineAsync(maskedTextBox1.Text.ToString());
                }
                this.Close();
                Enter_letter?.Invoke();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
