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
            Match match = Regex.Match(s0, "0x[0-9a-fA-F]{1,}");
            if (!match.Success)
                return "0x00000000";
            else
                return s0;
        }

        public string getStartPRGaddr()
        {
            string s0 = textBox2.Text;
            Match match = Regex.Match(s0, "0x[0-9a-fA-F]{1,}");
            if (!match.Success)
                return "0x00000000";
            else
                return s0;
        }
    }
}
