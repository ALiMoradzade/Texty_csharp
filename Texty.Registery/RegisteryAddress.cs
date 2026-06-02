using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Texty.Registery
{
    public static class RegisteryAddress
    {
        public static string Font { get => $"Software\\{RegisteryDefaultValues.ApplicationName}\\Settings\\Text\\Font"; }
        public static string FormLocation { get => $"Software\\{RegisteryDefaultValues.ApplicationName}\\Settings\\Form\\Location"; }
        public static string FormSize { get => $"Software\\{RegisteryDefaultValues.ApplicationName}\\Settings\\Form\\Size"; }
        public static string FormWindowState { get => $"Software\\{RegisteryDefaultValues.ApplicationName}\\Settings\\Form\\WindowState"; }
    }
}
