using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Classes.ChangeParameters;

namespace Polovenki
{
    public partial class login__signin_Form : Form
    {
        Form parentConrtol;

        public login__signin_Form(Form parent)
        {
            InitializeComponent();
            parentConrtol = parent;
            this.DoubleBuffered = true;
            
        }
        loginForm loginForm;
        signinForm signinForm;

        bool isLoginForm = false;
        bool wrongPass = false;

        public delegate void loginsigninResultEventHandler(object sender, loginsigninResult e);
        public event loginsigninResultEventHandler loginsigninResult;

        private void btn_login__mainForm_Click(object sender, EventArgs e)
        {
            loginForm = new loginForm(parentConrtol, wrongPass);
            loginForm.locationChange();
            loginForm.LoginResult += LoginForm_LoginResult;
            loginForm.ShowDialog();
            isLoginForm = true;
        }

        private void btn_signin__mainForm_Click(object sender, EventArgs e)
        {
            signinForm = new signinForm(parentConrtol);
            signinForm.locationChange();
            signinForm.SigninResult += SigninForm_SigninResult;
            signinForm.ShowDialog();
            isLoginForm = false;
        }

        private void SigninForm_SigninResult(object sender, SigninResultEventArgs e) {
            bool signinSuccess = e.SigninSuccess;
            if (signinSuccess)
            {
                loginsigninResult?.Invoke(this, new loginsigninResult(true, false));
                SetParamValue("_unauthorizedUser", "false");
                SetParamValue("_firstOpen", "false");
                SetParamValue("_rememberUser", "true");
            }
            else
            {
            }
        }

        private void LoginForm_LoginResult(object sender, LoginResultEventArgs e)
        {
            bool loginSuccess = e.LoginSuccess;
            if (loginSuccess)
            {
                wrongPass = false;
                loginsigninResult?.Invoke(this, new loginsigninResult(true, true));
                SetParamValue("_unauthorizedUser", "false");
                SetParamValue("_firstOpen", "false");
                SetParamValue("_rememberUser", "true");
            }
            else
            {
                wrongPass = true;
                btn_login__mainForm_Click(this, EventArgs.Empty);
            }
        }
    }
}
