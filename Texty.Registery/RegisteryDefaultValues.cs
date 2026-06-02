using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Texty.Registery
{
    internal static class RegisteryDefaultValues
    {
        internal static string ApplicationName { get; } = Application.ProductName;
        internal static Font Font { get; } = new Font("Comic Sans MS", 12, FontStyle.Regular);
        internal static Point FormLocation { get; } = new Point(442, 163);
        internal static Size FormSize { get; } = new Size(716, 525);
        internal static FormWindowState FormWindowState { get; } = FormWindowState.Normal;
    }
}
