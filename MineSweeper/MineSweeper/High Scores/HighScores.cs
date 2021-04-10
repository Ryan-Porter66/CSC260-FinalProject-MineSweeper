using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace MineSweeper.High_Scores
{
    class HighScores
    {
        #region Methods
        static string GetPath()
        {
            //https://stackoverflow.com/questions/13762338/read-files-from-a-folder-present-in-project
            //https://stackoverflow.com/questions/5606747/how-to-get-application-path
            //gets the path of where the high score file should be, and calls a function to make sure file exists
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            return CheckIfFileExists(Path.Combine(projectDirectory, @"High Scores\HighScoresData.txt"));
        }
        private static string CheckIfFileExists(string filePath)
        {
            //https://stackoverflow.com/questions/2781357/file-being-used-by-another-process-after-using-file-create
            //create file if it does not exist
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
                try
                {
                    output = output + data[0 + index * 3].PadRight(15, pad) + "\t" + data[1 + index * 3].PadRight(30, pad) + "\t" + data[2 + index * 3].PadRight(5, pad) + "\n";
                }
                catch
                {
                    //incase something was wrong in the original text file, replace all text and get new values
                    string fileData = "Easy\nN/A\n999\nIntermediate\nN/A\n999\nExpert\nN/A\n999";
                    File.WriteAllText(GetPath(), fileData);
                    data = File.ReadAllLines(GetPath());
                    output = output + data[0 + index * 3].PadRight(15, pad) + "\t" + data[1 + index * 3].PadRight(30, pad) + "\t" + data[2 + index * 3].PadRight(5, pad) + "\n";
                }
            }
            MessageBox.Show(output);
        }
        public static void CheckForNewHS(string difficulty, int time)
        {
            string[] data = File.ReadAllLines(GetPath());
            string timeString;
            int index;
            try
            {
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
                else if (difficulty.Equals("Expert"))
                {
                    timeString = data[8];
                    index = 8;
                }
                else
                {
                    return;
                }
                if (Int32.Parse(timeString) > time)
                {
                    UpdateTime(time, data, index);
                }
            }
            catch
            {
                MessageBox.Show("Something went wrong when checking the scores. Your score will not be updated to file.");
                string fileData = "Easy\nN/A\n999\nIntermediate\nN/A\n999\nExpert\nN/A\n999";
                File.WriteAllText(GetPath(), fileData);
            }
        }
        private static void UpdateTime(int time, string[] data, int index)
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
