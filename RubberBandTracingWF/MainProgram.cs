using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubberBandTracingWF
{
    /// <summary>
    /// Main-Class.
    /// </summary>
    public static class MainProgram
    {
        /// <summary>
        /// The main entrance point for this program.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
