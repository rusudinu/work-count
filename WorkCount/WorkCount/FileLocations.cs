using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCount
{
    class FileLocations
    {
        public static string UserLoginFiles = @"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\";
        public static string UserWorkedTimeFile = @"C:\Users\" + EnvironmentData.PCUsername + @"\Desktop\WorkCount\Users\";
    }
}
