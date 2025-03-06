using System.Xml;

namespace Lab_i2
{
    public partial class FormMain : Form
    {
        const int wPanel = 100, hPanel = 40; //размеры панели 
        int cX, cY; // дл€ расположени€ курсора по центру
        Random random = new();
        Panel[] arrPanel = new Panel[9];
        int countClick = 0; // дл€ подсчЄта попаданий
        int quantityPanel = 2; // количество панелей активных (начинаем с двух)
        int targetNumber = 0; // необходимый элемент дл€ пользовател€
         
        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            CreateArr(arrPanel);
            // ¬ычисл€ем центр окна
            cX = this.Left + this.Width / 2;
            cY = this.Top + this.Height / 2;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Cursor.Position = new Point(cX, cY);

            if (countClick <= 5)
            {
                targetNumber = random.Next(1, quantityPanel + 1);
                labelCurrentItem.Text = targetNumber.ToString(); // выводит номер панели, которую надо выбрать
                ShuffleArray(arrPanel, quantityPanel);
                ShowPanel(arrPanel, quantityPanel);
            }
            else
            {
                quantityPanel++;
                targetNumber = random.Next(1, quantityPanel + 1);
                labelCurrentItem.Text = targetNumber.ToString(); // выводит номер панели, которую надо выбрать

                ShuffleArray(arrPanel, quantityPanel);
                ShowPanel(arrPanel, quantityPanel);

                countClick = 0;
            }

            
            this.ActiveControl = null; // ”бираем фокус с кнопки
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

                    // ѕеремещаем панели в новое положение
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
        /// заполн€ет массив и размещает его
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
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill
                };
                arr[i].Controls.Add(label); // ƒобавл€ем метку в панель
                tabPage1.Controls.Add(arr[i]); // ƒобавл€ем панель в tabPage1

                arr[i].Click += Panel_Click; // прив€жем обработчик к каждой панели
                

                //System.Diagnostics.Debug.WriteLine($"ќбработчик прив€зан к панели {i + 1}");

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
            //System.Diagnostics.Debug.WriteLine("—работал Panel_Click");

            if (sender is Panel panel)
            {
                if (panel.Controls[0] is Label label)
                {
                    int num = Convert.ToInt32(label.Text);
                    if(num == targetNumber)
                    {
                        countClick++;
                    }
                }
            }

            //label_time1.Text = countClick.ToString(); 
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
                n--;  // ”меньшаем размер массива на 1, чтобы переставить элементы с оставшимис€
                int k = rand.Next(n + 1);  // ѕолучаем случайное число от 0 до n (включительно)

                // ѕеремещаем элементы массива
                Panel temp = array[n];  // —охран€ем текущий элемент в temp
                array[n] = array[k];  // ѕеремещаем случайный элемент в текущее место
                array[k] = temp;  // ѕеремещаем элемент из temp в случайное место
            }
        }


    }
}
