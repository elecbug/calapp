using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calapp
{
    internal class App
    {
        private static App? _instance;

        public static App Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new App();
                }

                return _instance;
            }
        }

        private App()
        {

        }
    }
}
