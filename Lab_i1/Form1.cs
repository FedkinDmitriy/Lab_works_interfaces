
using System.Diagnostics;

namespace Lab_i1
{
    public partial class FormMain : Form
    {
        private readonly int FixSize = 7; // для первой серии
        private readonly int FixDistance = 300; // для второй серии 
        private readonly int[] S = [0, 20, 40, 60, 100, 150, 200, 250, 300, 350]; //массив дистанций
        private readonly int[] D = [8, 10, 12, 15, 20, 30, 50, 70, 100]; //массив размеров

        private Panel targetRectangle; // Прямоугольник-мишень

        int counterClicks = 0; // Количество попаданий
        int counterS = 0; // Индекс текущего расстояния


        List<double> results = new(); // Хранение времени попаданий
        Stopwatch timer = new(); // Таймер для измерения времени
        Random random = new(); // Для случайного размещения по дуге

        public FormMain()
        {
            InitializeComponent();
            this.KeyPreview = true; // Позволяет форме обрабатывать нажатия клавиш перед передачей элементам
            this.KeyDown += FormMain_KeyDown;

            // Создание мишени
            targetRectangle = new Panel
            {
                Size = new Size(FixSize, FixSize * 2),
                BackColor = Color.Black,
                Visible = true
            };
            //targetRectangle.MouseClick += TargetRectangle_MouseClick;
            this.Controls.Add(targetRectangle);
        }



        private void FormMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                //Cursor.Position = new Point(0, 0); // любая точка на экране
                //Cursor.Position = new Point(this.Location.X + 10, this.Location.Y + 30); // относительно заголовка формы


                if (radioButton1.Checked)
                {
                    toolStripStatusLabel1.Text = "Выбрана первая серия экспериментов";
                    Cursor.Position = new Point(this.Left, this.Top);

                    counterClicks = 0;
                    counterS = 0;




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