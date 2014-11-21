using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gizmo
{
    class GizSetup
    {
        System.Collections.Specialized.StringCollection dirs = Properties.Settings.Default.Dirs;

        public void Create_Directory()
        {
            foreach (string dir in dirs)
            {
                bool valid_Dir = Directory.Exists(dir);
                if (valid_Dir == false)
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }

        public Boolean Validate_MainDir()
        {
            bool validation = Directory.Exists(dirs[0]);
            return validation;
        }
    }
}
