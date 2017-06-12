using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace ProcessNote
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Process[] procs;
        private void GetProcesses()
        {
            procs = Process.GetProcesses();
            if(Convert.ToInt32(label2.Text) != procs.Length)
            {
                Processes.Items.Clear();
                for(int i = 0; i < procs.Length;i++)
                {
                    Processes.Items.Add(procs[i].Id + "\t" +procs[i].ProcessName);
                }
                label1.Text = procs.Length.ToString();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            GetProcesses();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetProcesses();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            procs[Processes.SelectedIndex].Kill();
        }

        private void killProcessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            procs[Processes.SelectedIndex].Kill();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string text   = startTextBox.Text;
            Process process = new Process();
            process.StartInfo.FileName = text;
            process.Start();
        }

        private void Processes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Process currentProc = procs[Processes.SelectedIndex];
            long memoryUsed = currentProc.PrivateMemorySize64;
            MemLabel2.Text = memoryUsed + " ";

        }
    }
}
