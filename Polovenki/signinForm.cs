using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Data.Entity.Infrastructure;
using System.Xml.Linq;
using static Utilities.Classes.RelativePath;
using static Utilities.Classes.HashChepher;
using Utilities.Classes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Imaging;
using System.IO;

namespace Polovenki
{
    public partial class signinForm : KryptonForm
    {

        Form parent;

        bool radiobuttonChecked;
        bool _signinSuccess = false;

        public delegate void SigninResultEventHandler(object sender, SigninResultEventArgs e);
        public event SigninResultEventHandler SigninResult;

        public signinForm(Form parentForm)
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            parent = parentForm;
        }

        // Спавн формы в нужной локации
        public void locationChange()
        {
            this.CenterToParent();
            int y = parent.Location.Y + 43;
            this.Top = y;
        }

        // Обработчик механизма регистрации
        // Выбор пола
        // Обработчик выбора пола (мужчина)

        bool isPressed = false;

        private void sex_radiobutton__man_Click(object sender, EventArgs e)
        {
            switch (radiobuttonChecked)
            {
                case true:
                    sex_radiobutton__woman.BackgroundImage = new Bitmap(GetFullPath(@"Source\img\sex_radiobtn_false1.png"));
                    sex_radiobutton__man.BackgroundImage = new Bitmap(GetFullPath(@"Source\img\sex_radiobtn_true.png"));
                    radiobuttonChecked = false;
                    break;
                case false:
                    sex_radiobutton__man.BackgroundImage = new Bitmap(GetFullPath(@"Source\img\sex_radiobtn_true.png"));
                    break;
            }
            isPressed = true;
        }

        // Обработчик выбора пола (женщина)
        private void sex_radiobutton__woman_Click(object sender, EventArgs e)
        {
            switch (radiobuttonChecked)
            {
                case true:
                    break;
                case false:
                    sex_radiobutton__man.BackgroundImage = new Bitmap(GetFullPath(@"Source\img\sex_radiobtn_false1.png"));
                    sex_radiobutton__woman.BackgroundImage = new Bitmap(GetFullPath(@"Source\img\sex_radiobtn_true.png"));
                    radiobuttonChecked = true;
                    break;
            }
            isPressed = true;
        }

        // Возврат полученного пола
        private string sex_indefication()
        {
            switch (radiobuttonChecked)
            {
                case true:
                    return "Женщина";
                case false:
                    return "Мужчина";
            }
            return "null";
        }

        // Генерация айди
        public static int GenerateUniqueId()
        {
            long timestamp = DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond;
            int uniqueId = (int)timestamp;

            if (uniqueId < 0) { uniqueId = -uniqueId; }

            return uniqueId;
        }

        //Обработчик нажатие на скрытие/раскрытие пароля

        static byte[] ImageToArrayByte(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                ((Bitmap)image).Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;
            }
        }
        //Обработчик кнопки "Зарегистрироваться"
        private void btn_signin__signinForm_Click(object sender, EventArgs e)
        {
            bool isFull = true;
            if (login_input.Text == string.Empty || password_input.Text == string.Empty || name_input.Text == string.Empty || borndate_input.Text == string.Empty || !isPressed) {
                WrongPass.Visible = true;
                isFull = false;
            }

            if (isFull)
            {
                int ID = GenerateUniqueId();

                dataBuffer.setUserID(ID);

                SQLHelper.SetNameDB("1cef673ireh4.db");
                string SQLQuery = "INSERT INTO user_data ('mail/number', 'password', 'id') VALUES (@mailNumber, @password, @id);";

                Dictionary<string, object> parameters = new Dictionary<string, object>
            {
                {"@mailNumber", login_input.Text},
                {"@password", PROTECT_PASSWORD(password_input.Text)},
                {"@id", ID}
            };

                SQLHelper.ExecuteQueryWithParameters(SQLQuery, parameters);
                SQLHelper.CloseConnection();

                SQLHelper.SetNameDB("usersData.db");
                SQLQuery = "INSERT INTO users_data ('name', 'borndate', 'sex', 'id','Image') VALUES (@name, @bornDate, @sex, @id, @Image);";
                parameters = new Dictionary<string, object>
            {
                {"@name", name_input.Text},
                {"@bornDate", borndate_input.Text},
                {"@sex", sex_indefication()},
                {"@id", ID},
                {"@Image", ImageToArrayByte(new Bitmap(Utilities.Classes.RelativePath.GetFullPath(@"Source\img\prof_sett_img_back.png")))}
            };
                SQLHelper.ExecuteQueryWithParameters(SQLQuery, parameters);
                Utilities.Classes.ChangeParameters.SetParamValue("_loginUserID", dataBuffer.getUserID().ToString());
                Utilities.Classes.ChangeParameters.SetParamValue("_loginUserSex", sex_indefication());
                
                SQLHelper.CloseConnection();

                _signinSuccess = true;
                SigninResult?.Invoke(this, new SigninResultEventArgs(_signinSuccess));
                this.Close();
            }
            else { 
                this.Refresh();
            }
            
        }

        private void signinForm_Load(object sender, EventArgs e)
        {
            locationChange();
        }

        private void borndate_input_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(borndate_input.Text)) return;

            int value;
            if (int.TryParse(borndate_input.Text, out value))
            {
                if (value < 1 || value > 99)
                {

                    borndate_input.Text = (value < 1) ? "1" : "99";
                }
                borndate_input.SelectionStart = borndate_input.Text.Length;

            }
            else
            {
                borndate_input.Text = "";
            }
        }

        private void borndate_input_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
