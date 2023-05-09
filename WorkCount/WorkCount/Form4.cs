using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkCount
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // admin controls form
            pictureBox1.Image = Properties.Resources.settings;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            KeyboardAndMouse.Subscribe();
            hide_All();
        }

        private void hide_All()
        {
            button3.Hide();
            label2.Hide();
            label3.Hide();
            label5.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            label6.Hide();
            linkLabel1.Hide();
            label7.Hide();
            label8.Hide();
            textBox5.Hide();
            textBox4.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // settings clicked 
            if (label3.Visible == true)
            {
                hide_All();
                button1.Show();
            }
            else
            {
                button3.Show();
                label7.Show();
                label8.Show();
                textBox5.Show();
                textBox4.Show();
                button1.Show();
                label2.Show();
                label3.Show();
                label5.Show();
                textBox1.Show();
                textBox2.Show();
                textBox3.Show();
                label6.Show();
                linkLabel1.Show();
                textBox5.Text = MonitoringData.ProgramTrigger;
            }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.settings2;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Properties.Resources.settings;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //link to the video ; how to set this up
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Save settings");
            // save settings 
            if (Directory.Exists(@"C:\Users\" + UserData.Username + @"\Desktop\WorkCount\ProgramData"))
            {
                Console.WriteLine("IN if");
                StreamWriter sw = new StreamWriter(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData\Timeout.txt");
                sw.WriteLine(textBox4.Text);
                sw.Close();

                StreamWriter sw2 = new StreamWriter(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData\Trigger.txt");
                sw2.WriteLine(textBox5.Text);
                sw2.Close();
            }
            else
            {
                Console.WriteLine("IN ELSE");
                Directory.CreateDirectory(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData");
                StreamWriter sw = new StreamWriter(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData\Timeout.txt");
                sw.WriteLine(textBox4.Text);
                sw.Close();

                StreamWriter sw2 = new StreamWriter(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData\Trigger.txt");
                sw2.WriteLine(textBox5.Text);
                sw2.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // pick valid trigger
            Form f5 = new Form5();
            f5.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // create table 
            Form  f6 = new  Form6();
            f6.Show();
            this.Hide();
        }
    }
}
