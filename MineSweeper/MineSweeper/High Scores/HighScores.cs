using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;

namespace MineSweeper.High_Scores
{
    class HighScores
    {
        #region Methods
        static string GetPath()
        {
            //https://stackoverflow.com/questions/13762338/read-files-from-a-folder-present-in-project
            //https://stackoverflow.com/questions/5606747/how-to-get-application-path
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            return CheckIfFileExists(Path.Combine(projectDirectory, @"High Scores\HighScoresData.txt"));
        }
        private static string CheckIfFileExists(string filePath)
        {
            //https://stackoverflow.com/questions/2781357/file-being-used-by-another-process-after-using-file-create
            if (!(File.Exists(filePath)))
            {
                File.Create(filePath).Close();
                string fileData = "Easy\nN/A\n999\nIntermediate\nN/A\n999\nExpert\nN/A\n999";
                File.WriteAllText(filePath, fileData);
            }
            return filePath;
        }
        public static void DisplayHighScores()
        {
            string[] data = File.ReadAllLines(GetPath());
            //https://docs.microsoft.com/en-us/dotnet/api/system.string.padright?view=net-5.0
            string output = "";
            char pad = ' ';
            for (int index = 0; index < 3; index++)
            {
                output = output + data[0 + index * 3].PadRight(15, pad) + "\t" + data[1 + index * 3].PadRight(22, pad) + "\t" + data[2 + index * 3].PadRight(5, pad) + "\n";
            }
            MessageBox.Show(output);
        }
        public static void CheckForNewHS(string difficulty, int time)
        {
            string[] data = File.ReadAllLines(GetPath());
            string timeString;
            int index;
            if (difficulty.Equals("Easy"))
            {
                timeString = data[2];
                index = 2;
            }
            else if (difficulty.Equals("Intermediate"))
            {
                timeString = data[5];
                index = 5;
            }
            else
            {
                timeString = data[8];
                index = 8;
            }
            if (Int32.Parse(timeString) > time)
            {
                UpdateTime(difficulty, time, data, index);
            }

        }
        private static void UpdateTime(string difficulty, int time, string[] data, int index)
        {
            string name = GetNameDialogBox();
            data[index - 1] = name;
            data[index] = time.ToString();
            File.WriteAllLines(GetPath(), data);
        }
        private static string GetNameDialogBox()
        {
            //https://stackoverflow.com/questions/5427020/prompt-dialog-in-windows-forms
            Form name = new Form();
            name.Text = "New High Score";
            name.Size = new Size(250, 150);
            Label newHS = new Label();
            newHS.Text = "Congrats! You beat the old high score.\nPlease enter your name.";
            newHS.Location = new Point(10, 10);
            newHS.Size = new Size(188, 26);
            TextBox input = new TextBox();
            input.MaxLength = 19;
            input.Size = new Size(130, 13);
            input.Location = new Point(12, 40);
            Button confirmation = new Button();
            confirmation.Text = "OK";
            confirmation.Location = new Point(10, 70);
            confirmation.Click += (sender, e) => { name.Close(); };
            confirmation.DialogResult = DialogResult.OK;
            name.Controls.Add(newHS);
            name.Controls.Add(input);
            name.Controls.Add(confirmation);
            name.AcceptButton = confirmation;

            if (name.ShowDialog() == DialogResult.OK)
            {
                return input.Text;
            }
            else
            {
                return "Unknown";
            }
        }
        #endregion
    }
}
