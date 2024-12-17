using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities.Classes;

namespace Utilities.Classes
{
    public static class dataBuffer
    {
        static int userID;
        static bool _2ndClick = false;

        public static void setUserID(int ID) { userID = ID;  }
        public static int getUserID() {
            if (userID == 0)
            {
                userID = int.Parse(ChangeParameters.ReadParam("_loginUserID").Trim('"'));
                return int.Parse(ChangeParameters.ReadParam("_loginUserID").Trim('"'));
            }
            else {
                Console.WriteLine($"FEF E FW {userID}");
                return userID;
            }
        }

        public static void setValue(bool value) { _2ndClick = value; }

        public static bool getValue() { return _2ndClick; }
    }
}
