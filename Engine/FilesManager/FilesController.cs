using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public static class FilesController
    {
        public static void MoveFileTo(string filePathFROM, string filePathTO)
        {
            if (File.Exists(filePathFROM))
            {
                File.Move(filePathFROM, filePathTO, true);
            }
        }

        public static void CreateServerFloder(string directoryPathName)
        {
            Directory.CreateDirectory(directoryPathName);
        }
    }
}
