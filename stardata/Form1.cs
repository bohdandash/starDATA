using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace stardata
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            Commentary.Text += ("1). Format for a new star: 'hours(RA) minutes(RA) seconds(RA) degrees minutes(DEC) seconds(DEC) distance(pc)':");
            // Bind Click event to button "button1"

        }

        private void buttonWrite_Click(object sender, EventArgs e)
        {
            // Get data from user
            string line = EnterInf.Text;

            // Split the string into separate values
            string[] values = line.Split(' ');

            if (values.Length < 7)
            {
                MessageBox.Show("Need More Digits");
                return;
            }

            // Convert values into required data types
            int hoursRA = int.Parse(values[0]);
            int minutesRA = int.Parse(values[1]);
            double secondsRA = double.Parse(values[2]);

            int degreesDEC = int.Parse(values[3]);
            int minutesDEC = int.Parse(values[4]);
            double secondsDEC = double.Parse(values[5]);

            double distance = double.Parse(values[6]);

            // Create a new string in CSV format
            string output = hoursRA + " " + minutesRA + " " + secondsRA + " " + degreesDEC + " " + minutesDEC + " " + secondsDEC + " " + distance;

            // Open dialog box to select file save location
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Write the string to the selected file
                using (StreamWriter file = new StreamWriter(saveFileDialog.FileName, true))
                {
                    file.WriteLine(output);
                }

                // Output the result to a text field
                Commentary.Text += "\r2). Data Saved '" + saveFileDialog.FileName + "':\r\n" + output;
            }
        }

        private void buttonRead_Click(object sender, EventArgs e)
        {
            // Create a dialog box to select a file
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            openFileDialog.Title = "Directory:";

            // Open dialog box to select a file
            DialogResult result = openFileDialog.ShowDialog();



            // If a file is selected, read its contents
            if (result == DialogResult.OK)
            {
                // Get the path to the selected file
                string filePath = openFileDialog.FileName;

                // Initialize lists for X, Y, Z, Radius, Name
                List<double> xValues = new List<double>();
                List<double> yValues = new List<double>();
                List<double> zValues = new List<double>();
                List<double> RadiusValues = new List<double>();
                List<string> NameValues = new List<string>();

                // Read the contents of the file
                using (StreamReader file = new StreamReader(filePath))
                {
                    string line;
                    string output = "";
                    string ABCoutput = "";
                    string ABCshowLetters = "";
                    string XYZoutput = "";
                    string XYZshowLetters = "";

                    string text = "Hr(RA) Min(RA) Sec(RA)  Deg(DEC) Hr(DEC) Sec(DEC)  Dst(PC) Rad  Nm";
                   

                    while ((line = file.ReadLine()) != null)
                    {
                        // Split the string into separate values
                        string[] values = line.Split(' ');

                        // Convert values into required data types

                        int hoursRA = Math.Max(0, Math.Min(23, int.Parse(values[0])));
                        int minutesRA = Math.Max(0, Math.Min(59, int.Parse(values[1])));
                        double secondsRA = Math.Max(0, Math.Min(59.9999, double.Parse(values[2])));

                        int degreesDEC = Math.Max(-360, Math.Min(360, int.Parse(values[3])));
                        int minutesDEC = Math.Max(0, Math.Min(59, int.Parse(values[4])));
                        double secondsDEC = Math.Max(0, Math.Min(59.9999, double.Parse(values[5])));

                        double distance = Math.Max(0, Math.Min(40, double.Parse(values[6])));

                        double Radius = 0;
                        double.TryParse(values[7], out Radius);
                        Radius = Math.Max(0, Math.Min(30, Radius));

                        string Name = values[8];

                        double A = Math.Round((hoursRA * 15) + (minutesRA * 0.25) + (secondsRA * 0.004166), 3);
                        double B = Math.Round(Math.Abs(degreesDEC + (minutesDEC / 60) + (secondsDEC / 3600)) * Math.Sign(degreesDEC), 3);

                        double X = (distance * Math.Cos(B)) * Math.Cos(A);
                        double Y = (distance * Math.Cos(B)) * Math.Sin(A);
                        double Z = distance * Math.Sin(B);

                        // Add X, Y, Z values to lists
                        xValues.Add(X);
                        yValues.Add(Y);
                        zValues.Add(Z);
                        RadiusValues.Add(Radius);
                        NameValues.Add(Name);


                        // Format the output string into a table
                        string lineOutput = $"{hoursRA,-9} {minutesRA,-12} {secondsRA,-7:F4} {degreesDEC,-14} {minutesDEC,-12} {secondsDEC,-10} {distance,-2} {Radius,-2} {Name,-0}\r\n";
                        ABCshowLetters = $"{"A",-12} {"B",-12} {"C",0}";
                        ABCoutput += $"\r{A,-8} {B,-8} {distance,-0}";

                        XYZshowLetters = $"{"X",-32} {"Y",-32} {"Z",0}";
                        XYZoutput += $"\r{X,-8} {Y,-8} {Z,-0}";




                        // Add the string to the overall output
                        output += lineOutput;
                       
                    }

                    // Output the result to a text field
                    Commentary.Text += "\r2). File: '" + filePath + "':\r\n\n" + text + "\n" + output;
                    Commentary.Text += "\n3). A,B,C:"+ "\n" + ABCshowLetters + ABCoutput;
                    Commentary.Text += "\n\n4). X,Y,Z:" + "\n" + XYZshowLetters + XYZoutput;

                    

                }
                WriteToCsvFile(xValues, yValues, zValues, RadiusValues, NameValues);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Verufy the user wants to exit
            DialogResult result = MessageBox.Show("Are you sure you wish to quit?", "Exit App", MessageBoxButtons.YesNo);
            if (result == System.Windows.Forms.DialogResult.Yes) 
            {
                System.Windows.Forms.Application.Exit(); 
            }
        }

        private void WriteToCsvFile(List<double> xValues, List<double> yValues, List<double> zValues, List<double> RadiusValues, List<string> NameValues)
        {
            // Create a dialog box to select a file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.Title = "Directory:";
            saveFileDialog.FileName = "blenderXYZ.csv"; // Имя файла по умолчанию

            // Open dialog box to select a file
            DialogResult result = saveFileDialog.ShowDialog();

            // If a file is selected, write data to the file
            if (result == DialogResult.OK)
            {
                // Get the path to the selected file
                string filePath = saveFileDialog.FileName;

                // Create a dictionary to store already added values
                Dictionary<string, bool> uniqueValues = new Dictionary<string, bool>();

                // Write data to the file
                using (StreamWriter file = new StreamWriter(filePath))
                {
                    for (int i = 0; i < xValues.Count; i++)
                    {
                        // Format a string to write to the file
                        string lineOutput = $"{xValues[i]} {yValues[i]} {zValues[i]} {RadiusValues[i]} {NameValues[i]}";

                        // Check if the value has already been added to the file
                        if (!uniqueValues.ContainsKey(lineOutput))
                        {
                            // Add the value to the file
                            file.WriteLine(lineOutput);

                            // Add the value to the dictionary of already added values
                            uniqueValues.Add(lineOutput, true);
                        }
                    }
                }

                MessageBox.Show("Data Saved");
            }
        }



    }
}
