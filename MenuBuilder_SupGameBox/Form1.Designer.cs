namespace MenuBuilder_SupGameBox
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
            listView1 = new ListView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            button7 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button8 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.FullRowSelect = true;
            listView1.GridLines = true;
            listView1.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            listView1.Location = new Point(12, 39);
            listView1.Name = "listView1";
            listView1.Size = new Size(879, 256);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // button1
            // 
            button1.Location = new Point(12, 301);
            button1.Name = "button1";
            button1.Size = new Size(96, 30);
            button1.TabIndex = 1;
            button1.Text = "Move Up";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(114, 301);
            button2.Name = "button2";
            button2.Size = new Size(96, 30);
            button2.TabIndex = 1;
            button2.Text = "Add Item";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(216, 301);
            button3.Name = "button3";
            button3.Size = new Size(96, 30);
            button3.TabIndex = 1;
            button3.Text = "Remove Item";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(318, 301);
            button4.Name = "button4";
            button4.Size = new Size(96, 30);
            button4.TabIndex = 1;
            button4.Text = "Move Down";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(795, 301);
            button5.Name = "button5";
            button5.Size = new Size(96, 30);
            button5.TabIndex = 4;
            button5.Text = "Compile!";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(504, 301);
            button6.Name = "button6";
            button6.Size = new Size(113, 30);
            button6.TabIndex = 1;
            button6.Text = "Config OneBus";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(623, 301);
            button7.Name = "button7";
            button7.Size = new Size(166, 30);
            button7.TabIndex = 1;
            button7.Text = "Set Start CHR and PRG";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(98, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 25);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(80, 17);
            label1.TabIndex = 6;
            label1.Text = "Build Folder:";
            // 
            // button8
            // 
            button8.Location = new Point(506, 8);
            button8.Name = "button8";
            button8.Size = new Size(75, 23);
            button8.TabIndex = 7;
            button8.Text = "Browse";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 339);
            Controls.Add(button8);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button5);
            Controls.Add(button7);
            Controls.Add(button6);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Menu Builder for Sup Game Box 400-in-1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TextBox textBox1;
        private Label label1;
        private Button button8;
    }
}
