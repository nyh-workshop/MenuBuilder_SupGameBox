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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            button9 = new Button();
            button10 = new Button();
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
            button1.Image = Properties.Resources._103296_full_up_arrow_icon;
            button1.Location = new Point(12, 301);
            button1.Name = "button1";
            button1.Size = new Size(54, 54);
            button1.TabIndex = 1;
            button1.Tag = "\"Move Up\"";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            button1.MouseHover += button1_MouseHover;
            // 
            // button2
            // 
            button2.Image = Properties.Resources._1110960_essential_in_plus_round_set_icon;
            button2.Location = new Point(72, 301);
            button2.Name = "button2";
            button2.Size = new Size(54, 54);
            button2.TabIndex = 1;
            button2.Tag = "\"Add Item\"";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            button2.MouseHover += button2_MouseHover;
            // 
            // button3
            // 
            button3.Image = Properties.Resources._1110958_essential_out_minus_round_set_icon;
            button3.Location = new Point(132, 301);
            button3.Name = "button3";
            button3.Size = new Size(54, 54);
            button3.TabIndex = 1;
            button3.Tag = "\"Remove Item\"";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            button3.MouseHover += button3_MouseHover;
            // 
            // button4
            // 
            button4.Image = Properties.Resources._103291_down_full_arrow_icon;
            button4.Location = new Point(192, 300);
            button4.Name = "button4";
            button4.Size = new Size(54, 54);
            button4.TabIndex = 1;
            button4.Tag = "\"Move Down\"";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            button4.MouseHover += button4_MouseHover;
            // 
            // button5
            // 
            button5.Location = new Point(795, 301);
            button5.Name = "button5";
            button5.Size = new Size(96, 53);
            button5.TabIndex = 4;
            button5.Text = "Compile!";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(504, 301);
            button6.Name = "button6";
            button6.Size = new Size(113, 54);
            button6.TabIndex = 1;
            button6.Text = "Config OneBus";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button7
            // 
            button7.Location = new Point(623, 301);
            button7.Name = "button7";
            button7.Size = new Size(166, 53);
            button7.TabIndex = 1;
            button7.Text = "Set Start CHR and PRG";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(116, 8);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(384, 25);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 11);
            label1.Name = "label1";
            label1.Size = new Size(107, 21);
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
            // button9
            // 
            button9.Location = new Point(700, 8);
            button9.Name = "button9";
            button9.Size = new Size(89, 23);
            button9.TabIndex = 8;
            button9.Text = "Load CSV";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click;
            // 
            // button10
            // 
            button10.Location = new Point(795, 8);
            button10.Name = "button10";
            button10.Size = new Size(96, 23);
            button10.TabIndex = 9;
            button10.Text = "Save CSV";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(903, 366);
            Controls.Add(button10);
            Controls.Add(button9);
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
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            Text = "Menu Builder for Sup Game Box 400-in-1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
        private Button button7;
        private TextBox textBox1;
        private Label label1;
        private Button button8;
        private Button button9;
        private Button button10;
        public Button button1;
    }
}
