﻿
using System.Diagnostics;


namespace Lab_i1
{
    public partial class FormMain : Form
    {
        private const int FixSize = 7; // для первой серии
        private const int FixDistance = 300; // для второй серии 
        private readonly int[] S = [1, 20, 40, 60, 100, 150, 200, 250, 300, 350]; //массив дистанций (вместо 0 поставил 1)
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

        //тех переменные-счётчики
        int currentDistance;
        int currentWidth;
        int currentHeight;

        //Третья серия опытов
        int counterClicks3 = 0; // Количество кликов в третьей серии
        int counterS3 = 0; // Индекс текущей дистанции
        int counterD3 = 0; // Индекс текущего размера


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

            if (radioButton3.Checked)
            {
                counterClicks3++;

                if (counterClicks3 >= 3) // Третья серия требует 3 нажатия
                {
                    double avgTime = results.Average();
                    results.Clear();
                    counterClicks3 = 0;

                    double ratio = (double)currentDistance / currentHeight; // S/D

                    SaveResultsToFile(avgTime, currentDistance, currentWidth, currentHeight, ratio);

                    counterD3++; // Переход к следующему D

                    if (counterD3 >= D.Length) // Если все размеры пройдены, переходим к следующему S
                    {
                        counterD3 = 0;
                        counterS3++;
                    }
                }

                Start_3();
                return;
            }

            // Обработка первых двух серий
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
                    toolStripStatusLabel1.Text = "Выбрана третья серия экспериментов";

                    counterClicks3 = 0;
                    counterS3 = 0;
                    counterD3 = 0;

                    Start_3();
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

            //Угол от 0 до  π / 2 для 4 - й четверти
            double angle = random.NextDouble() * (Math.PI / 2);
            int x = (int)(S[counterS] * Math.Cos(angle));
            int y = (int)(S[counterS] * Math.Sin(angle));

            targetRectangle.Location = new Point(x, y);
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
            currentWidth = D[counterD] * 2;

            textBox_size.Text = currentHeight.ToString();
            textBox_size2.Text = currentWidth.ToString();

            Cursor.Position = new Point(this.Left, this.Top);

            //Угол от 0 до  π / 2 для 4 - й четверти
            double angle = random.NextDouble() * (Math.PI / 2);
            int x = (int)(FixDistance * Math.Cos(angle));
            int y = (int)(FixDistance * Math.Sin(angle));

            targetRectangle.Location = new Point(x,y); // меняем локацию
            targetRectangle.Size = new Size(currentWidth, currentHeight); //меняем размер

            targetRectangle.Visible = true;

            timer.Restart();
        }
        /// <summary>
        /// старт третьей группы экспериментов
        /// </summary>
        private void Start_3()
        {
            if (counterS3 >= S.Length)
            {
                toolStripStatusLabel1.Text = $"Третья серия завершена. Данные записаны в файл {FilePath}";
                return;
            }

            currentDistance = S[counterS3];
            currentHeight = D[counterD3];
            currentWidth = currentHeight * 2;

            textBox_distance.Text = currentDistance.ToString();
            textBox_size.Text = currentHeight.ToString();
            textBox_size2.Text = currentWidth.ToString();

            Cursor.Position = new Point(this.Left, this.Top);

            // Генерируем случайный угол и вычисляем координаты
            double angle = random.NextDouble() * (Math.PI / 2);
            int x = (int)(currentDistance * Math.Cos(angle));
            int y = (int)(currentDistance * Math.Sin(angle));

            targetRectangle.Location = new Point(x, y);
            targetRectangle.Size = new Size(currentWidth, currentHeight);
            targetRectangle.Visible = true;

            timer.Restart();
        }


        /// <summary>
        /// Записывает результаты эксперимента в файл.
        /// </summary>
        private void SaveResultsToFile(double avgTime, int distance = FixDistance, int width = FixSize * 2, int height = FixSize, double ratio = -1)
        {
            try
            {
                using StreamWriter writer = File.AppendText(FilePath);

                if (ratio >= 0)
                {
                    writer.WriteLine($"Дистанция: {distance}\t Размер: {width} * {height}\t Отношение S/D: {ratio:F2}\t Среднее время: {avgTime:F2} мс");
                }
                else
                {
                    writer.WriteLine($"Дистанция: {distance}\t Размер: {width} * {height}\t Среднее время: {avgTime} мс");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}