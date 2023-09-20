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

namespace Form3
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        string[] location = { "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\putin walking.gif", "D:\\IT\\Repositories WF\\WF_Philipps_homework_form_3\\Form3\\Resources\\tramp.gif" };

        public Form1()
        {
            InitializeComponent();

            this.buttonRestart.Enabled = false;
            this.buttonSet.Enabled = false;
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {

            this.pictureBox1.ImageLocation = this.location[1];
        }

        private void buttonPrevious_Click(object sender, EventArgs e)
        {
            this.pictureBox1.ImageLocation = this.location[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "й";
            }
            else
            {
                this.textBoxFIO.Text = "q";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "ц";
            }
            else
            {
                this.textBoxFIO.Text = "w";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "у";
            }
            else
            {
                this.textBoxFIO.Text = "e";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "к";
            }
            else
            {
                this.textBoxFIO.Text = "r";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "е";
            }
            else
            {
                this.textBoxFIO.Text = "t";
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "н";
            }
            else
            {
                this.textBoxFIO.Text = "y";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "г";
            }
            else
            {
                this.textBoxFIO.Text = "u";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "ш";
            }
            else
            {
                this.textBoxFIO.Text = "i";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "щ";
            }
            else
            {
                this.textBoxFIO.Text = "o";
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {   
                this.textBoxFIO.Text = "з";
            }
            else
            {
                this.textBoxFIO.Text = "p";
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.textBoxFIO.Text = "х";
            }
            else
            {
                this.textBoxFIO.Text = "";
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void button20_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {

        }

        private void button25_Click(object sender, EventArgs e)
        {

        }

        private void button26_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {

        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void button32_Click(object sender, EventArgs e)
        {

        }

        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            if (this.buttonLanguage.Text == "RUS")
            {
                this.buttonLanguage.Text = "ENG";

                this.button11.Visible = false; this.button12.Visible = false; this.button22.Visible = false; this.button23.Visible = false; this.button31.Visible = false; this.button32.Visible = false;
                
                foreach (Button button in this.groupBoxFIO.Controls.OfType<Button>())
                {
                    button.Text = (button.Text[0] + 1001).ToString();
                }
            }
            else
            {
                this.buttonLanguage.Text = "RUS";

                this.button11.Visible = true;
                this.button12.Visible = true;
                this.button22.Visible = true;
                this.button23.Visible = true;
                this.button31.Visible = true;
                this.button32.Visible = true;

                foreach (Button button in this.groupBoxFIO.Controls.OfType<Button>())
                {
                    button.Text = (button.Text[0] - 1001).ToString();
                }
            }
        }
    }
}
