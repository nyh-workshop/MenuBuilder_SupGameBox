namespace MenuBuilder_SupGameBox
{
    partial class Form4
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(136, 12);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(88, 25);
            textBox1.TabIndex = 0;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(118, 17);
            label1.TabIndex = 1;
            label1.Text = "Start CHR address:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(117, 17);
            label2.TabIndex = 1;
            label2.Text = "Start PRG address:";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(136, 48);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(88, 25);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(232, 12);
            button1.Name = "button1";
            button1.Size = new Size(50, 61);
            button1.TabIndex = 2;
            button1.Text = "OK";
            button1.UseVisualStyleBackColor = true;
            // 
            // Form4
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(293, 81);
            ControlBox = false;
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form4";
            ShowIcon = false;
            Text = "Set Start CHR and PRG (in Hex)";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button button1;
    }
}