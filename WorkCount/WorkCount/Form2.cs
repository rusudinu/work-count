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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            LogfileOperations.WriteLogfile("Form2 state = shown(confirmed)");
            label7.Hide();
            label8.Hide();
            label6.Hide();
            textBox5.Hide();
            linkLabel1.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserData.Username = textBox1.Text;
            UserData.Password = textBox2.Text;
            if (UserData.Password == textBox3.Text && UserData.Username != "" && UserData.Password != "")
            {
                if (Directory.Exists(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\" + textBox1.Text + @"\LoginData") == true)
                {
                    MessageBox.Show("An account with this username already exists !");
                }
                else
                {
                    if (checkBox1.Checked == true)
                    {
                        
                       // NewUser.UserAdminKey = Encrypt.Encrypter(textBox5.Text);
                        if (textBox5.Text == "admin")//NewUser.AdminKey == NewUser.UserAdminKey)
                        {
                            Console.WriteLine("TRUE ADMIN IF");
                            label1.Text = "Your account (with admin permissions) is created now, please be patient !";
                            label1.Font = new Font("Century Gothic", 12);
                            Directory.CreateDirectory(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\" + textBox1.Text + @"\LoginData");
                            string path = @"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\" + textBox1.Text + @"\LoginData\";
                            StreamWriter WriteUserPassword = new StreamWriter(path + "Password.txt", true);
                            WriteUserPassword.WriteLine(Encrypt.Encrypter(UserData.Password));
                            StreamWriter WriteUserPermissions = new StreamWriter(path + "AdminPermissions.txt", true);
                            WriteUserPermissions.WriteLine("true");
                            WriteUserPassword.Close();
                            WriteUserPermissions.Close();
                        }
                    }
                    else
                    {
                        label1.Text = "Your account (without admin permissions) is created now, please be patient !";
                        label1.Font = new Font("Century Gothic", 12);
                        Directory.CreateDirectory(@"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\" + textBox1.Text + @"\LoginData");
                        string path = @"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\" + textBox1.Text + @"\LoginData\";
                        StreamWriter WriteUserPassword = new StreamWriter(path + "Password.txt", true);
                        WriteUserPassword.WriteLine(Encrypt.Encrypter(UserData.Password));
                        StreamWriter WriteUserPermissions = new StreamWriter(path + "AdminPermissions.txt", true);
                        WriteUserPermissions.WriteLine("false");
                        WriteUserPassword.Close();
                        WriteUserPermissions.Close();
                    }
                }
            }

            Form f1 = new Form1();
            f1.Show();
            this.Hide();
        }

        private void checkBox1_MouseHover(object sender, EventArgs e)
        {
            label7.Show();
        }

        private void checkBox1_MouseLeave(object sender, EventArgs e)
        {
            label7.Hide();
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label8.Show();
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label8.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                label6.Show();
                textBox5.Show();
            }
            else
            {
                label6.Hide();
                textBox5.Hide();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) linkLabel1.Show();
            else linkLabel1.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("Enter the key you got when this program was installed ! If you don't have that, email the dev at : dinustefan89.ds@gmail.com or fill a request in the custommer support section");
        }
    }
}
