using System;
using System.IO;
using System.Windows.Forms;

namespace WorkCount
{
    public partial class Form1 : Form
    {
        #region starters
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
            LogfileOperations.WriteLogfile("Form1 state = hidden");
            LogfileOperations.WriteLogfile("Form2 state = shown(call)");
            this.Hide();
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //login button
          
            UserData.Username = textBox1.Text;
            UserData.Password = textBox2.Text;
            StreamReader passwordRead = new StreamReader(FileLocations.UserLoginFiles + UserData.Username + @"\LoginData\Password.txt");
            if (Encrypt.Encrypter(UserData.Password) == passwordRead.ReadLine())
            {
                StreamReader permissionsRead = new StreamReader(FileLocations.UserLoginFiles + UserData.Username + @"\LoginData\AdminPermissions.txt");
                UserData.AdminPermissions = Convert.ToBoolean(permissionsRead.ReadLine());

                StreamReader sr1 = new StreamReader(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData\Timeout.txt");
                MonitoringData.Timeout = Convert.ToInt32(sr1.ReadLine());
                sr1.Close();

                StreamReader sr2 = new StreamReader(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\ProgramData\Trigger.txt");
                MonitoringData.ProgramTrigger = sr2.ReadLine();
                sr2.Close();

                Console.WriteLine($"Logged in ; added trigger and timeout info : trigger : {MonitoringData.ProgramTrigger} and timeout  : {MonitoringData.Timeout}");

                if (UserData.AdminPermissions == false)
                {
                    Form f3 = new Form3();
                    f3.Show();
                    this.Hide();
                }
                else
                {
                    Form f4 = new Form4();
                    f4.Show();
                    this.Hide();
                }
            }
            else MessageBox.Show("Failed to log in !");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogfileOperations.WriteLogfile("Program launched - form 1 loaded");
           
        }
    }
}
