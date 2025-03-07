using System.Diagnostics;
using System.Xml;

namespace Lab_i2
{
    public partial class FormMain : Form
    {
        const int wPanel = 100, hPanel = 40; //размеры панели 
        int cX, cY; // для расположения курсора по центру
        Random random = new();
        Panel[] arrPanel = new Panel[9];
        int countClick = 0; // для подсчёта попаданий
        int quantityPanel = 2; // количество панелей активных (начинаем с двух)
        int targetNumber = 0; // необходимый элемент для пользователя
        bool isSelected = false;
        List<double> averageTime = new(); //для записи среднего для каждой группы объектов
        Stopwatch sw = new(); //секундомер
        private readonly string txtFilePath = "results.txt";
        private readonly string csvFilePath = "results.csv";

        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            CreateArr(arrPanel);
            // Вычисляем центр окна
            cX = this.Left + this.Width / 2;
            cY = this.Top + this.Height / 2;
           
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Cursor.Position = new Point(cX, cY);
            isSelected = false;

            if (countClick < 5)
            {
                targetNumber = random.Next(1, quantityPanel + 1);
                labelCurrentItem.Text = targetNumber.ToString(); // выводит номер панели, которую надо выбрать
                ShuffleArray(arrPanel, quantityPanel);
                ShowPanel(arrPanel, quantityPanel);
            }
            else
            {
                if (quantityPanel < arrPanel.Length)
                {
                    quantityPanel++;
                    targetNumber = random.Next(1, quantityPanel + 1);
                    labelCurrentItem.Text = targetNumber.ToString(); // выводит номер панели, которую надо выбрать
                    countClick = 0;

                    ShuffleArray(arrPanel, quantityPanel);
                    ShowPanel(arrPanel, quantityPanel);

                }
                else
                {
                    quantityPanel = 2;
                    countClick = 0;
                    label_time1.Text = "0";
                    labelCurrentItem.Text = "0";
                    for (int i = 0; i < arrPanel.Length; i++)
                    {
                        arrPanel[i].Visible = false;
                    }
                    MessageBox.Show("первая группа экспериментов звершена", "!", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    CreateArr(arrPanel);
                }
            }

            sw.Start();
            
            this.ActiveControl = null; // Убираем фокус с кнопки
        }

        /// <summary>
        /// отображает панели
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="quantity"></param>
        void ShowPanel(Panel[] arr, int quantity)
        {
            if (quantity <= arr.Length)
            {
                int forPositiveY = 250; // стартовые координаты Y относительно формы
                int forNegativeY = 300; // стартовые координаты Y относительно формы

                for (int i = 0; i < quantity; i++)
                {
                    arr[i].Visible = true;

                    // Перемещаем панели в новое положение
                    if (i % 2 == 0)
                    {
                        arr[i].Location = new Point(150, forPositiveY);
                        forPositiveY -= 50;
                    }
                    else
                    {
                        arr[i].Location = new Point(150, forNegativeY);
                        forNegativeY += 50;
                    }
                }
            }
        }

        /// <summary>
        /// заполняет массив и размещает его
        /// </summary>
        /// <param name="arr"></param>
        void CreateArr(Panel[] arr)
        {
            int forPositiveY = 250; // стартовые координаты Y относительно формы
            int forNegativeY = 300; // стартовые координаты Y относительно формы

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = new Panel
                {
                    Size = new Size(wPanel, hPanel),
                    BackColor = Color.White,
                    Visible = false
                };
                Label label = new Label
                {
                    Text = (i + 1).ToString(),
                    ForeColor = Color.Blue,
                    Font = new Font("Times New Roman", 14, FontStyle.Bold),
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true
                };
                arr[i].Controls.Add(label); // Добавляем метку в панель
                tabPage1.Controls.Add(arr[i]); // Добавляем панель в tabPage1
                label.Location = new Point(20, (arr[i].Height - label.Height) / 2); // Смещение от левого края и по центру
                arr[i].Click += Panel_Click; // привяжем обработчик к каждой панели
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    arr[i].Location = new Point(150, forPositiveY);
                    forPositiveY -= 50;
                }
                else
                {
                    arr[i].Location = new Point(150, forNegativeY);
                    forNegativeY += 50;
                }
            }
        }

        private void Panel_Click(object? sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("Сработал Panel_Click");
            //System.Media.SystemSounds.Beep.Play();

            if (sender is Panel panel)
            {
                if (panel.Controls[0] is Label label)
                {
                    try
                    {
                        int num = Convert.ToInt32(label.Text);
                        if (num == targetNumber && !isSelected)
                        {
                            countClick++;
                            isSelected = true;
                            Cursor.Position = new Point(cX, cY);

                            sw.Stop();
                            double res = sw.Elapsed.TotalMilliseconds;
                            label_time1.Text = res.ToString("F2");
                            averageTime.Add(res);
                            if(averageTime.Count >= 5)
                            {
                                double avg = averageTime.Average();
                                SaveResultsToFile(Math.Round(avg, 2), quantityPanel);
                                averageTime.Clear();
                            }
                            sw.Reset();
                        }
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex.Message);
                    }
                }
            }
          
            
        }

        /// <summary>
        /// перемешивает массив
        /// </summary>
        /// <param name="array"></param>
        private void ShuffleArray(Panel[] array, int currentBorder)
        {
            Random rand = new Random();
            int n = currentBorder;
            while (n > 1)
            {
                n--;  // Уменьшаем размер массива на 1, чтобы переставить элементы с оставшимися
                int k = rand.Next(n + 1);  // Получаем случайное число от 0 до n (включительно)

                // Перемещаем элементы массива
                Panel temp = array[n];  // Сохраняем текущий элемент в temp
                array[n] = array[k];  // Перемещаем случайный элемент в текущее место
                array[k] = temp;  // Перемещаем элемент из temp в случайное место
            }
        }

        /// <summary>
        /// Записывает результаты эксперимента в два файла (txt и csv).
        /// </summary>
        private void SaveResultsToFile(double avgTime, int quantity)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(txtFilePath))
                {
                    writer.WriteLine($"Количество объектов: {quantityPanel} среднее время из 5 попыток: {avgTime}");
                }
                using (StreamWriter writer = File.AppendText(csvFilePath))
                {
                    writer.WriteLine($"{quantityPanel};{avgTime}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка записи в файл: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
