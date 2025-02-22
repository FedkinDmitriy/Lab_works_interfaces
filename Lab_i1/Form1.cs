
using System.Diagnostics;

namespace Lab_i1
{
    public partial class FormMain : Form
    {
        private readonly int FixSize = 7; // ��� ������ �����
        private readonly int FixDistance = 300; // ��� ������ ����� 
        private readonly int[] S = [0, 20, 40, 60, 100, 150, 200, 250, 300, 350]; //������ ���������
        private readonly int[] D = [8, 10, 12, 15, 20, 30, 50, 70, 100]; //������ ��������

        private Panel targetRectangle; // �������������-������

        int counterClicks = 0; // ���������� ���������
        int counterS = 0; // ������ �������� ����������


        List<double> results = new(); // �������� ������� ���������
        Stopwatch timer = new(); // ������ ��� ��������� �������
        Random random = new(); // ��� ���������� ���������� �� ����

        public FormMain()
        {
            InitializeComponent();
            this.KeyPreview = true; // ��������� ����� ������������ ������� ������ ����� ��������� ���������
            this.KeyDown += FormMain_KeyDown;

            // �������� ������
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
                //Cursor.Position = new Point(0, 0); // ����� ����� �� ������
                //Cursor.Position = new Point(this.Location.X + 10, this.Location.Y + 30); // ������������ ��������� �����


                if (radioButton1.Checked)
                {
                    toolStripStatusLabel1.Text = "������� ������ ����� �������������";
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