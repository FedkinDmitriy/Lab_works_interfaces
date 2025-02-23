
using System.Diagnostics;


namespace Lab_i1
{
    public partial class FormMain : Form
    {
        private const int FixSize = 7; // для первой серии
        private const int FixDistance = 300; // для второй серии 
        private readonly int[] S = [0, 20, 40, 60, 100, 150, 200, 250, 300, 350]; //массив дистанций
        private readonly int[] D = [8, 10, 12, 15, 20, 30, 50, 70, 100]; //массив размеров

        private Panel targetRectangle; // Прямоугольник-мишень

        int counterClicks = 0; // Количество попаданий
        int counterS = 0; // Индекс текущего расстояния
        int counterD = 0; // Индекс текущего размера
        bool isMouseMoving = false; // флаг для курсора

        Stopwatch timer = new(); // Таймер для измерения времени
        Random random = new(); // Для случайного размещения по дуге
        List<double> results = new(); // Хранение времени попаданий

        private readonly string FilePath = "results.txt";

        int currentDistance;
        int currentWidth;
        int currentHeight;

        public FormMain()
        {
            InitializeComponent();
            this.KeyPreview = true; // Позволяет форме обрабатывать нажатия клавиш перед передачей элементам
            this.KeyDown += FormMain_KeyDown;
            this.MouseMove += FormMain_MouseMove; // отслеживание курсора

            // Создание мишени
            targetRectangle = new Panel
            {
                Size = new Size(FixSize * 2, FixSize),
                BackColor = Color.Black,
                Visible = false
            };
            targetRectangle.MouseClick += TargetRectangle_MouseClick;
            this.Controls.Add(targetRectangle);
        }

        private void FormMain_MouseMove(object? sender, MouseEventArgs e)
        {
            if (!isMouseMoving && (Cursor.Position.X != this.Left || Cursor.Position.Y != this.Top))
            {
                timer.Restart();
                isMouseMoving = true;
            }
        }

        private void TargetRectangle_MouseClick(object? sender, MouseEventArgs e)
        {
            timer.Stop();
            double elapsedTime = timer.Elapsed.TotalMilliseconds;
            results.Add(elapsedTime);

            if (results.Count >= 5)
            {
                var time = results.Average();
                results.Clear();

                if (radioButton1.Checked)
                {                    
                    SaveResultsToFile(time, distance: currentDistance);
                }
                else if(radioButton2.Checked)
                {
                    SaveResultsToFile(time, width: currentWidth, height: currentHeight);
                }
            }

            counterClicks++;
            textBox_counter.Text = counterClicks.ToString();

            if (counterClicks >= 5)
            {
                counterClicks = 0;
                counterS++;
                counterD++;
            }

            if (radioButton1.Checked)
            {
                Start_1();
            }
            else if (radioButton2.Checked)
            {
                Start_2();
            }
            else if (radioButton3.Checked)
            {

            }

        }

        private void FormMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && radioButton1.Checked || radioButton2.Checked || radioButton3.Checked)
            {
                //Cursor.Position = new Point(0, 0); // любая точка на экране
                //Cursor.Position = new Point(this.Location.X + 10, this.Location.Y + 30); // относительно заголовка формы
                //Cursor.Position = new Point(this.Left, this.Top);

                if (radioButton1.Checked)
                {
                    toolStripStatusLabel1.Text = "Выбрана первая серия экспериментов";
                    
                    counterClicks = 0;
                    counterS = 0;

                    Start_1();

                }
                else if (radioButton2.Checked)
                {
                    toolStripStatusLabel1.Text = "Выбрана вторая серия экспериментов";

                    counterClicks = 0;
                    counterD = 0;

                    Start_2();
                }
                else if (radioButton3.Checked)
                {

                }
            }

        }
        /// <summary>
        /// старт первой серии экспериментов
        /// </summary>
        private void Start_1()
        {
            if (counterS >= S.Length)
            {
                toolStripStatusLabel1.Text =  $"Первая серия завершена. Данные записаны в файл {FilePath}";
                return;
            }
            textBox_distance.Text = S[counterS].ToString();
            currentDistance = S[counterS];
            textBox_size.Text = FixSize.ToString();
            textBox_size2.Text = (FixSize * 2).ToString();

            Cursor.Position = new Point(this.Left, this.Top);

            targetRectangle.Location = RandPoint();

            targetRectangle.Visible = true;

            timer.Restart();
        }
        /// <summary>
        /// старт второй серии экспериментов
        /// </summary>
        private void Start_2()
        {

            if (counterD >= D.Length)
            {
                toolStripStatusLabel1.Text = $"Вторая серия завершена. Данные записаны в файл {FilePath}";
                return;
            }

            textBox_distance.Text = FixDistance.ToString();

            currentHeight = D[counterD];
            currentWidth = D[counterD * 2];

            textBox_size.Text = currentHeight.ToString();
            textBox_size2.Text = currentWidth.ToString();

            Cursor.Position = new Point(this.Left, this.Top);

            targetRectangle.Location = RandPoint();

            targetRectangle.Visible = true;

            timer.Restart();
        }

        /// <summary>
        /// Записывает результаты эксперимента в файл.
        /// </summary>
        private void SaveResultsToFile(double avgTime, int distance = FixDistance, int width = FixSize * 2, int height = FixSize)
        {
            try
            {
                using StreamWriter writer = File.AppendText(FilePath);
                writer.WriteLine($"Дистанция: {distance}, Размер: {width} * {height}, Среднее время: {avgTime} мс");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// размещает цель по дуге
        /// </summary>
        /// <returns></returns>
        private Point RandPoint()
        {
            //Угол от 0 до  π / 2 для 4 - й четверти
            double angle = random.NextDouble() * (Math.PI / 2);
            int x = (int)(S[counterS] * Math.Cos(angle));
            int y = (int)(S[counterS] * Math.Sin(angle));

            return new Point(x, y);
        }
    }
}