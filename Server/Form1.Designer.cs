namespace Pratice3Server
{
    partial class Form1
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
            button1 = new Button();
            listBox1 = new ListBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(245, 79);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(235, 127);
            button1.TabIndex = 0;
            button1.Text = "Добавить товар в ассортимент";
            button1.UseVisualStyleBackColor = true;
            button1.Click += AddProductButton;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.Location = new Point(14, 16);
            listBox1.Margin = new Padding(3, 4, 3, 4);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(191, 564);
            listBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(245, 40);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(114, 27);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(366, 40);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(114, 27);
            textBox2.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(245, 16);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 4;
            label1.Text = "Имя товара";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(363, 16);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 5;
            label2.Text = "Цена";
            // 
            // button2
            // 
            button2.Location = new Point(208, 521);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(118, 60);
            button2.TabIndex = 6;
            button2.Text = "Открыть соединение\r\n";
            button2.UseVisualStyleBackColor = true;
            button2.Click += StartListening;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(549, 8);
            textBox3.Margin = new Padding(3, 4, 3, 4);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.ScrollBars = ScrollBars.Both;
            textBox3.Size = new Size(364, 591);
            textBox3.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 600);
            Controls.Add(textBox3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(listBox1);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private ListBox listBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button2;
        private TextBox textBox3;
    }
}
