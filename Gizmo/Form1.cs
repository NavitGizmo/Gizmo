using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gizmo
{
    public partial class Form_Main : Form
    {
        public Form_Main()
        {
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            /* The program checks to see if the directory structure it expects exists, 
             * if it does not then it sets the flag back to true on FirstRun settings.
             * 
             * It then prompts the user if it is alright to make the directory structure
             * if yes it creates the structures it needs.
             */
            GizSetup setup = new GizSetup();
            if (setup.Validate_MainDir() == false)
            {
                Properties.Settings.Default.FirstRun = true;
                Properties.Settings.Default.Save();
            }
            bool first_Run = Properties.Settings.Default.FirstRun;
            if (first_Run == true)
            {
                if (MessageBox.Show(@"This is a first run, or the directory structure was removed. May we create a directory structure at C:\Gizmo\?", "Setup",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    setup.Create_Directory();
                    Properties.Settings.Default.FirstRun = false;
                    Properties.Settings.Default.Save();
                }
            }
        }
    }
}
