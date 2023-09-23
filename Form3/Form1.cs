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

            this.groupBoxFIO.Controls.SetChildIndex(this.buttonLanguage, 0); // ВЕСЬ МОЗГ МНЕ ВЫНЕС GROUPBOX, ТАК КАК ВООБЩЕ НЕ ПОНЯТНО, 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonSpace, 1); // ПО КАКОЙ ЛОГИКЕ ОН ВНУТРИ СЕБЯ НУМИРУЕТ.
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonDelete, 2); // ПОЭТОМУ ПРИШЛОСЬ ЕМУ ПРИНУДИТЕЛЬНО СКАЗАТЬ, КАК МНЕ НАДО. 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonCaps, 3);

            this.toolStripProgressBar1.Minimum = 0;
            this.toolStripProgressBar1.Maximum = 100;

            this.toolStripProgressBar1.Value = 0;
        }


        /////////////////////////////////////
        //           ПЕРВЫЙ БЛОК           //
        /////////////////////////////////////

        private Random rand = new Random();
        private string language = "RUS";
        private bool caps = true;

        private void button_Click(object sender, EventArgs e) // Используется для всех кнопок-букв.
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
            this.textBoxFIO.Text += " "; // добаляется пробел

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
        //           ВТОРОЙ БЛОК           //
        /////////////////////////////////////




        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////

        string[] location = { "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\russia.gif", "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\usa.gif" };
        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.location[1]; // БУДЕТ ЗАБАВНО, ЕСЛИ ОНО ТУТ БУДЕТ ВСЁ РАВНО РАНДОМНО ПЕРЕКЛЮЧАТЬСЯ, ТОЛЬКО НУЖНО БОЛЬШЕ СДЕЛАТЬ СТРАН
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.location[0];
        }

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

            string persInfo = $"ФИО: {this.textBoxFIO.Text}\n" +
                $"Телефон: +7 ({this.textBox1.Text + this.textBox2.Text + this.textBox3.Text}) {this.textBox4.Text + this.textBox5.Text + this.textBox6.Text} {this.textBox7.Text + this.textBox8.Text}-{this.textBox9.Text + this.textBox10.Text}\n" +
                $"Страна: {"russia"}\n" +
                $"Пол: {(this.trackBarGender.Value == 1 ? "мужской" : "женский")}\n";

            MessageBox.Show(persInfo, "Анкета ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////

    }
}
