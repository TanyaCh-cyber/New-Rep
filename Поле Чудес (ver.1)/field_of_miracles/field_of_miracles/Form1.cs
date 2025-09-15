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

namespace field_of_miracles
{
    public partial class Form1 : Form
    {
        public string word = "";
        public string question = "";
        private Random rnd = new Random();
        private Random rnd_for_letter = new Random();
        private Random rnd_for_prise = new Random();
        private Random rnd_for_crct= new Random();
        private Random rnd_for_ques = new Random();
        private string num_of_str = "";
        private string was_in_ans = "";
        private string right_lett = "";
        private int balance_pers = 0;
        private int balance_ai = 0;
        private int balance_duck = 0;
        private int balance_Visel = 0;
        private int balance_cesar = 0;
        private int balance_refreg = 0;
        private int who_move = 1;
        private int[] round_1_chr = new int[3];
        private int[] round_1_sum = new int[3];
        bool is_start_of_round_2 = false;
        private int vib;
        private char[] letters = Enumerable.Range('а', 32).Select(c => (char)c).ToArray();

        public Form1()
        {

            InitializeComponent();
            Fill_the_questions();
            open_window_of_leading();
            Start_the_game();
            Fill_the_table();
        }

        private void Fill_the_questions()
        {
            int strrrrrr = rnd_for_ques.Next(12);
            while (num_of_str.Contains(strrrrrr.ToString()))
            {
                strrrrrr = rnd_for_ques.Next(12);
            }
            num_of_str += strrrrrr.ToString();
            string[] lines = File.ReadAllLines("question.txt");
            int num = 0;
            foreach (string line in lines)
            {
                if (num == strrrrrr)
                {
                    question = line.Split('@')[0];
                    word = line.Split('@')[1];
                }
                num += 1;
            }
            //label4.Text = question;
            //Form3 prizze = new Form3(ch);
            //prizze.Show();
            //End_the_game();


        }

        private void open_window_of_leading()
        {
            Form5 letts = new Form5(question);
            letts.ShowDialog();
        }

        private void Start_the_game()
        {

            for (int i = 0; i < 3; i++)
            {
                int chrrrt = rnd_for_crct.Next(2, 7);
                while (round_1_chr.Contains(chrrrt))
                {
                    chrrrt = rnd_for_crct.Next(2, 7);
                }
                round_1_chr[i] = chrrrt;
            }
            Fill_the_image(round_1_chr[0]);


        }


        private void Fill_the_image(int charact)
        {
            switch (charact)
            {
                case 2:
                    pictureBox1.Image = Image.FromFile("aiexe.png");
                    label2.Text = "Баланс Ai.exe: " + balance_ai.ToString();
                    break;
                case 3:
                    pictureBox1.Image = Image.FromFile("bread_duck.png");
                    label2.Text = "Баланс Хлебной Уточки: " + balance_duck.ToString();
                    break;
                case 4:
                    pictureBox1.Image = Image.FromFile("Visel.png");
                    label2.Text = "Баланс Висельчака: " + balance_Visel.ToString();
                    break;
                case 5:
                    pictureBox1.Image = Image.FromFile("Cesar.png");
                    label2.Text = "Баланс Цезаря: " + balance_cesar.ToString();
                    break;
                case 6:
                    pictureBox1.Image = Image.FromFile("Frige.png");
                    label2.Text = "Баланс Холодильника: " + balance_refreg.ToString();
                    break;
            }
        }
        

