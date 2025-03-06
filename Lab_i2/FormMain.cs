using System.Xml;

namespace Lab_i2
{
    public partial class FormMain : Form
    {
        const int wPanel = 100, hPanel = 40; //������� ������ 
        int cX, cY; // ��� ������������ ������� �� ������
        Random random = new();
        Panel[] arrPanel = new Panel[9];
        int countClick = 0; // ��� �������� ���������
        int quantityPanel = 2; // ���������� ������� �������� (�������� � ����)
        int targetNumber = 0; // ����������� ������� ��� ������������
         
        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            CreateArr(arrPanel);
            // ��������� ����� ����
            cX = this.Left + this.Width / 2;
            cY = this.Top + this.Height / 2;
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            Cursor.Position = new Point(cX, cY);

            if (countClick <= 5)
            {
                targetNumber = random.Next(1, quantityPanel + 1);
                labelCurrentItem.Text = targetNumber.ToString(); // ������� ����� ������, ������� ���� �������
                ShuffleArray(arrPanel, quantityPanel);
                ShowPanel(arrPanel, quantityPanel);
            }
            else
            {
                quantityPanel++;
                targetNumber = random.Next(1, quantityPanel + 1);
                labelCurrentItem.Text = targetNumber.ToString(); // ������� ����� ������, ������� ���� �������

                ShuffleArray(arrPanel, quantityPanel);
                ShowPanel(arrPanel, quantityPanel);

                countClick = 0;
            }

            
            this.ActiveControl = null; // ������� ����� � ������
        }

        /// <summary>
        /// ���������� ������
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="quantity"></param>
        void ShowPanel(Panel[] arr, int quantity)
        {
            if (quantity <= arr.Length)
            {
                int forPositiveY = 250; // ��������� ���������� Y ������������ �����
                int forNegativeY = 300; // ��������� ���������� Y ������������ �����

                for (int i = 0; i < quantity; i++)
                {
                    arr[i].Visible = true;

                    // ���������� ������ � ����� ���������
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
        /// ��������� ������ � ��������� ���
        /// </summary>
        /// <param name="arr"></param>
        void CreateArr(Panel[] arr)
        {
            int forPositiveY = 250; // ��������� ���������� Y ������������ �����
            int forNegativeY = 300; // ��������� ���������� Y ������������ �����

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
                arr[i].Controls.Add(label); // ��������� ����� � ������
                tabPage1.Controls.Add(arr[i]); // ��������� ������ � tabPage1

                arr[i].Click += Panel_Click; // �������� ���������� � ������ ������
                

                //System.Diagnostics.Debug.WriteLine($"���������� �������� � ������ {i + 1}");

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
            //System.Diagnostics.Debug.WriteLine("�������� Panel_Click");

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
        /// ������������ ������
        /// </summary>
        /// <param name="array"></param>
        private void ShuffleArray(Panel[] array, int currentBorder)
        {
            Random rand = new Random();
            int n = currentBorder;
            while (n > 1)
            {
                n--;  // ��������� ������ ������� �� 1, ����� ����������� �������� � �����������
                int k = rand.Next(n + 1);  // �������� ��������� ����� �� 0 �� n (������������)

                // ���������� �������� �������
                Panel temp = array[n];  // ��������� ������� ������� � temp
                array[n] = array[k];  // ���������� ��������� ������� � ������� �����
                array[k] = temp;  // ���������� ������� �� temp � ��������� �����
            }
        }


    }
}
