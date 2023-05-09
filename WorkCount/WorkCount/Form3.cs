using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCount
{
    public partial class Form3 : Form
    {
        public static int WorkedTime = 0;   // seconds

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            KeyboardAndMouse.Subscribe();
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
            //minimize the form
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form3_Shown(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("ticked");
            Process[] pname2 = Process.GetProcesses();
          //  for (int i = 0; i < pname2.Length; i++) Console.WriteLine(pname2[i]); // write the processes names in the console
            Process[] pname = Process.GetProcessesByName(MonitoringData.ProgramTrigger);

            if (pname.Length == 0)
            {
                label5.ForeColor = Color.Red;
                label5.Text = "NOT RECORDING";
            }
            else
            {
                label5.ForeColor = Color.Green;
                label5.Text = "RECORDING";
                WorkedTime = WorkedTime + (timer1.Interval / 1000);
                Console.WriteLine(WorkedTime);
            }
            Console.WriteLine("The las key press time :" + KeyboardAndMouse.Time);
            Console.WriteLine(DateTime.Now.Minute - KeyboardAndMouse.Time);
            if (DateTime.Now.Minute - KeyboardAndMouse.Time >= 1) // daca nici o tasta nu a mai fost apasata de 10 minute se trece pe modul afk 
            {
                label5.ForeColor = Color.Yellow;
                label5.Text = "AFK";
            }

            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //close 
            Console.WriteLine("Writing to files ... ");
            if (File.Exists(FileLocations.UserWorkedTimeFile + UserData.Username + $@"\WorkedTime\{DateTime.Now.Year}\{DateTime.Now.Month}\" + $@"{DateTime.Now.Day}.txt") == false)
            {
                Console.WriteLine("The file does not exist, creating a new one now ");
                Directory.CreateDirectory(FileLocations.UserWorkedTimeFile + UserData.Username + $@"\WorkedTime\{DateTime.Now.Year}\{DateTime.Now.Month}\");
                StreamWriter sw = new StreamWriter(FileLocations.UserWorkedTimeFile + UserData.Username + $@"\WorkedTime\{DateTime.Now.Year}\{DateTime.Now.Month}\"  +  $@"{DateTime.Now.Day }.txt");
                sw.WriteLine(WorkedTime);
                sw.Close();
            }
            else
            {
                StreamReader sr = new StreamReader(FileLocations.UserWorkedTimeFile + UserData.Username + $@"\WorkedTime\{DateTime.Now.Year}\{DateTime.Now.Month}\"  + $@"{DateTime.Now.Day}.txt");
                WorkedTime = WorkedTime + Convert.ToInt32(sr.ReadLine());
                sr.Close();

                StreamWriter sw = new StreamWriter(FileLocations.UserWorkedTimeFile + UserData.Username + $@"\WorkedTime\{DateTime.Now.Year}\{DateTime.Now.Month}\" + $@"{DateTime.Now.Day }.txt");
                sw.WriteLine(WorkedTime);
                sw.Close();
            }
         
          
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            // ? 
            Form f7 = new Form7();
            f7.Show();
        }
    }
}
