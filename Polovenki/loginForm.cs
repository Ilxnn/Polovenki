using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using static Utilities.Classes.RelativePath;
using static Utilities.Classes.SQLHelper;
using static Utilities.Classes.HashChepher;
using Utilities.Classes;

namespace Polovenki
{
    public partial class loginForm : KryptonForm
    {
        Form parent;

        bool _loginSuccess = false;

        public delegate void LoginResultEventHandler(object sender, LoginResultEventArgs e);
        public event LoginResultEventHandler LoginResult;

        public loginForm(Form parentForm, bool wrongPass)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            parent = parentForm;
            if (wrongPass)
            {
                WrongPass.Visible = true;
            }
        }

        // Спавн формы в нужной локации
        public void locationChange() {
            this.CenterToParent();
            int y = parent.Location.Y + 43;
            this.Top = y;
        }


        //Обработчик кнопки "Войти"
        private void btn_login__loginForm_Click(object sender, EventArgs e)
        {
            
            SetNameDB("1cef673ireh4.db");
            string SQLQuery = "SELECT CASE " +
                          "WHEN EXISTS (SELECT 1 FROM user_data WHERE \"mail/number\" = @mailNumber AND password = @password) THEN 1 " +
                          "ELSE 0 " +
                          "END";

            Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@mailNumber", login_input.Text},
                {"@password", PROTECT_PASSWORD(password_input.Text)}
            };


            _loginSuccess = ExecuteScalarQueryWithParameters(SQLQuery,parameters) == 1 ? true : false;

            SQLQuery = "SELECT \"id\" FROM user_data WHERE \"mail/number\" = @mailNumber";
            parameters = new Dictionary<string, object>
            {
                {"@mailNumber", login_input.Text},
            };
            dataBuffer.setUserID(ExecuteScalarQueryWithParameters(SQLQuery, parameters));
            Utilities.Classes.ChangeParameters.SetParamValue("_loginUserID", dataBuffer.getUserID().ToString());
            SQLHelper.CloseConnection();
            this.Close();
            
            
        }
        
        private void loginForm_Load(object sender, EventArgs e)
        {
            locationChange();
        }

        private void password_input_TextChanged(object sender, EventArgs e)
        {

        }

        private void loginForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void loginForm_Leave(object sender, EventArgs e)
        {
            
        }

        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoginResult?.Invoke(this, new LoginResultEventArgs(_loginSuccess));
        }
    }
}
