using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignLogic
{
    /// <summary>
    /// This class takes care of asynchronous access to the save file with all previously created buttons.
    /// It takes care of opening, reading and writing to the file and also carries the list with all Buttons in memory.
    /// </summary>
    public static class FileAccess
    {
        /// <summary>
        /// List of button entries.
        /// </summary>
        public static List<FullButton> Entries = new List<FullButton>();

        /// <summary>
        /// Gets the full file path.
        /// </summary>
        /// <value>
        /// The full file path.
        /// </value>
        public static string FullFilePath { get; private set; }

        /// <summary>
        /// Writes the file.
        /// </summary>
        /// <returns>String to write.</returns>
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

        /// <summary>
        /// Adds the button to the internal Button list.
        /// </summary>
        /// <param name="buttonSign">The button sign.</param>
        /// <param name="buttonDesc">The button desc.</param>
        public static void MakeButton(string buttonSign, string buttonDesc)
        {
            var button = new FullButton(buttonSign, buttonDesc);
            FileAccess.Entries.Add(button);
        }

        /// <summary>
        /// Accesses the file and either reads all buttons saved or writes all buttons currently in the system to the file.
        /// This usually happens at the start and end of the application cycle.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="forRead">if set to <c>true</c> [for read], if <c>false</c> then for [write].</param>
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

        /// <summary>
        /// Reads the file contents.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <exception cref="System.Exception">Error in the saving file!</exception>
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
