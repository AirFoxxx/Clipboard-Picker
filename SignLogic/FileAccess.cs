using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProtoBuf;

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
                        var stream = new MemoryStream(bytes);

                        var bc = Serializer.DeserializeWithLengthPrefix<ButtonCollection>(stream, PrefixStyle.Fixed32);

                        if (bc.bList == null)
                        {
                            // This happens when no file exists;
                            return;
                        }

                        foreach (var button in bc.bList)
                        {
                            var b = new FullButton();
                            b.Id = button.id;
                            b.Sign = button.sign;
                            b.Description = button.desc;
                            FileAccess.Entries.Add(b);
                        }

                        stream.Close();
                        stream.Dispose();
                    }
                    else // Write operation
                    {
                        var bc = new ButtonCollection();
                        bc.bList = new List<EasyButton>();
                        int indexFix = 1;

                        foreach (var button in FileAccess.Entries)
                        {
                            var b = new EasyButton();
                            b.id = indexFix++;
                            b.sign = button.Sign;
                            b.desc = button.Description;
                            bc.bList.Add(b);
                        }

                        var stream = new MemoryStream();
                        Serializer.SerializeWithLengthPrefix<ButtonCollection>(stream, bc, PrefixStyle.Fixed32);
                        byte[] output = stream.ToArray();
                        reader.WriteArray<byte>(0, output, 0, output.Length);
                        stream.Close();
                        stream.Dispose();
                    }
                }
            }
        }

        [ProtoContract]
        public partial class EasyButton
        {
            [ProtoMember(1)]
            public int id;

            [ProtoMember(2)]
            public string sign;

            [ProtoMember(3)]
            public string desc;
        }

        [ProtoContract]
        public partial class ButtonCollection
        {
            [ProtoMember(1)]
            public List<EasyButton> bList;
        }
    }
}
