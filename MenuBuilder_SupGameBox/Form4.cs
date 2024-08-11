using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace MenuBuilder_SupGameBox
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public string getStartCHRaddr()
        {
            string s0 = textBox1.Text;
            int value = 0;
            // Reference: https://stackoverflow.com/questions/4279892/convert-a-string-containing-a-hexadecimal-value-starting-with-0x-to-an-integer
            if (s0 != null && s0.StartsWith("0x") && int.TryParse(s0.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out value))
            {
                return "0x" + value.ToString("X6");
            }
            else
            {
                return "0x00000000";
            }
        }

        public string getStartPRGaddr()
        {
            string s0 = textBox2.Text;
            int value = 0;
            // Reference: https://stackoverflow.com/questions/4279892/convert-a-string-containing-a-hexadecimal-value-starting-with-0x-to-an-integer
            if (s0 != null && s0.StartsWith("0x") && int.TryParse(s0.Substring(2), System.Globalization.NumberStyles.AllowHexSpecifier, null, out value))
            {
                return "0x" + value.ToString("X6");
            }
            else
            {
                return "0x00000000";
            }
        }
        public void setTextBox(string s0, string s1)
        {
            textBox1.Text = s0;
            textBox2.Text = s1;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
