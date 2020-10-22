using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


/*
 * " The ultimate goal is to create a PowerPoint slide for the user"
 * " solution to give them suggestions of images to use from the internet, based on the contents of the information they are using for the slide."
 *  > result = more point (>= 9 image results)
 *  "preferred minimum is 9 suggestions or more. "
 */
namespace Windows_Form_Solution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
