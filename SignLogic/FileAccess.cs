using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLogic
{
    public class FileAccess
    {
        public List<FullButton> Entries = new List<FullButton>();
        public string FullFilePath { get; private set; }

        public void ReadFile()
        {
            var fStream = File.Open(this.FullFilePath, FileMode.OpenOrCreate);

            if (!fStream.CanRead)
                throw new Exception($"File located at: {this.FullFilePath} failed to open");

            // entry looks like this: id,sign,description[endline]
            var buttonsList = fStream.ToString().Split(new char[] { '\r', '\n' }).ToList();
            foreach (var button in buttonsList)
            {
                var buttonStrings = button.Split(',').ToList();

                if (buttonStrings.Count() != 3)
                    throw new Exception("Error in the saving file!");

                var newButton = new FullButton();
                newButton.Id = int.Parse(buttonStrings[0]);
                newButton.Sign = buttonStrings[1];
                newButton.Description = buttonStrings[2];

                this.Entries.Add(newButton);
            }
        }

        public void SaveButtonToFile(FullButton button)
        {
            var fStream = File.Open(this.FullFilePath, FileMode.Open);

            if (!fStream.CanWrite)
                throw new Exception($"File located at: {this.FullFilePath} cannot be written to!");

            string stringToWrite = $"{button.Id},{button.Sign},{button.Description}\n";

            fStream.Write(Encoding.ASCII.GetBytes(stringToWrite), 0, stringToWrite.Length);
        }

        public void Initialize(string fileName)
        {
            // i.e. \bin\Debug - where the binary is loaded from
            string workingDirectory = Environment.CurrentDirectory;
            this.FullFilePath = $"{ workingDirectory }\\{fileName}";

            this.ReadFile();
        }
    }
}
