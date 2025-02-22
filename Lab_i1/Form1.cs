namespace Lab_i1
{
    public partial class FormMain : Form
    {
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
            }
        }
    }
}
