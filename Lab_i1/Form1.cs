using System.Windows.Forms;

namespace Lab_i1
{
    public partial class FormMain : Form
    {
        private readonly int FixDistance = 300; // дл€ второй серии 
        private readonly int[] S = [0, 20, 40, 60, 100, 150, 200, 250, 300, 350]; //массив дистанций
        private readonly int[] D = [8, 10, 12, 15, 20, 30, 50, 70, 100]; //массив размеров

        int counter = 0; //счЄтчик дл€ визуализации количества нажатий

        public FormMain()
        {
            InitializeComponent();
            this.KeyPreview = true; // ѕозвол€ет форме обрабатывать нажати€ клавиш перед передачей элементам
            this.KeyDown += FormMain_KeyDown;
        }

        private void FormMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //Cursor.Position = new Point(0, 0); // люба€ точка на экране
                //Cursor.Position = new Point(this.Location.X + 10, this.Location.Y + 30); // относительно заголовка формы
                Cursor.Position = new Point(this.Left, this.Top);

                counter++;
                toolStripStatusLabel1.Text = "выбрана перва€ сери€";
                textBox_counter.Text = counter.ToString();

                if (radioButton1.Checked)
                {

                }
                else if (radioButton2.Checked)
                {

                }
                else if (radioButton3.Checked)
                {

                }
            }
            
        }

    }
}
