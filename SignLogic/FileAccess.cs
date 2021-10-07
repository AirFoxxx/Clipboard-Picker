using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLogic
{
    public static class FileAccess
    {
        public static List<FullButton> Entries = new List<FullButton>();

        public static string FullFilePath { get; private set; }

        public static string WriteFile()
        {
            // entry looks like this: id,sign,description[endline]
            var str = String.Empty;
            foreach (var button in FileAccess.Entries)
            {
                str = str + $"{button.Id}\r{button.Sign}\r{button.Description}\n";
            }
            return str;
        }

        public static void MakeButton(string buttonSign, string buttonDesc)
        {
            var button = new FullButton(buttonSign, buttonDesc);
            FileAccess.Entries.Add(button);
        }

        public static void AccessFile(string fileName, bool forRead)
        {
            // i.e. \bin\Debug - where the binary is loaded from
            string workingDirectory = Environment.CurrentDirectory;
            FileAccess.FullFilePath = $"{ workingDirectory }\\{fileName}";

            string str = string.Empty;
            using (MemoryMappedFile Mmf = MemoryMappedFile.CreateFromFile(FullFilePath, FileMode.OpenOrCreate, "myFileMap", 10000))
            {
                using (MemoryMappedViewAccessor reader = Mmf.CreateViewAccessor())
                {
                    if (forRead) // Read operation
                    {
                        var bytes = new byte[reader.Capacity];
                        reader.ReadArray<byte>(0, bytes, 0, bytes.Length);
                        str = System.Text.Encoding.UTF8.GetString(bytes, 0, bytes.Length);
                        str = str.Trim('\0');
                        // System.Diagnostics.Debug.Write(str);

                        if (str.Length == 0)
                            return;

                        FileAccess.ReadFile(str);
                    }
                    else // Write operation
                    {
                        str = FileAccess.WriteFile();

                        if (str.Length == 0)
                            return;

                        byte[] buffer = System.Text.Encoding.UTF8.GetBytes(str);
                        reader.WriteArray<byte>(0, buffer, 0, buffer.Length);
                    }
                }
            }
        }

        private static void ReadFile(string str)
        {
            // entry looks like this: id,sign,description[endline]
            var buttonsList = str.Split(new char[] { '\n' }).ToList();

            foreach (var button in buttonsList)
            {
                if (button == string.Empty)
                    continue;

                var buttonStrings = button.Split('\r').ToList();

                if (buttonStrings.Count() != 3)
                    throw new Exception("Error in the saving file!");

                var newButton = new FullButton();
                newButton.Id = int.Parse(buttonStrings[0]);
                newButton.Sign = buttonStrings[1];
                newButton.Description = buttonStrings[2];

                FileAccess.Entries.Add(newButton);
                FullButton.IdCounter = ++newButton.Id;
            }
        }
    }
}