        private void End_the_game(int kode)
        {
            switch (kode)
            {
                case 1:
                    this.Close();
                    break;
                case 2:
                    int max_sum = round_1_sum.Max();
                    if ( balance_pers > max_sum)
                    {
                        MessageBox.Show("Все буквы угаданы! Вы Выигрываете с наибольшим количеством баллов!", "игра завершена", MessageBoxButtons.OK);
                        this.Close();
                    }
                    else
                    {
                        string vibb = "";
                        vib = round_1_chr[Array.IndexOf(round_1_sum, max_sum)];
                        switch (vib)
                        {
                            case 2:
                                vibb = "Ai.exe";
                                break;
                            case 3:
                                vibb = "Хлебная уточка";
                                break;
                            case 4:
                                vibb = "Висельчак";
                                break;
                            case 5:
                                vibb = "Цезарь";
                                break;
                            case 6:
                                vibb = "Холодильник";
                                break;
                        }
                        MessageBox.Show("Все буквы угаданы! " + vibb + " выигрывает с наибольшим количеством баллов!", "игра завершена", MessageBoxButtons.OK);
                        this.Close();
                        // MessageBox.Show("Все буквы угаданы!", "игра завершена", MessageBoxButtons.OK);
                    }
                    break;
            }
        }

        public void Fill_the_table()
        {
            label5.Text = "Ваш ход!";
            // Очищаем столбцы
            dataGridView1.Columns.Clear();

            for (int i = 0; i < word.Length; i++)
            {
                var column1 = new DataGridViewColumn
                {
                    // Width = 150,
                    // Height = 150,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
                    ReadOnly = true,
                    CellTemplate = new DataGridViewTextBoxCell()
                };
                //dataGridView1.Columns.Add(column1);
                dataGridView1.Columns.Add(column1);
            }
            dataGridView1.RowTemplate.Height = 150; 
            
            DataGridViewRow roww = new DataGridViewRow();
            roww.CreateCells(dataGridView1);

            for (int i = 0; i < word.Length; i++)
            {
                roww.Cells[i].Value = "*";
                roww.Height = 110;
                roww.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                roww.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 22);
                //roww.Cells[i].
            }
            dataGridView1.Rows.Add(roww);
        }

        private void spin_the_drum(int charact)
        {


            int ch = rnd.Next(1, 11);
            switch (ch)
            {
                case 1:
                    textBox1.Text = "На барабане сектор 'Буква'!";
                    sect_letter(charact);
                    break;
                case 2:
                    goto case 1;
                case 3:
                    goto case 1;
                case 4:
                    goto case 1;
                case 5:
                    textBox1.Text = "На барабане сектор 'Плюс'!";
                    sect_plus(charact);
                    break;
                case 6:
                    goto case 5;
                case 7:
                    textBox1.Text = "На барабане сектор 'Обнуление'!";
                    sect_obnul(charact);
                    break;
                case 8:
                    textBox1.Text = "На барабане сектор 'Фига'!";
                    sect_figa(charact);
                    break;
                case 9:
                    textBox1.Text = "На барабане сектор 'Приз'!";
                    sect_prize(charact);
                    break;
                case 10:
                    goto case 8;
            }
            if (is_start_of_round_2)
            {
                End_the_game(2);
            }
            else
            {
                if (who_move == 1)
                {
                    who_move = round_1_chr[0];
                    who_is_moving_in_text();
                    spin_the_drum(who_move);
                }
                else
                {
                    next_step();
                }
            }

        }

        private void who_is_moving_in_text()
        {
            switch (who_move)
            {
                case 1:
                    label5.Text = "Сейчас Ваш ход!";
                    break;
                case 2:
                    label5.Text = "Сейчас ход Ai.ex!";
                    break;
                case 3:
                    label5.Text = "Сейчас ход Хлебной Уточки!";
                    break;
                case 4:
                    label5.Text = "Сейчас ход Висельчака!";
                    break;
                case 5:
                    label5.Text = "Сейчас ход Цезаря!";
                    break;
                case 6:
                    label5.Text = "Сейчас ход Холодильника!";
                    break;
            }
        }

