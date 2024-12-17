using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polovenki
{
    public class LoginResultEventArgs : EventArgs
    {
        public bool LoginSuccess { get; private set; }

        public LoginResultEventArgs(bool loginSuccess)
        {
            LoginSuccess = loginSuccess;
        }
    }
}
