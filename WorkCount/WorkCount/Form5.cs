using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace WorkCount
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //detect button 

            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                if (theprocess.ProcessName.ToString() != "svchost")
                {
                    comboBox1.Items.Add(theprocess.ProcessName);
                    Console.WriteLine($"{theprocess.ProcessName}");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MonitoringData.ProgramTrigger = comboBox1.Text;
            Console.WriteLine(MonitoringData.ProgramTrigger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // back
            Form f4 = new Form4();
            f4.Show();
            this.Close();
        }
    }
}
