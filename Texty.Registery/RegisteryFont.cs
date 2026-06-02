using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texty.Registery
{
    public static class RegisteryFont
    {
        public static bool IsExisted
        {
            get
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegisteryAddress.Font, false))
                {
                   if (key != null) return true;
                }
                return false;
            }
        }

        public static void Write()
        {
            Write(RegisteryDefaultValues.Font);
        }

        public static void Write(Font font)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegisteryAddress.Font))
            {
                key.SetValue("Name", font.Name, RegistryValueKind.String);
                key.SetValue("Size", font.Size, RegistryValueKind.DWord);
                key.SetValue("Style", (int)font.Style, RegistryValueKind.DWord);
            }
        }

        public static Font Read()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegisteryAddress.Font, false))
            {
                if (key != null)
                {
                    string fontName = key.GetValue("Name").ToString();
                    int fontSize = (int)key.GetValue("Size");
                    FontStyle fontStyle = (FontStyle)key.GetValue("Style");

                    Font font = new Font(fontName, fontSize, fontStyle);
                    return font;
                }
            }
            return RegisteryDefaultValues.Font;
        }
    }
}
