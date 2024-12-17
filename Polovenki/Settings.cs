using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
using static Utilities.Classes.ChangeParameters;
using static Utilities.Classes.SQLHelper;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography;

namespace Utilities.Classes
{
    public static class Settings
    {
       static object Form;

        public static void exitFromProfile() {
            SetParamValue("_unauthorizedUser", "true");
            SetParamValue("_loginUserID", "0");
            SQLHelper.SetNameDB("girlsDataBase.db");
            string SQLQuery = $"UPDATE \"girlsData\" SET \"Reaction\" = @reaction;";
            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                    { "@reaction", "n/a" },
            };
            ExecuteUpdateWithParameters(SQLQuery, parameters);
            SQLHelper.CloseConnection();
            Application.Restart();
        }
    }
}
