namespace TcpLientPratice
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
            textBox1 = new TextBox();
            comboBox1 = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 27);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(186, 23);
            textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(204, 27);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(202, 23);
            comboBox1.TabIndex = 1;
            comboBox1.SelectedIndexChanged += SelectProduct;
            // 
            // button1
            // 
            button1.Location = new Point(12, 51);
            button1.Name = "button1";
            button1.Size = new Size(186, 27);
            button1.TabIndex = 2;
            button1.Text = "Получить";
            button1.UseVisualStyleBackColor = true;
            button1.Click += SendMessageButton;
            // 
            // button2
            // 
            button2.Location = new Point(412, 27);
            button2.Name = "button2";
            button2.Size = new Size(93, 56);
            button2.TabIndex = 3;
            button2.Text = "Получить товары в наличии";
            button2.UseVisualStyleBackColor = true;
            button2.Click += GetProductsAsync;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(12, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(186, 23);
            textBox2.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(143, 15);
            label1.TabIndex = 5;
            label1.Text = "Введите название товара";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(181, 9);
            label2.Name = "label2";
            label2.Size = new Size(235, 15);
            label2.TabIndex = 6;
            label2.Text = "или выберите товар из тех что в наличии";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 105);
            label3.Name = "label3";
            label3.Size = new Size(138, 15);
            label3.TabIndex = 7;
            label3.Text = "Информация по товару";
            // 
            // button3
            // 
            button3.Location = new Point(0, 397);
            button3.Name = "button3";
            button3.Size = new Size(126, 51);
            button3.TabIndex = 8;
            button3.Text = "Подключиться к серверу";
            button3.UseVisualStyleBackColor = true;
            button3.Click += StartReceivingButton;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private ComboBox comboBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button3;
    }
}
