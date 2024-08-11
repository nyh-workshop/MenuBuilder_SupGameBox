using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuBuilder_SupGameBox
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public string getTitleText()
        {
            string t0 = textBox1.Text;
            t0 = t0.ToUpper();
            if (t0.Length > 16)
                t0 = t0.Substring(0, 16);
            return t0;
        }

        public void putIntoTextBox(string s)
        {
            textBox1.Text = s;
        }

        private void Form2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
