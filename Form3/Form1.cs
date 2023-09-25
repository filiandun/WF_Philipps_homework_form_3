using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Form3
{
    public partial class Form1 : Form
    {
        private Random rand = new Random();

        // ДЛЯ ПЕРВОГО БЛОКА
        private string language = "RUS"; // текущая раскладка
        private bool caps = true; // текущий CAPS

        // ДЛЯ ТРЕТЬЕГО БЛОКА
        TextBox textBox; // текущий textBox

        // ДЛЯ ЧЕТВЁРТОГО БЛОКА
        private string projectPath; // путь к папке с проектом
        //private DirectoryInfo directoryInfo;


        public Form1()
        {
            InitializeComponent();

            // ДЛЯ ПЕРВОГО БЛОКА
            this.language = "RUS";
            this.caps = true;

            this.groupBoxFIO.Controls.SetChildIndex(this.buttonLanguage, 0); // ВЕСЬ МОЗГ МНЕ ВЫНЕС GROUPBOX, ТАК КАК ВООБЩЕ НЕПОНЯТНО, 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonSpace, 1); // ПО КАКОЙ ЛОГИКЕ ОН ВНУТРИ СЕБЯ НУМИРУЕТ ЭЛЕМЕНТЫ,
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonDelete, 2); // ПОЭТОМУ ПРИШЛОСЬ ЕМУ ПРИНУДИТЕЛЬНО СКАЗАТЬ, КАК МНЕ НАДО. 
            this.groupBoxFIO.Controls.SetChildIndex(this.buttonCaps, 3); // P.S. уже на заключательном этапе, я начинаю догадываться, что это происходит либо по TabIndex, либо по расположения в Form1.Designer
            
            // ДЛЯ ТРЕТЬЕГО БЛОКА
            this.buttonClearAllTexBox.Enabled = false;
            this.buttonNewNum.Enabled = false;
            this.buttonNextTextBox.Enabled = false;

            // ДЛЯ ЧЁТВЕРТОГО БЛОКА
            this.projectPath = AppDomain.CurrentDomain.BaseDirectory.Remove(AppDomain.CurrentDomain.BaseDirectory.Length - 10);
        }


        private void updateProgressBar(object sender, EventArgs e)
        {
            byte filledFields = 0;

            // ПРОВЕРКА ФИО
            if (!string.IsNullOrEmpty(this.textBoxFIO.Text)) 
            {
                Regex regex = new Regex(@"^\D+\s\D+\s\D+$"); 
                if (regex.IsMatch(this.textBoxFIO.Text))
                {
                    filledFields++;
                }
            }

            // ПРОВЕРКА ДАТЫ РОЖДЕНИЯ
            if (this.numericUpDownBirthYear.Value != 1)
            {
                filledFields++;
            }

            // ПРОВЕРКА НОМЕРА ТЕЛЕФОНА
            if (this.groupBoxTelephone.Controls.OfType<TextBox>().Where(n => !String.IsNullOrEmpty(n.Text)).Count() == 10)
            {
                filledFields++;
            }

            // ПРОВЕРКА СТРАНЫ
            if (!String.IsNullOrEmpty(this.pictureBoxCountry.ImageLocation))
            {
                filledFields++;
            }

            // ПРОВЕРКА ПОЛА
            if (this.trackBarGender.Value != 1) 
            {
                filledFields++;
            }

            this.toolStripProgressBar.Value = 20 * filledFields; // задание progressBar'у значения
            this.updateStatusLabel(sender, e); // обновление строки статуса
        }

        private void updateStatusLabel(object sender, EventArgs e)
        {
            if (sender == this.textBoxFIO)
            {
                this.toolStripStatusLabel.Text = $"Последним изменением был ввод ФИО: {this.textBoxFIO.Text}";
            }
            else if (sender == this.numericUpDownBirthDay || sender == this.numericUpDownBirthMonth || sender == this.numericUpDownBirthYear)
            {
                this.toolStripStatusLabel.Text = $"Последним изменением был ввод даты рождения: {this.numericUpDownBirthDay.Value}.{this.numericUpDownBirthMonth.Value}.{this.numericUpDownBirthYear.Value}";
            }
            else if (sender == this.textBox1 || sender == this.textBox2 || sender == this.textBox3 || sender == this.textBox4 || sender == this.textBox5 || sender == this.textBox6 || sender == this.textBox7 || sender == this.textBox8 || sender == this.textBox9 || sender == this.textBox10)
            {
                this.toolStripStatusLabel.Text = $"Последним изменением был ввод номера телефона: +7 ({this.textBox1.Text + this.textBox2.Text + this.textBox3.Text}) {this.textBox4.Text + this.textBox5.Text + this.textBox6.Text} {this.textBox7.Text + this.textBox8.Text}-{this.textBox9.Text + this.textBox10.Text}";
            }
            else if (sender == this.buttonNext || sender == this.buttonPrevious)
            {
                this.toolStripStatusLabel.Text = $"Последним изменением был выбор страны проживания: {Path.GetFileNameWithoutExtension(this.pictureBoxCountry.ImageLocation)}"; // TO DO
            }
            else if (sender == this.trackBarGender)
            {
                this.toolStripStatusLabel.Text = $"Последним изменением был выбор пола: {(this.trackBarGender.Value == 1 ? "мужской" : "женский")}";
            }
        }


        /////////////////////////////////////
        //           ПЕРВЫЙ БЛОК           //
        /////////////////////////////////////

        // МЕТОД, ОТВЕЧАЮЩИЙ ЗА КЛИК НА ЛЮБУЮ КНОПКУ-БУКВУ
        private void button_Click(object sender, EventArgs e) // используется для всех кнопок-букв.
        {
            Button clickedButton = sender as Button; // берётся кнопка, которая вызвала метод,
            this.textBoxFIO.Text += clickedButton.Text; // с этой кнопки добаляется текст в поле с ФИО
        }

        // КНОПКА ДЛЯ ПЕРЕКЛЮЧЕНИЯ РАСКЛАДКИ
        private void buttonLanguage_Click(object sender, EventArgs e)
        {
            this.buttonLanguage.Text = this.buttonLanguage.Text == "RUS" ? "ENG" : "RUS"; // меняется язык на противоположный

            this.language = this.buttonLanguage.Text;
            this.updateKeyboard();
        }

        // КНОПКА "ПРОБЕЛ"
        private void buttonSpace_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text += " "; // добавляется пробел

            this.caps = true;
            this.updateKeyboard();
        }

        // КНОПКА ДЛЯ ОЧИСТКИ ВСЕГО ПОЛЯ ФИО
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.textBoxFIO.Text = string.Empty; // строка очищается

            this.caps = true;
            this.updateKeyboard();
        }

        // КНОПКА "CAPS"
        private void buttonCaps_Click(object sender, EventArgs e)
        {
            this.caps = !this.caps; // меняется регистр на противоположный
            this.updateKeyboard();
        }

        // ОБНОЛВЕНИЕ КНОПОК КЛАВИАТУРЫ
        private void updateKeyboard()
        {
            ushort from = 0;
            ushort to = 0;

            if (this.language == "RUS") { from = 1040; to = 1072; } // по ASCII большие РУС-буквы от 1040 до 1072
            else if (this.language == "ENG") { from = 65; to = 90; } // по ASCII большие АНГ-буквы от 65 до 90

            if (this.caps == false) { from += 32; to += 32; } // если добавить к коду по ASCII хоть к РУС-буквам, хоть к АНГ-буквам - они станут маленькими.

            foreach (Button button in this.groupBoxFIO.Controls.OfType<Button>().Skip(4)) // берётся каждая клавиша-буква (пропускаются четыре кнопки управления) и ей рандомно задаётся буква
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

        // NUMERICUPDOWN, КОТОРЫЙ ОТВЕЧАЕТ ЗА ИЗМЕНЕНИЕ МЕСЯЦА
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
                Распределение високосных годов:
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

        // NUMERICUPDOWN, КОТОРЫЙ ОТВЕЧАЕТ ЗА ИЗМЕНЕНИЕ ГОДА
        private void numericUpDownBirthYear_ValueChanged(object sender, EventArgs e) 
        {
            this.numericUpDownBirthMonth_ValueChanged(sender, e); // лучше бы было создать один метод, который вёл бы и на это свойство и на свойство выше
        }

        /////////////////////////////////////
        //           ВТОРОЙ БЛОК           //
        /////////////////////////////////////





        /////////////////////////////////////
        //           ТРЕТИЙ БЛОК           //
        /////////////////////////////////////


        // КНОПКА ДЛЯ ОЧИСТКИ ВСЕХ ПОЛЕЙ НОМЕРА ТЕЛЕФОНА
        private void buttonClearAllTexBox_Click(object sender, EventArgs e)
        {
            foreach (TextBox textBox in this.groupBoxTelephone.Controls.OfType<TextBox>())
            {
                textBox.Text = null;
            }
        }

        // КНОПКА ДЛЯ ГЕНЕРАЦИИ НОВОГО ЧИСЛА В ТЕКУЩЕМ ПОЛЕ
        private void buttonNewNum_Click(object sender, EventArgs e)
        {
            char generatedNum;

            do
            {
                generatedNum = (char)this.rand.Next(48, 58);
            }
            while (this.textBox.Text.Contains(generatedNum)); // нужно, чтобы новое сгенерированное число не было равно предыдущему в этом же textBox

            this.textBox.Text = generatedNum.ToString();
        }

        // КНОПКА ДЛЯ ВЫБОРА СЛЕДУЮЩЕГО "ТЕКУЩЕГО" ПОЛЯ
        private void buttonNextTextBox_Click(object sender, EventArgs e)
        {
            this.textBox = this.groupBoxTelephone.Controls.OfType<TextBox>().Skip(this.rand.Next(0, 10)).First();
        }

        // КНОПКА ДЛЯ НАЧАЛА ВВОДА
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
        //           ЧЕТВЁРТЫЙ БЛОК        //
        /////////////////////////////////////
        
        DirectoryInfo directoryInfo;
        private void nextCountry(object sender, EventArgs e)
        {
            this.directoryInfo = new DirectoryInfo(Path.Combine(this.projectPath, "Resources", "Countries")); // тут находятся gif'ки

            // this.pictureBoxCountry.ImageLocation = this.directoryInfo.GetFiles().Skip(this.rand.Next(0, 6)).First().FullName; // директория.Получение всех файлов в ней.Пропуск рандомно от 0 до 6 файлов.Взятие одного.Получение полного пути к файлу
            // CHAT GPT порекомендовал мне разделить мою портянку выше на это:
            FileInfo[] files = this.directoryInfo.GetFiles();
            byte randomIndex;
            FileInfo randomFile;
            string newImageLocation;

            do
            {
                randomIndex = (byte) this.rand.Next(0, files.Length);
                randomFile = files[randomIndex];
                newImageLocation = randomFile.FullName;
            } 
            while (this.pictureBoxCountry.ImageLocation == newImageLocation); // проверка, чтобы не было повторов подряд

            this.pictureBoxCountry.ImageLocation = newImageLocation;

            this.updateProgressBar(sender, e);
        }
        /////////////////////////////////////
        //           ЧЕТВЁРТЫЙ БЛОК        //
        /////////////////////////////////////




        // КНОПКА "ГОТОВО", Т.Е. ОТПРАВИТЬ РЕЗУЛЬТАТЫ
        byte can = 0;
        private void buttonComplete_Click(object sender, EventArgs e) // ПРИКОЛЬНО БЫ СДЕЛАТЬ, ЧТОБЫ КНОПКА ПЕРЕМЕЩАЛАСЬ ОТ КУРСОРА В ДРУГУЮ СТОРОНУ
        {
            if (this.toolStripProgressBar.Value == 100)
            {
                can++;
                if (can < 13)
                {
                    this.buttonComplete.Location = new System.Drawing.Point(this.rand.Next(13, 390), this.rand.Next(648, 695));
                }
                else if (can == 13)
                {
                    this.buttonComplete.Location = new System.Drawing.Point(13, 650);
                    this.buttonComplete.Size = new System.Drawing.Size(548, 60);
                }
                else 
                {
                    MessageBox.Show("An attempt was made to join or substitute a drive for which a directory on the drive is the target of a previous substitute.", "Error 129", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("The operating system cannot run.\r\n\r\nERROR_ALREADY_EXISTS.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("The global filename characters, * or ?, are entered incorrectly or too many global filename characters are specified.", "Error global filename", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("This version of %1 is not compatible with the version of Windows you're running. Check your computer's system information and then contact the software publisher.", "Error compatible", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("401 (0x191)\r\n\r\nThe thread is not in background processing mode.\r\n\r\nERROR_PROCESS_MODE_ALREADY_BACKGROUND", "Error (0)", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    Form form = new Form();
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = Image.FromFile(Path.Combine(this.projectPath, "Resources", "BSOD.png"));

                    pictureBox.Dock = DockStyle.Fill;
                    form.Controls.Add(pictureBox);
                    form.FormBorderStyle = FormBorderStyle.None;
                    form.WindowState = FormWindowState.Maximized;

                    form.ShowDialog();

                    string persInfo = $"ФИО: {this.textBoxFIO.Text}\t\t\t\n" +
                        $"Дата рождения: {this.numericUpDownBirthDay.Value}.{this.numericUpDownBirthMonth.Value}.{this.numericUpDownBirthYear.Value}\n" +
                        $"Телефон: +7 ({this.textBox1.Text + this.textBox2.Text + this.textBox3.Text}) {this.textBox4.Text + this.textBox5.Text + this.textBox6.Text} {this.textBox7.Text + this.textBox8.Text}-{this.textBox9.Text + this.textBox10.Text}\n" +
                        $"Страна: {Path.GetFileNameWithoutExtension(this.pictureBoxCountry.ImageLocation)}\n" +
                        $"Пол: {(this.trackBarGender.Value == 1 ? "мужской" : "женский")}\n";

                    MessageBox.Show(persInfo, "Анкета ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля!", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
