using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerCreation.Engine
{
    public class DataLoader
    {
        private static DataLoader _instanse;

        private DataLoader() { }

        public static DataLoader GetInstanse()
        {
            if (_instanse == null)
                _instanse = new DataLoader();

            return _instanse;
        }

        public void LoadData()
        {

        }
    }
}
