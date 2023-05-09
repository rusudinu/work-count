using OfficeOpenXml;
using System;
using System.IO;
using System.Windows.Forms;

namespace WorkCount
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // crete table 
            string tablePath = "";
            string username = textBox1.Text;
            int month = dateTimePicker1.Value.Month;
            int year = dateTimePicker1.Value.Year;
            if (username != null)
            {
               tablePath = $@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Output\{year}\{month}\{username}\Activity - {username} {month}.{year}.xlsx";
            }
            else  tablePath = $@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Output\{year}\{month}\AllUsers\Activity - AllUsers {month}.{year}.xlsx";

            FileInfo spreadSheetInfo = new FileInfo(tablePath);
            ExcelPackage pck = new ExcelPackage(spreadSheetInfo);
            if (File.Exists($@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Output\{year}\{month}\{username}\Activity - {username} {month}.{year}.xlsx") == true)
            {
                File.Delete($@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Output\{year}\{month}\{username}\Activity - {username} {month}.{year}.xlsx");
                button1_Click(sender, e);
                Environment.Exit(0);
            }
            var activitiesWorksheet = pck.Workbook.Worksheets.Add($"Activity - {username} { month}.{ year}");

            activitiesWorksheet.Cells["A2"].Value = "WorkCount";
            activitiesWorksheet.Cells["D4"].Value = username;
            activitiesWorksheet.Cells["E4"].Value = $" - {month}.{year}";
            activitiesWorksheet.Cells["B6"].Value = "Date(day)";
            activitiesWorksheet.Cells["C6"].Value = "WorkingTime(minutes)";

            
            int dateCount = 0;
            while (dateCount <= 30)
            {
                dateCount++;
                activitiesWorksheet.Cells[$"B{7 + dateCount}"].Value = dateCount;
                Console.WriteLine(dateCount);
                Console.WriteLine($@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Users\{username}\WorkedTime\{year}\{month}\{dateCount}.txt");
                if (File.Exists($@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Users\{username}\WorkedTime\{year}\{month}\{dateCount}.txt"))
                {
                    Console.WriteLine("EXISTS");
                    StreamReader sr = new StreamReader($@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Users\{username}\WorkedTime\{year}\{month}\{dateCount}.txt");
                    activitiesWorksheet.Cells[$"C{7 + dateCount}"].Value = (Convert.ToInt32(sr.ReadLine())) / 60;
                    sr.Close();
                }
                else
                {
                    Console.WriteLine("DOESN'T EXIST");
                    activitiesWorksheet.Cells[$"C{7 + dateCount}"].Value = "NO DATA";
                }

               

            }
            
            Directory.CreateDirectory($@"C:\Users\{Environment.UserName}\Desktop\WorkCount\Output\{year}\{month}\{username}\");
            pck.Save();
            System.Diagnostics.Process.Start(tablePath);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
