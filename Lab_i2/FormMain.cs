using System.Diagnostics;
using System.Drawing;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
        bool isSelected = false;
        List<double> averageTime = new(); //��� ������ �������� ��� ������ ������ ��������
        Stopwatch sw = new(); //����������
        private readonly string txtFilePath = "results.txt";
        private readonly string csvFilePath = "results.csv";


        //****************************2 ������*************************//
        Color[] colors = [Color.Black, Color.Yellow, Color.Green, Color.Red]; // ������ ������, �������� �������� ���� ������ (�����) � ������ (�����)
        Panel[] arrPanel2 = new Panel[9]; // ��� ������ ������
        bool isSelected2 = false;
        int countClick2 = 0; // ��� �������� ��������� ��� ������ ������
        int quantityPanel2 = 2; // ���������� ������� �������� (�������� � ����) ��� ������ ������
        List<double> averageTime2 = new(); //��� ������ �������� ��� ������ ������ �������� ��� ������ ������
        Stopwatch sw2 = new(); //���������� ��� ������ ������
        private readonly string txtFilePath2 = "results2.txt";
        private readonly string csvFilePath2 = "results2.csv";

        Color currentColorBack = Color.White, currentColorFont = Color.Blue;

        public FormMain()
        {
            InitializeComponent();
            this.Load += FormMain_Load;
            radioButton_back.Checked = true;
            radioButton_black.Checked = true;
        }

        private void FormMain_Load(object? sender, EventArgs e)
        {
            CreateArr(arrPanel);
            CreateArr2(arrPanel2); // ������� �� ������ ������� ����������� ������ � ��������
            // ��������� ����� ����
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
                labelCurrentItem.Text = targetNumber.ToString(); // ������� ����� ������, ������� ���� �������
                ShuffleArray(arrPanel, quantityPanel);
                ShowPanel(arrPanel, quantityPanel);
            }
            else
            {
                if (quantityPanel < arrPanel.Length)
                {
                    quantityPanel++;
                    targetNumber = random.Next(1, quantityPanel + 1);
                    labelCurrentItem.Text = targetNumber.ToString(); // ������� ����� ������, ������� ���� �������
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
                    MessageBox.Show("������ ������ ������������� ��������", "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CreateArr(arrPanel);
                }
            }

            sw.Start();

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
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true
                };
                arr[i].Controls.Add(label); // ��������� ����� � ������
                tabPage1.Controls.Add(arr[i]); // ��������� ������ � tabPage1
                label.Location = new Point(20, (arr[i].Height - label.Height) / 2); // �������� �� ������ ���� � �� ������
                arr[i].Click += Panel_Click; // �������� ���������� � ������ ������
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
                            if (averageTime.Count >= 5)
                            {
                                double avg = averageTime.Average();
                                SaveResultsToFile(Math.Round(avg, 2), quantityPanel, txtFilePath, csvFilePath);
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

        /// <summary>
        /// ���������� ���������� ������������ � ��� ����� (txt � csv).
        /// </summary>
        private void SaveResultsToFile(double avgTime, int quantity, string txtPath, string csvPath)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(txtPath))
                {
                    writer.WriteLine($"���������� ��������: {quantityPanel} ������� ����� �� 5 �������: {avgTime}");
                }
                using (StreamWriter writer = File.AppendText(csvPath))
                {
                    writer.WriteLine($"{quantityPanel};{avgTime}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ������ � ����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        //*************����������� � ������ ��� 2� ������*******************//

        private void buttonRun2_Click(object sender, EventArgs e)
        {
            Cursor.Position = new Point(cX, cY);
            isSelected2 = false;


            if (radioButton_back.Checked)
            {
                ResetBack(arrPanel2, quantityPanel2);
                currentColorFont = Color.Blue;

                if (radioButton_black.Checked)
                {
                    RandBack(arrPanel2, quantityPanel2, Color.Black);
                    currentColorBack = Color.Black;
                }
                else if (radioButton_red.Checked)
                {
                    RandBack(arrPanel2, quantityPanel2, Color.Red);
                    currentColorBack = Color.Red;
                }
                else if (radioButton_green.Checked)
                {
                    RandBack(arrPanel2, quantityPanel2, Color.Green);
                    currentColorBack = Color.Green;
                }
                else if (radioButton_yellow.Checked)
                {
                    RandBack(arrPanel2, quantityPanel2, Color.Yellow);
                    currentColorBack = Color.Yellow;
                }
            }
            else if (radioButton_font.Checked)
            {
                ResetColorFont(arrPanel2, quantityPanel2);
                currentColorBack = Color.White;

                if (radioButton_black.Checked)
                {
                    RandColorFont(arrPanel2, quantityPanel2, Color.Black);
                    currentColorFont = Color.Black;
                }
                else if (radioButton_red.Checked)
                {
                    RandColorFont(arrPanel2, quantityPanel2, Color.Red);
                    currentColorFont = Color.Red;
                }
                else if (radioButton_green.Checked)
                {
                    RandColorFont(arrPanel2, quantityPanel2, Color.Green);
                    currentColorFont = Color.Green;
                }
                else if (radioButton_yellow.Checked)
                {
                    RandColorFont(arrPanel2, quantityPanel2, Color.Yellow);
                    currentColorFont = Color.Yellow;
                }
            }


            if (countClick2 < 5)
            {
                ShowPanel2(arrPanel2, quantityPanel2);
            }
            else
            {
                if (quantityPanel2 < arrPanel2.Length)
                {
                    quantityPanel2++;
                    countClick2 = 0;
                    ShowPanel2(arrPanel2, quantityPanel2);
                }
                else
                {
                    quantityPanel2 = 2;
                    countClick2 = 0;

                    for (int i = 0; i < arrPanel2.Length; i++)
                    {
                        arrPanel2[i].Visible = false;
                    }
                    MessageBox.Show("������ ������ ������������� ��������", "!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CreateArr2(arrPanel2);
                }
            }

            sw2.Start();

            this.ActiveControl = null; // ������� ����� � ������
        }

        private void Panel_Click2(object? sender, EventArgs e)
        {
            if (radioButton_back.Checked)
            {
                if (sender is Panel panel)
                {
                    if (radioButton_black.Checked && !isSelected2 && panel.BackColor == Color.Black)
                    {
                        isSelected2 = true;
                        countClick2++;

                    }
                    else if (radioButton_red.Checked && !isSelected2 && panel.BackColor == Color.Red)
                    {
                        isSelected2 = true;
                        countClick2++;
                    }
                    else if (radioButton_green.Checked && !isSelected2 && panel.BackColor == Color.Green)
                    {
                        isSelected2 = true;
                        countClick2++;
                    }
                    else if (radioButton_yellow.Checked && !isSelected2 && panel.BackColor == Color.Yellow)
                    {
                        isSelected2 = true;
                        countClick2++;
                    }

                    Cursor.Position = new Point(cX, cY);
                    sw2.Stop();
                    double res = sw2.Elapsed.TotalMilliseconds;

                    label_time2.Text = res.ToString("F2");

                    averageTime2.Add(res);
                    if (averageTime2.Count >= 5)
                    {
                        double avg = averageTime2.Average();
                        SaveResultsToFile2(Math.Round(avg, 2), quantityPanel2, txtFilePath2, csvFilePath2);
                        averageTime2.Clear();
                    }
                    sw2.Reset();

                }

            }
            else if (radioButton_font.Checked)
            {
                if(sender is Panel panel)
                {
                    if (panel.Controls[0] is Label label)
                    {
                        if (radioButton_black.Checked && !isSelected2 && label.ForeColor == Color.Black)
                        {
                            isSelected2 = true;
                            countClick2++;

                        }
                        else if (radioButton_red.Checked && !isSelected2 && label.ForeColor == Color.Red)
                        {
                            isSelected2 = true;
                            countClick2++;
                        }
                        else if (radioButton_green.Checked && !isSelected2 && label.ForeColor == Color.Green)
                        {
                            isSelected2 = true;
                            countClick2++;
                        }
                        else if (radioButton_yellow.Checked && !isSelected2 && label.ForeColor == Color.Yellow)
                        {
                            isSelected2 = true;
                            countClick2++;
                        }

                        Cursor.Position = new Point(cX, cY);
                        sw2.Stop();
                        double res = sw2.Elapsed.TotalMilliseconds;

                        label_time2.Text = res.ToString("F2");

                        averageTime2.Add(res);
                        if (averageTime2.Count >= 5)
                        {
                            double avg = averageTime2.Average();
                            SaveResultsToFile2(Math.Round(avg, 2), quantityPanel2, txtFilePath2, csvFilePath2);
                            averageTime2.Clear();
                        }
                        sw2.Reset();

                    }
                }
            }
        }

        void ShowPanel2(Panel[] arr, int quantity)
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

        void CreateArr2(Panel[] arr)
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
                    TextAlign = ContentAlignment.MiddleLeft,
                    AutoSize = true
                };
                arr[i].Controls.Add(label); // ��������� ����� � ������
                tabPage2.Controls.Add(arr[i]); // ��������� ������ � tabPage2
                label.Location = new Point(20, (arr[i].Height - label.Height) / 2); // �������� �� ������ ���� � �� ������
                arr[i].Click += Panel_Click2; // �������� ���������� � ������ ������
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

        void RandBack(Panel[] arr, int border, Color color)
        {
            Random rand = new();
            arr[rand.Next(border)].BackColor = color;

        }
        void ResetBack(Panel[] arr, int border)
        {
            for (int i = 0; i < border; i++)
            {
                arr[i].BackColor = Color.White;
            }
        }

        void RandColorFont(Panel[] arr, int border, Color color)
        {
            Random rand = new();
            arr[rand.Next(border)].Controls[0].ForeColor = color;
        }
        void ResetColorFont(Panel[] arr, int border)
        {
            for (int i = 0; i < border; i++)
            {
                arr[i].Controls[0].ForeColor = Color.Blue;
            }
        }

        private void button_reset_Click(object sender, EventArgs e)
        {
            countClick2 = 0;
            quantityPanel2 = 2;
            isSelected2 = false;

            foreach (var panel in arrPanel2)
            {
                tabPage2.Controls.Remove(panel);
            }

            CreateArr2(arrPanel2);
        }


        private void SaveResultsToFile2(double avgTime, int quantity, string txtPath, string csvPath)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(txtPath))
                {
                    writer.WriteLine($"���������� ��������: {quantityPanel2} ���� ������: {currentColorBack} ���� ������: {currentColorFont} ������� ����� �� 5 �������: {avgTime}");
                }
                using (StreamWriter writer = File.AppendText(csvPath))
                {
                    writer.WriteLine($"{quantityPanel2};{currentColorBack};{currentColorFont};{avgTime}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ������ � ����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
