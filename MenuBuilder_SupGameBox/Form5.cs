using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MenuBuilder_SupGameBox
{
    public partial class Form5 : Form
    {
        // Reference: https://jeremylindsayni.wordpress.com/2016/03/08/2821/
        private BackgroundWorker worker = new BackgroundWorker();

        public Form5()
        {
            InitializeComponent();
            DoGenerateROM();
        }

        public void DoGenerateROM()
        {
            // register background worker events
            worker.DoWork += worker_DoWork;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;

            // start background worker in different thread to the GUI
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Reference: https://medium.com/@david.bollobas/calling-another-process-from-c-console-app-david-dev-blog-9ee9b482ab1b
            Process proc = new Process();
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.FileName = "make.exe";

            proc.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                // Reference: https://csharpforums.net/threads/appending-to-richtextbox-in-event-handler-getting-cross-thread-operation-not-valid-share-icon.4969/
                richTextBox1.Invoke(() => richTextBox1.AppendText(Environment.NewLine + Convert.ToString(e.Data)));
            });

            proc.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                // Reference: https://csharpforums.net/threads/appending-to-richtextbox-in-event-handler-getting-cross-thread-operation-not-valid-share-icon.4969/
                richTextBox1.Invoke(() => richTextBox1.AppendText(Environment.NewLine + Convert.ToString(e.Data)));
            });

            proc.Start();
            proc.BeginOutputReadLine();
            proc.BeginErrorReadLine();
            proc.WaitForExit();
        }
        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            richTextBox1.Invoke(() => richTextBox1.AppendText(Environment.NewLine + "ROM generated successfully!!"));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
