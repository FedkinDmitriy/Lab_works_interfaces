namespace Lab_i1
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
            groupBox1 = new GroupBox();
            label4 = new Label();
            textBox_size2 = new TextBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            label3 = new Label();
            radioButton1 = new RadioButton();
            textBox_size = new TextBox();
            label2 = new Label();
            textBox_distance = new TextBox();
            label1 = new Label();
            textBox_counter = new TextBox();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            groupBox1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.GradientActiveCaption;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(textBox_size2);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Controls.Add(textBox_size);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textBox_distance);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(textBox_counter);
            groupBox1.Dock = DockStyle.Right;
            groupBox1.Location = new Point(624, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(170, 594);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Меню";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 420);
            label4.Name = "label4";
            label4.Size = new Size(43, 15);
            label4.TabIndex = 7;
            label4.Text = "Height";
            // 
            // textBox_size2
            // 
            textBox_size2.Location = new Point(110, 417);
            textBox_size2.Name = "textBox_size2";
            textBox_size2.Size = new Size(48, 23);
            textBox_size2.TabIndex = 6;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Location = new Point(15, 91);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(95, 19);
            radioButton3.TabIndex = 3;
            radioButton3.TabStop = true;
            radioButton3.Text = "третья серия";
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(15, 66);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(97, 19);
            radioButton2.TabIndex = 2;
            radioButton2.TabStop = true;
            radioButton2.Text = "вторая серия";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(25, 378);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 5;
            label3.Text = "Width";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Location = new Point(15, 41);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(98, 19);
            radioButton1.TabIndex = 1;
            radioButton1.TabStop = true;
            radioButton1.Text = "первая серия";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // textBox_size
            // 
            textBox_size.Location = new Point(110, 375);
            textBox_size.Name = "textBox_size";
            textBox_size.Size = new Size(48, 23);
            textBox_size.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 337);
            label2.Name = "label2";
            label2.Size = new Size(13, 15);
            label2.TabIndex = 3;
            label2.Text = "S";
            // 
            // textBox_distance
            // 
            textBox_distance.Location = new Point(110, 329);
            textBox_distance.Name = "textBox_distance";
            textBox_distance.Size = new Size(48, 23);
            textBox_distance.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 463);
            label1.Name = "label1";
            label1.Size = new Size(33, 15);
            label1.TabIndex = 1;
            label1.Text = "Click";
            // 
            // textBox_counter
            // 
            textBox_counter.Location = new Point(110, 455);
            textBox_counter.Name = "textBox_counter";
            textBox_counter.Size = new Size(48, 23);
            textBox_counter.TabIndex = 0;
            // 
            // statusStrip1
            // 
            statusStrip1.BackColor = SystemColors.GradientActiveCaption;
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1 });
            statusStrip1.Location = new Point(0, 572);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(624, 22);
            statusStrip1.TabIndex = 1;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(250, 17);
            toolStripStatusLabel1.Text = "Выберите серию в меню и нажмите пробел";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(794, 594);
            ControlBox = false;
            Controls.Add(statusStrip1);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private TextBox textBox_counter;
        private Label label2;
        private TextBox textBox_distance;
        private Label label3;
        private TextBox textBox_size;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private Label label4;
        private TextBox textBox_size2;
    }
}
