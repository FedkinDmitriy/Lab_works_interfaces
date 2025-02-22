using System.Windows.Forms;

namespace Lab_i1
{
    public partial class FormMain : Form
    {
        private readonly int FixDistance = 300; // ��� ������ ����� 
        private readonly int[] S = [0, 20, 40, 60, 100, 150, 200, 250, 300, 350]; //������ ���������
        private readonly int[] D = [8, 10, 12, 15, 20, 30, 50, 70, 100]; //������ ��������

        int counter = 0; //������� ��� ������������ ���������� �������

        public FormMain()
        {
            InitializeComponent();
            this.KeyPreview = true; // ��������� ����� ������������ ������� ������ ����� ��������� ���������
            this.KeyDown += FormMain_KeyDown;
        }

        private void FormMain_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //Cursor.Position = new Point(0, 0); // ����� ����� �� ������
                //Cursor.Position = new Point(this.Location.X + 10, this.Location.Y + 30); // ������������ ��������� �����
                Cursor.Position = new Point(this.Left, this.Top);

                counter++;
                toolStripStatusLabel1.Text = "������� ������ �����";
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