        private void next_step()
        {
            int indd = Array.IndexOf(round_1_chr, who_move);
            if (indd == 2)
            {
                who_move = 1;
                who_is_moving_in_text();
                Fill_the_image(round_1_chr[0]);

            }
            else
            {
                who_move = round_1_chr[indd + 1];
                who_is_moving_in_text();
                Fill_the_image(who_move);
                spin_the_drum(who_move);
                // Fill_the_image(who_move);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            spin_the_drum(who_move);
            // label4.Text = ch.ToString();
        }

        private void sect_prize(int charact)
        {
            switch (charact)
            {

                case 1:
                    DialogResult res = MessageBox.Show("Хотите забрать приз?", "Сектор приз", MessageBoxButtons.YesNo);
                    if (res == DialogResult.Yes)
                    {
                        int prs = rnd_for_prise.Next(31);
                        int num = 0;
                        string ch = "";
                        string[] lines = File.ReadAllLines("prise.txt");
                        foreach (string line in lines)
                        {
                            if (num == prs)
                            {
                                ch = line;
                            }
                            num += 1;
                        }
                        Form3 prizze = new Form3(ch);
                        prizze.ShowDialog();
                        End_the_game(1);
                    }
                    else
                    {
                        MessageBox.Show("Вы отказались от приза, но полуяаете 5 баллов", "Отказ от приза", MessageBoxButtons.OK);
                        balance_pers += 5;
                        label3.Text = "Ваш баланс: " + balance_pers.ToString();
                    }
                    break;
                case 2:
                    balance_ai += 5;
                    label2.Text = "Баланс Ai.exe: " + balance_ai.ToString();
                    MessageBox.Show("Ai.exe отказывается от приза и получает 5 баллов", "Сектор приз", MessageBoxButtons.OK);
                    break;
                case 3:
                    balance_duck += 5;
                    label2.Text = "Баланс Хлебной уточки: " + balance_duck.ToString();
                    MessageBox.Show("Хлебная уточка отказывается от приза и получает 5 баллов", "Сектор приз", MessageBoxButtons.OK);
                    break;
                case 4:
                    balance_Visel += 5;
                    label2.Text = "Баланс Висельчака: " + balance_Visel.ToString();
                    MessageBox.Show("Висельчак отказывается от приза и получает 5 баллов", "Сектор приз", MessageBoxButtons.OK);
                    break;
                case 5:
                    balance_cesar += 5;
                    label2.Text = "Баланс Цезаря: " + balance_cesar.ToString();
                    MessageBox.Show("Цезарь отказывается от приза и получает 5 баллов", "Сектор приз", MessageBoxButtons.OK);
                    break;
                case 6:
                    balance_refreg += 5;
                    label2.Text = "Баланс Холодильника: " + balance_refreg.ToString();
                    MessageBox.Show("Холодильник отказывается от приза и получает 5 баллов", "Сектор приз", MessageBoxButtons.OK);
                    break;
            }
            if (who_move != 1)
            {

                round_1_sum[Array.IndexOf(round_1_chr, who_move)] += 5;

            }
        }

        private void sect_letter(int charact)
        {
            switch (charact)
            {
                case 1:
                    Form2 lett = new Form2(was_in_ans);
                    lett.Enter_letter += Entered_letter;
                    lett.ShowDialog();
                    
                    break;
                default:
                    string chh;
                    int ch_lt = rnd_for_letter.Next(32);
                    chh = letters[ch_lt].ToString();
                    while (was_in_ans.Contains(chh))
                    {
                        ch_lt = rnd_for_letter.Next(32);
                        chh = letters[ch_lt].ToString();
                    }
                    using (StreamWriter writer = new StreamWriter("letter.txt", false))
                    {
                        writer.WriteLineAsync(chh);
                    }
                    is_letter_in_word(who_move);
                    // label4.Text = "из цикла вышли успешно!";
                break;

            }
            
        }

        private void is_letter_in_word(int charact)
        {
            string lt;
            using (StreamReader reader = new StreamReader("letter.txt"))
            {
                lt = reader.ReadLine().ToLower();
            }
            was_in_ans += lt.ToLower();
            // label4.Text = was_in_ans;
            if (word.Contains(lt))
            {
                int vh = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].ToString() == lt)
                    {
                        vh += 1;
                    }
                }
                switch (charact)
                {
                    case 1:
                        MessageBox.Show("Вы правильно отгадали букву и получаете " + (30 * vh).ToString() + " очков!", "Буква отгадана!", MessageBoxButtons.OK);
                        balance_pers += 30 * vh;
                        label3.Text = "Ваш баланс: " + balance_pers.ToString();
                        break;
                    case 2:
                        balance_ai += 30 * vh;
                        label2.Text = "Баланс Ai.exe: " + balance_ai.ToString();
                        MessageBox.Show("Ai.exe правильно отгадал букву '" + lt + "' и получает " + (30 * vh).ToString() + " очков!", "Буква отгадана!", MessageBoxButtons.OK);
                        break;
                    case 3:
                        balance_duck += 30 * vh;
                        label2.Text = "Баланс Хлебной Уточки: " + balance_duck.ToString();
                        MessageBox.Show("Хлебная уточка правильно отгадала букву '" + lt + "' и получает " + (30 * vh).ToString() + " очков!", "Буква отгадана!", MessageBoxButtons.OK);
                        break;
                    case 4:
                        balance_Visel += 30 * vh;
                        label2.Text = "Баланс Висельчака: " + balance_Visel.ToString();
                        MessageBox.Show("Висельчак правильно отгадал букву '" + lt + "' и получает " + (30 * vh).ToString() + " очков!", "Буква отгадана!", MessageBoxButtons.OK);
                        break;
                    case 5:
                        balance_cesar += 30 * vh;
                        label2.Text = "Баланс Цезаря: " + balance_cesar.ToString();
                        MessageBox.Show("Цезарь правильно отгадал букву '" + lt + "' и получает " + (30 * vh).ToString() + " очков!", "Буква отгадана!", MessageBoxButtons.OK);
                        break;
                    case 6:
                        balance_refreg += 30 * vh;
                        label2.Text = "Баланс Холодильника: " + balance_refreg.ToString();
                        MessageBox.Show("Холодильник правильно отгадал букву '" + lt + "' и получает " + (30 * vh).ToString() + " очков!", "Буква отгадана!", MessageBoxButtons.OK);
                        break;
                }

