using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polovenki
{
    public class loginsigninResult : EventArgs
    {
        public bool loginsignin { get; private set; }
        public bool isLoginForm{ get; private set; }

        public loginsigninResult(bool loginSuccess, bool isLogin)
        {
            loginsignin = loginSuccess;
            isLoginForm = isLogin;
        }
    }
}
