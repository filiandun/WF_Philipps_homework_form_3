using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Form3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.buttonClearAllTexBox.Enabled = false;
            this.buttonNewNum.Enabled = false;
            this.buttonNextTextBox.Enabled = false;

            this.groupBoxFIO.Controls.SetChildIndex(this.buttonLanguage, 0); // ВЕСЬ МОЗГ МНЕ ВЫНЕС GROUPBOX, ТАК КАК ВООБЩЕ НЕПОНЯТНО, 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonSpace, 1); // ПО КАКОЙ ЛОГИКЕ ОН ВНУТРИ СЕБЯ НУМИРУЕТ ЭЛЕМЕНТЫ,
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonDelete, 2); // ПОЭТОМУ ПРИШЛОСЬ ЕМУ ПРИНУДИТЕЛЬНО СКАЗАТЬ, КАК МНЕ НАДО. 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonCaps, 3); // P.S. уже на заключательном этапе, я начинаю догадываться, что это происходит по TabIndex.

            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 100;
        }


        private void updateProgressBar(object sender, EventArgs e)
        {
            byte filledFields = 0;

            // SENDER НУЖНО УБРАТЬ, С НИМ РАБОТАЕТ НЕКОРРЕКТНО
            // нужно, чтобы подряд проверялось ВСЁ

            if (sender == this.textBoxFIO) // проверка ФИО
            {
                Regex regex = new Regex(@"^\D+\s\D+\s\D+$");
                if (!string.IsNullOrEmpty(this.textBoxFIO.Text)) 
                {
                    if (regex.IsMatch(this.textBoxFIO.Text))
                    {
                        filledFields++;
                        this.toolStripStatusLabel1.Text = "Было введено ФИО";

                        MessageBox.Show("1");
                    }
                }
            }

            if (sender == this.numericUpDownBirthMonth || sender == this.numericUpDownBirthYear) // проверка даты рождения
            {
                if (this.numericUpDownBirthYear.Value != 1) 
                {
                    filledFields++;
                    this.toolStripStatusLabel1.Text = "Была введена дата рождения";

                    MessageBox.Show("2");
                }
            }

            if (sender == this.textBox1 || sender == this.textBox2 || sender == this.textBox3 || sender == this.textBox4 || sender == this.textBox5 || sender == this.textBox6 || sender == this.textBox7 || sender == this.textBox8 || sender == this.textBox9 || sender == this.textBox10)
            {
                byte filledFieldsTelephone = 0;

                filledFieldsTelephone = (byte) this.groupBoxTelephone.Controls.OfType<TextBox>().Where(n => !String.IsNullOrEmpty(n.Text)).Count(); // список TextBox, строка которых не будет пуста
                this.toolStripStatusLabel1.Text = filledFieldsTelephone != 10 ? $"Осталось цифр номера: {10 - filledFieldsTelephone} из {10}" : "Был введён номер телефона";

                filledFields += filledFieldsTelephone;

                //MessageBox.Show($"3: {filledFields}");
            }

            if (sender == this.buttonNext) // проверка страны
            {
                filledFields++;
                this.toolStripStatusLabel1.Text = "Была выбрана страна";

                MessageBox.Show("4");
            }

            if (sender == this.trackBarGender) // проверка пола
            {
                if (this.trackBarGender.Value != 1) 
                {
                    filledFields++;
                    this.toolStripStatusLabel1.Text = "Был выбран пол";

                    MessageBox.Show("5");
                }
            }

            int percentFilled = (int) (100 / 14 * filledFields);
            this.toolStripProgressBar1.Value = percentFilled;

            //MessageBox.Show($"VALUE: {this.toolStripProgressBar1.Value}\nPERCENT: {percentFilled}\nFILLEDFILDS: {filledFields}");
        }



        /////////////////////////////////////
        //           ПЕРВЫЙ БЛОК           //
        /////////////////////////////////////

        private Random rand = new Random();
        private string language = "RUS";
        private bool caps = true;

        private void button_Click(object sender, EventArgs e) // используется для всех кнопок-букв.
        {
            Button clickedButton = sender as Button; // берётся кнопка, которая вызвала метод,
            this.textBoxFIO.Text += clickedButton.Text; // с этой кнопки добаляется текст в поле с ФИО
        }

        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            this.buttonLanguage.Text = this.buttonLanguage.Text == "RUS" ? "ENG" : "RUS"; // меняется язык на противоположный

            this.language = this.buttonLanguage.Text;
            this.updateKeyboard();
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += " "; // добавляется пробел

            this.caps = true;
            this.updateKeyboard();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text = string.Empty; // строка очищается

            this.caps = true;
            this.updateKeyboard();
        }

        private void buttonCaps_Click(object sender, EventArgs e)
        {
            this.caps = !this.caps; // меняется регистр на противоположный
            this.updateKeyboard();
        }


        private void updateKeyboard()
        {
            ushort from = 0;
            ushort to = 0;

            if (this.language == "RUS") { from = 1040; to = 1072; }
            else if (this.language == "ENG") { from = 65; to = 90; }

            if (this.caps == false) { from += 32; to += 32; }

            foreach (Button button in this.groupBoxFIO.Controls.OfType<Button>().Skip(4))
            {
                button.Text = char.ConvertFromUtf32(this.rand.Next(from, to));
            }
        }

        /////////////////////////////////////
        //           ПЕРВЫЙ БЛОК           //
        /////////////////////////////////////





        /////////////////////////////////////
        //           ВТОРОЙ БЛОК           //
        /////////////////////////////////////

        private void numericUpDownBirthMonth_ValueChanged(object sender, EventArgs e)
        {
            this.updateProgressBar(sender, e);

            if (this.numericUpDownBirthMonth.Value == 4 || this.numericUpDownBirthMonth.Value == 6 || this.numericUpDownBirthMonth.Value == 9 || this.numericUpDownBirthMonth.Value == 11) // если выбрна один из месяцев: апрель, июнь, сентябрь, ноябрь, т.е. 30 дней.
            {
                this.numericUpDownBirthDay.Maximum = 30;
            }
            else if (this.numericUpDownBirthMonth.Value == 2) // если выбран месяц февраль, т.е. 28 или 29 дней.
            {
                /*
                Отсюда следует распределение високосных годов:
                * год, номер которого кратен 400, — високосный;
                * остальные годы, номер которых кратен 100, — невисокосные (например, годы 1700, 1800, 1900, 2100, 2200, 2300);
                * остальные годы, номер которых кратен 4, — високосные;
                * все остальные годы — невисокосные.
                */
                if (this.numericUpDownBirthYear.Value % 400 == 0)
                {
                    this.numericUpDownBirthDay.Maximum = 29;
                }
                else if (this.numericUpDownBirthYear.Value % 100 == 0)
                {
                    this.numericUpDownBirthDay.Maximum = 28;
                }
                else if (this.numericUpDownBirthYear.Value % 4 == 0)
                {
                    this.numericUpDownBirthDay.Maximum = 29;
                }
                else
                {
                    this.numericUpDownBirthDay.Maximum = 28;
                }
            }
            else // если выбран один из этих месяцев: январь, март, май, июль, август, октябрь, август, т.е. 31 день.
            {
                this.numericUpDownBirthDay.Maximum = 31;
            }
        }

        private void numericUpDownBirthYear_ValueChanged(object sender, EventArgs e)
        {
            this.numericUpDownBirthMonth_ValueChanged(sender, e);
        }

        /////////////////////////////////////
        //           ВТОРОЙ БЛОК           //
        /////////////////////////////////////





        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////

        TextBox textBox; // текущий textBox

        private void buttonClearAllTexBox_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in this.groupBoxTelephone.Controls.OfType<TextBox>())
            {
                textBox.Text = null;
                textBox.Enabled = true;
            }
        }

        private void buttonNewNum_Click(object sender, EventArgs e)
        {
            this.textBox.Text = char.ConvertFromUtf32(rand.Next(48, 58));
        }

        private void buttonNextTextBox_Click(object sender, EventArgs e)
        {
            this.textBox = this.groupBoxTelephone.Controls.OfType<TextBox>().Skip(rand.Next(0, 10)).First();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = false;

            this.buttonClearAllTexBox.Enabled = true;
            this.buttonNewNum.Enabled = true;
            this.buttonNextTextBox.Enabled = true;

            this.buttonNextTextBox_Click(sender, e);
        }

        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////




        /////////////////////////////////////
        //           ЧЕТВЁРТЫЙ БЛОК           //
        /////////////////////////////////////

        string[] location = { "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\russia.gif", "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\usa.gif" };
        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.updateProgressBar(sender, e);
            this.pictureBoxCountry.ImageLocation = this.location[rand.Next(0, location.Length)]; // БУДЕТ ЗАБАВНО, ЕСЛИ ОНО ТУТ БУДЕТ ВСЁ РАВНО РАНДОМНО ПЕРЕКЛЮЧАТЬСЯ, ТОЛЬКО НУЖНО БОЛЬШЕ СДЕЛАТЬ СТРАН
        }

        private void buttonPrevious_Click(object sender, EventArgs e) // это бы убрать, чтобы две кнопки на одну функици вели
        {
            this.buttonNext_Click(sender, e);
        }

        /////////////////////////////////////
        //           ЧЕТВЁРТЫЙ БЛОК           //
        /////////////////////////////////////


        private void buttonComplete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("An attempt was made to join or substitute a drive for which a directory on the drive is the target of a previous substitute.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("The operating system cannot run.\r\n\r\nERROR_ALREADY_EXISTS.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("The global filename characters, * or ?, are entered incorrectly or too many global filename characters are specified.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("This version of %1 is not compatible with the version of Windows you're running. Check your computer's system information and then contact the software publisher..", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            MessageBox.Show("401 (0x191)\r\n\r\nThe thread is not in background processing mode.\r\n\r\nERROR_PROCESS_MODE_ALREADY_BACKGROUND", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            Form form = new Form();
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = Image.FromFile("D:\\Downloads\\Bsodwindows10.png");

            pictureBox.Dock = DockStyle.Fill;
            form.Controls.Add(pictureBox);
            form.FormBorderStyle = FormBorderStyle.None;
            form.WindowState = FormWindowState.Maximized;

            form.ShowDialog();

            string persInfo = $"ФИО: {this.textBoxFIO.Text}\t\t\t\n" +
                $"Дата рождения: {this.numericUpDownBirthDay.Value}.{this.numericUpDownBirthMonth.Value}.{this.numericUpDownBirthYear.Value}\n" +
                $"Телефон: +7 ({this.textBox1.Text + this.textBox2.Text + this.textBox3.Text}) {this.textBox4.Text + this.textBox5.Text + this.textBox6.Text} {this.textBox7.Text + this.textBox8.Text}-{this.textBox9.Text + this.textBox10.Text}\n" +
                $"Страна: {"russia"}\n" +
                $"Пол: {(this.trackBarGender.Value == 1 ? "мужской" : "женский")}\n";

            MessageBox.Show(persInfo, "Анкета ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
