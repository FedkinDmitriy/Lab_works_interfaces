namespace Lab_i2
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            label1 = new Label();
            label_time1 = new Label();
            labelCurrentItem = new Label();
            buttonRun = new Button();
            tabPage2 = new TabPage();
            button_reset = new Button();
            flowLayoutPanel2 = new FlowLayoutPanel();
            radioButton_back = new RadioButton();
            radioButton_font = new RadioButton();
            flowLayoutPanel1 = new FlowLayoutPanel();
            radioButton_black = new RadioButton();
            radioButton_red = new RadioButton();
            radioButton_green = new RadioButton();
            radioButton_yellow = new RadioButton();
            label_time2 = new Label();
            label2 = new Label();
            buttonRun2 = new Button();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(780, 557);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = SystemColors.GradientInactiveCaption;
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label_time1);
            tabPage1.Controls.Add(labelCurrentItem);
            tabPage1.Controls.Add(buttonRun);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(772, 529);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Первая группа опытов";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(539, 246);
            label1.Name = "label1";
            label1.Size = new Size(101, 21);
            label1.TabIndex = 4;
            label1.Text = "Время в мс.";
            // 
            // label_time1
            // 
            label_time1.AutoSize = true;
            label_time1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_time1.Location = new Point(670, 246);
            label_time1.Name = "label_time1";
            label_time1.Size = new Size(19, 21);
            label_time1.TabIndex = 3;
            label_time1.Text = "0";
            // 
            // labelCurrentItem
            // 
            labelCurrentItem.AutoSize = true;
            labelCurrentItem.Font = new Font("Segoe UI Semibold", 48F, FontStyle.Bold, GraphicsUnit.Point, 204);
            labelCurrentItem.Location = new Point(539, 37);
            labelCurrentItem.Name = "labelCurrentItem";
            labelCurrentItem.Size = new Size(73, 86);
            labelCurrentItem.TabIndex = 2;
            labelCurrentItem.Text = "0";
            // 
            // buttonRun
            // 
            buttonRun.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonRun.Location = new Point(539, 399);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(150, 50);
            buttonRun.TabIndex = 1;
            buttonRun.TabStop = false;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = SystemColors.GradientInactiveCaption;
            tabPage2.Controls.Add(button_reset);
            tabPage2.Controls.Add(flowLayoutPanel2);
            tabPage2.Controls.Add(flowLayoutPanel1);
            tabPage2.Controls.Add(label_time2);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(buttonRun2);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(772, 529);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Вторая группа опытов";
            // 
            // button_reset
            // 
            button_reset.Location = new Point(632, 137);
            button_reset.Name = "button_reset";
            button_reset.Size = new Size(132, 50);
            button_reset.TabIndex = 5;
            button_reset.Text = "сброс";
            button_reset.UseVisualStyleBackColor = true;
            button_reset.Click += button_reset_Click;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(radioButton_back);
            flowLayoutPanel2.Controls.Add(radioButton_font);
            flowLayoutPanel2.Location = new Point(632, 21);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(132, 110);
            flowLayoutPanel2.TabIndex = 4;
            // 
            // radioButton_back
            // 
            radioButton_back.AutoSize = true;
            radioButton_back.Location = new Point(3, 3);
            radioButton_back.Name = "radioButton_back";
            radioButton_back.Size = new Size(66, 19);
            radioButton_back.TabIndex = 0;
            radioButton_back.TabStop = true;
            radioButton_back.Text = "Панель";
            radioButton_back.UseVisualStyleBackColor = true;
            // 
            // radioButton_font
            // 
            radioButton_font.AutoSize = true;
            radioButton_font.Location = new Point(3, 28);
            radioButton_font.Name = "radioButton_font";
            radioButton_font.Size = new Size(64, 19);
            radioButton_font.TabIndex = 1;
            radioButton_font.TabStop = true;
            radioButton_font.Text = "Шрифт";
            radioButton_font.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(radioButton_black);
            flowLayoutPanel1.Controls.Add(radioButton_red);
            flowLayoutPanel1.Controls.Add(radioButton_green);
            flowLayoutPanel1.Controls.Add(radioButton_yellow);
            flowLayoutPanel1.Location = new Point(494, 21);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(132, 110);
            flowLayoutPanel1.TabIndex = 3;
            // 
            // radioButton_black
            // 
            radioButton_black.AutoSize = true;
            radioButton_black.Location = new Point(3, 3);
            radioButton_black.Name = "radioButton_black";
            radioButton_black.Size = new Size(69, 19);
            radioButton_black.TabIndex = 0;
            radioButton_black.TabStop = true;
            radioButton_black.Text = "Чёрный";
            radioButton_black.UseVisualStyleBackColor = true;
            // 
            // radioButton_red
            // 
            radioButton_red.AutoSize = true;
            radioButton_red.Location = new Point(3, 28);
            radioButton_red.Name = "radioButton_red";
            radioButton_red.Size = new Size(74, 19);
            radioButton_red.TabIndex = 1;
            radioButton_red.TabStop = true;
            radioButton_red.Text = "Красный";
            radioButton_red.UseVisualStyleBackColor = true;
            // 
            // radioButton_green
            // 
            radioButton_green.AutoSize = true;
            radioButton_green.Location = new Point(3, 53);
            radioButton_green.Name = "radioButton_green";
            radioButton_green.Size = new Size(74, 19);
            radioButton_green.TabIndex = 2;
            radioButton_green.TabStop = true;
            radioButton_green.Text = "Зелёный";
            radioButton_green.UseVisualStyleBackColor = true;
            // 
            // radioButton_yellow
            // 
            radioButton_yellow.AutoSize = true;
            radioButton_yellow.Location = new Point(3, 78);
            radioButton_yellow.Name = "radioButton_yellow";
            radioButton_yellow.Size = new Size(70, 19);
            radioButton_yellow.TabIndex = 3;
            radioButton_yellow.TabStop = true;
            radioButton_yellow.Text = "Жёлтый";
            radioButton_yellow.UseVisualStyleBackColor = true;
            // 
            // label_time2
            // 
            label_time2.AutoSize = true;
            label_time2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_time2.Location = new Point(693, 335);
            label_time2.Name = "label_time2";
            label_time2.Size = new Size(19, 21);
            label_time2.TabIndex = 2;
            label_time2.Text = "0";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(562, 335);
            label2.Name = "label2";
            label2.Size = new Size(101, 21);
            label2.TabIndex = 1;
            label2.Text = "Время в мс.";
            // 
            // buttonRun2
            // 
            buttonRun2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            buttonRun2.Location = new Point(562, 393);
            buttonRun2.Name = "buttonRun2";
            buttonRun2.Size = new Size(150, 50);
            buttonRun2.TabIndex = 0;
            buttonRun2.Text = "Run";
            buttonRun2.UseVisualStyleBackColor = true;
            buttonRun2.Click += buttonRun2_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 557);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            Name = "FormMain";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Закон Хика";
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private Button buttonRun;
        private Label labelCurrentItem;
        private Label label_time1;
        private Label label1;
        private Button buttonRun2;
        private Label label_time2;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel1;
        private RadioButton radioButton_black;
        private RadioButton radioButton_red;
        private RadioButton radioButton_green;
        private RadioButton radioButton_yellow;
        private FlowLayoutPanel flowLayoutPanel2;
        private RadioButton radioButton_back;
        private RadioButton radioButton_font;
        private Button button_reset;
    }
}