                for (int i = 0; i < vh; i++)
                {
                    right_lett += lt;
                }

                if (right_lett.Length == word.Length)
                {
                    is_start_of_round_2 = true;
                }
                if (who_move != 1)
                {

                    round_1_sum[Array.IndexOf(round_1_chr, who_move)] += 30 * vh;

                }

                for (int i = 0; i < word.Length; i++)
                {
                    if (word[i].ToString() == lt)
                    {
                        dataGridView1.Rows[0].Cells[i].Value = lt;
                    }
                }
                //break;
            }

            else
            {
                switch (charact)
                {
                    case 1:
                        MessageBox.Show("Такой буквы нет!", "Буква не отгадана!", MessageBoxButtons.OK);
                        break;
                    case 2:
                        MessageBox.Show("Ai.exe не угадал букву '" + lt + "' !", "Буква не отгадана!", MessageBoxButtons.OK);
                        break;
                    case 3:
                        MessageBox.Show("Хлебная Уточка не угадал букву '" + lt + "' !", "Буква не отгадана!", MessageBoxButtons.OK);
                        break;
                    case 4:
                        MessageBox.Show("Висельчак не угадал букву '" + lt + "' !", "Буква не отгадана!", MessageBoxButtons.OK);
                        break;
                    case 5:
                        MessageBox.Show("Цезарь не угадал букву '" + lt + "' !", "Буква не отгадана!", MessageBoxButtons.OK);
                        break;
                    case 6:
                        MessageBox.Show("Холодильник не угадал букву '" + lt + "' !", "Буква не отгадана!", MessageBoxButtons.OK);
                        break;
                }

            }
        }

        private void Entered_letter()
        {
            is_letter_in_word(who_move);
        }

        private void sect_figa(int charact)
        {
            switch (charact)
            {
                case 1:
                    MessageBox.Show("Вы не получили очки!", "Фига", MessageBoxButtons.OK);
                    break;
                case 2:
                    MessageBox.Show("Ai.exe не получил очки!", "Фига", MessageBoxButtons.OK);
                    break;
                case 3:
                    MessageBox.Show("Хлебная уточка не получила очки!", "Фига", MessageBoxButtons.OK);
                    break;
                case 4:
                    MessageBox.Show("Висельчак не получил очки!", "Фига", MessageBoxButtons.OK);
                    break;
                case 5:
                    MessageBox.Show("Цезарь не получил очки!", "Фига", MessageBoxButtons.OK);
                    break;
                case 6:
                    MessageBox.Show("Холодильник не получила очки!", "Фига", MessageBoxButtons.OK);
                    break;
            }
        }

        private void sect_obnul(int charact)
        {
            switch (charact)
            {
                case 1:
                    MessageBox.Show("Вы потеряли все очки!", "Обнуление", MessageBoxButtons.OK);
                    balance_pers = 0;
                    label3.Text = "Ваш баланс: " + balance_pers.ToString();
                    break;
                case 2:
                    balance_ai = 0;
                    label2.Text = "Баланс Ai.exe: " + balance_ai.ToString();
                    MessageBox.Show("Ai.exe потерял все очки!", "Обнуление", MessageBoxButtons.OK);
                    break;
                case 3:
                    balance_duck = 0;
                    label2.Text = "Баланс Хлебной Уточки: " + balance_duck.ToString();
                    MessageBox.Show("Хлебная уточка потеряла все очки!", "Обнуление", MessageBoxButtons.OK);
                    break;
                case 4:
                    balance_Visel = 0;
                    label2.Text = "Баланс Висельчака: " + balance_Visel.ToString();
                    MessageBox.Show("Висельчак потерял все очки!", "Обнуление", MessageBoxButtons.OK);
                    break;
                case 5:
                    balance_cesar = 0;
                    label2.Text = "Баланс Цезаря: " + balance_cesar.ToString();
                    MessageBox.Show("Цезарь потерял все очки!", "Обнуление", MessageBoxButtons.OK);
                    break;
                case 6:
                    balance_refreg = 0;
                    label2.Text = "Баланс Холодильника: " + balance_refreg.ToString();
                    MessageBox.Show("Холодильник потерял все очки!", "Обнуление", MessageBoxButtons.OK);
                    break;
            }
            if (who_move != 1)
            {

                round_1_sum[Array.IndexOf(round_1_chr, who_move)] = 0;

            }
        }

        private void sect_plus(int charact)
        {
            switch (charact)
            {
                case 1:
                    balance_pers += 10;
                    label3.Text = "Ваш баланс: " + balance_pers.ToString();
                    MessageBox.Show("Вы получили 10 очков!", "Получение очков", MessageBoxButtons.OK);
                    break;
                case 2:
                    balance_ai += 10;
                    label2.Text = "Баланс Ai.exe: " + balance_ai.ToString();
                    MessageBox.Show("Ai.exe получил 10 очков!", "Получение очков", MessageBoxButtons.OK);
                    break;
                case 3:
                    balance_duck += 10;
                    label2.Text = "Баланс Хлебной Уточки: " + balance_duck.ToString();
                    MessageBox.Show("Хлебная уточка получила 10 очков!", "Получение очков", MessageBoxButtons.OK);
                    break;
                case 4:
                    balance_Visel += 10;
                    label2.Text = "Баланс Висельчака: " + balance_Visel.ToString();
                    MessageBox.Show("Висельчак получил 10 очков!", "Получение очков", MessageBoxButtons.OK);
                    break;
                case 5:
                    balance_cesar += 10;
                    label2.Text = "Баланс Цезаря: " + balance_cesar.ToString();
                    MessageBox.Show("Цезарь получил 10 очков!", "Получение очков", MessageBoxButtons.OK);
                    break;
                case 6:
                    balance_refreg += 10;
                    label2.Text = "Баланс Холодильника: " + balance_refreg.ToString();
                    MessageBox.Show("Холодильник получил 10 очков!", "Получение очков", MessageBoxButtons.OK);
                    break;
            }
            if (who_move != 1)
            {

                round_1_sum[Array.IndexOf(round_1_chr, who_move)] += 10;


            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form4 letts = new Form4(was_in_ans);
            letts.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            open_window_of_leading();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы точно хотите выйти?", "Выход", MessageBoxButtons.YesNo);
            if (res == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
