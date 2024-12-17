using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polovenki
{
    public class SigninResultEventArgs : EventArgs
    {
        public bool SigninSuccess { get; private set; }

        public SigninResultEventArgs(bool signinSuccess)
        {
            SigninSuccess = signinSuccess;
        }
    }
}
