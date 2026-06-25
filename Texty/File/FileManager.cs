using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texty.File
{
    internal static class FileManager
    {
        public static async Task<string> Read(string path)
        {
            string text;
            using (StreamReader sr = new StreamReader(path))
            {
                text = await sr.ReadToEndAsync();
            }
            return text;
        }

        public static void Write(string path, string text)
        {
            System.IO.File.WriteAllText(path, text);
        }
    }
}
