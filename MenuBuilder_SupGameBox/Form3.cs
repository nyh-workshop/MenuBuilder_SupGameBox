using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuBuilder_SupGameBox
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        public string getConfig16Text()
        {
            // Only accepts 16 hex values array. 
            // Returns 16 0x00 if input is wrong:
            string s0_default = "0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00";
            string s0 = textBox1.Text;

            // Regex pattern: ((0x[0-9a-fA-F]{2}), ){15}(0x[0-9a-fA-F]{2})
            Match match = Regex.Match(s0, "((0x[0-9a-fA-F]{2}), ){15}(0x[0-9a-fA-F]{2})");
            if (!match.Success)
                return s0_default;
            else
                return s0;
        }

        public void setTextBox(string s0)
        {
            textBox1.Text = s0;
        }

        private void Form3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
