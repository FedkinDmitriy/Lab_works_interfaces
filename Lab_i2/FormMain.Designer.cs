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
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
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
            label1.Location = new Point(539, 246);
            label1.Name = "label1";
            label1.Size = new Size(72, 15);
            label1.TabIndex = 4;
            label1.Text = "Время в мс.";
            // 
            // label_time1
            // 
            label_time1.AutoSize = true;
            label_time1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label_time1.Location = new Point(670, 240);
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
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(772, 529);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
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
    }
}
