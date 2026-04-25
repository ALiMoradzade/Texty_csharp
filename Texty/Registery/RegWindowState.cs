using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texty.Registery
{
    internal class RegWindowState
    {
        private static string RegAddress = $"Software\\{Application.ProductName}\\Settings\\WindowState";
        private static FormWindowState defaultState = FormWindowState.Normal;

        public static bool IsExisted
        {
            get
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegAddress, false))
                {
                    if (key != null) return true;
                }
                return false;
            }
        }

        public static void Write()
        {
            Write(defaultState);
        }

        public static void Write(FormWindowState state)
        {
            using (RegistryKey key = Registry.CurrentUser.CreateSubKey(RegAddress))
            {
                key.SetValue("State", (int)state, RegistryValueKind.DWord);
            }
        }

        public static FormWindowState Read()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RegAddress, false))
            {
                if (key != null)
                {
                    FormWindowState state = (FormWindowState)key.GetValue("State");
                    return state;
                }
            }
            return defaultState;
        }
    }
}
