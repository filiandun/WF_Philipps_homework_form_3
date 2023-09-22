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

namespace Form3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.buttonRestart.Enabled = false;
            this.buttonSet.Enabled = false;

            this.groupBoxFIO.Controls.SetChildIndex(this.buttonLanguage, 0); // ВЕСЬ МОЗГ МНЕ ВЫНЕС GROUPBOX, ТАК КАК ВООБЩЕ НЕ ПОНЯТНО, 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonSpace, 1); // ПО КАКОЙ ЛОГИКЕ ОН ВНУТРИ СЕБЯ НУМИРУЕТ.
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonDelete, 2); // ПОЭТОМУ ПРИШЛОСЬ ЕМУ ПРИНУДИТЕЛЬНО СКАЗАТЬ, КАК МНЕ НАДО. 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonCaps, 3);

        }


        /////////////////////////////////////
        //           ПЕРВЫЙ БЛОК           //
        /////////////////////////////////////

        private Random rand = new Random();
        private string language = "RUS";
        private bool caps = true;

        private void button1_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button15.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button19.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button20.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button21.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button22.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button23.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button24.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button25.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button26.Text;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button27.Text;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button28.Text;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button29.Text;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button30.Text;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button31.Text;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += this.button32.Text;
        }



        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            this.buttonLanguage.Text = this.buttonLanguage.Text == "RUS" ? "ENG" : "RUS";

            this.language = this.buttonLanguage.Text;
            this.updateKeyboards();
        }

        private void buttonSpace_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += " "; // добаляется пробел

            this.caps = true;
            this.updateKeyboards();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text = string.Empty; // строка очищается

            this.caps = true;
            this.updateKeyboards();
        }

        private void buttonCaps_Click(object sender, EventArgs e)
        {
            this.caps = !this.caps; // меняется регистр на противоположный
            this.updateKeyboards();
        }



        private void updateKeyboards()
        {
            ushort from = 0;
            ushort to = 0;

            if (this.language == "RUS")
            {
                from = 1040;
                to = 1072;
            }
            else if (this.language == "ENG")
            {
                from = 65;
                to = 90;
            }

            if (this.caps == false)
            {
                from += 32;
                to += 32;
            }

            foreach (Button button in this.groupBoxFIO.Controls.OfType<Button>().Skip(5))
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

        private ushort counter = 0;

        private void buttonRestart_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in this.groupBoxTelephone.Controls.OfType<TextBox>())
            {
                textBox.Enabled = true;
                textBox.Text = null;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            this.buttonSet.Enabled = true;
            this.buttonRestart.Enabled = true;

            this.buttonStart.Enabled = false;

            this.generatingNumber();
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            counter++;

            foreach (TextBox textBox in this.groupBoxTelephone.Controls.OfType<TextBox>().Skip(counter - 1).Take(1))
            {
                textBox.Enabled = false;
            }

            this.generatingNumber();
        }

        private async void generatingNumber()
        {
            foreach (TextBox textBox in this.groupBoxTelephone.Controls.OfType<TextBox>())
            {
                if (String.IsNullOrEmpty(textBox.Text))
                {
                    while (textBox.Enabled)
                    {
                        textBox.Text = this.rand.Next(0, 9).ToString();
                        await Task.Delay(250);
                    }
                }
            }
        }

        /////////////////////////////////////
        //           ВТОРОЙ БЛОК           //
        /////////////////////////////////////







        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////

        string[] location = { "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\putin walking.gif", "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\tramp.gif" };
        
        private void buttonNext_Click(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.location[1]; // БУДЕТ ЗАБАВНО, ЕСЛИ ОНО ТУТ БУДЕТ ВСЁ РАВНО РАНДОМНО ПЕРЕКЛЮЧАТЬСЯ, ТОЛЬКО НУЖНО БОЛЬШЕ СДЕЛАТЬ
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.location[0];
        }





        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////

    }
}
