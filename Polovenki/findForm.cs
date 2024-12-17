using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utilities.Classes;
using static Utilities.Classes.SQLHelper;
using static Utilities.Classes.RelativePath;
using static Utilities.Classes.dataBuffer;
using static System.Collections.Specialized.BitVector32;

namespace Polovenki
{
    public partial class findForm : Form
    {

        int id = 0, countId = 0;
        int randomId;
        bool isLogin = false;

        Panel LoadPanel;

        profileForm profileForm;
        messengerForm messengerForm;

        object name, age = 0, photoObj, hobby, music, city, sex, reaction;

        string SQLQuery, userSex;

        Dictionary<string, object> parameters;

        List<int> idsList = new List<int>();

        public findForm(Panel loadPanel)
        {
            LoadPanel = loadPanel;
            messengerForm = new messengerForm(this, profileForm, LoadPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            profileForm = new profileForm(this, messengerForm,LoadPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormTransition.setMessengerForm(messengerForm);
            FormTransition.setProfileForm(profileForm);
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        // Преобразование потока байтов в картинку
        static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        // Механизм запуска обучения или запуска основного функционала
        // Установка булевой переменной из какой формы был переход (вход или регистрация)
        public void setIsLogin(bool IsLogin) { 
            isLogin = IsLogin;
            Console.WriteLine(IsLogin);
        }

        // Включение панели обучения
        public void GuideStart() { 
            if(!isLogin)
            {
                guideBanner.Visible = true;
                guideBanner.Dock = DockStyle.Fill;
            }
        }
        
        // Механизм обучения
        public async void Guide()
        {
            for (int i = 1; i <= 6; i++)
            {
                guideBanner.BackgroundImage = new Bitmap(GetFullPath(@"Source\img\Guide\st" + i + ".png"));
                await Task.Delay(5000);
                Console.WriteLine(i);
            }
            guideBanner.Visible = false;
        }

        // Запуск панели обучения при отображении формы
        private void findForm_Shown(object sender, EventArgs e)
        {
            GuideStart();
            nextMan();
        }

        private void findForm_Load(object sender, EventArgs e)
        {
            ChangeLocation();
        }

        // Кнопки обучения
        private void btn_guide_yes_Click(object sender, EventArgs e)
        {
            btn_guide_yes.Visible = false;
            btn_guide_no.Visible = false;
            Guide();
        }

        private void btn_guide_no_Click(object sender, EventArgs e)
        {
            guideBanner.Visible = false;
        }

        private void ChangeLocation() {
            int pnlwidth = PhotoPanel.Width;
            int txtwidth = name_age_text.Width;

            int resultPosition = ((pnlwidth - txtwidth) / 2);
            name_age_text.Location = new Point(resultPosition, 408);
        }

        private void allowedIds() {
            userSex = ChangeParameters.ReadParam("_loginUserSex").Trim('"').ToString();
            string findSex = "";

            switch (userSex)
            {
                case "мужчина":
                    findSex = "woman";
                    break;
                case "женщина":
                    findSex = "man";
                    break;
            }

            SQLHelper.SetNameDB("girlsDataBase.db");
            SQLQuery = $"SELECT id FROM girlsData WHERE sex = \"{findSex}\" AND Reaction = 'n/a';";
            idsList = getIds(SQLQuery);
            SQLHelper.CloseConnection();
        }

        // Механизм свайпа людей
        // Функция для свайпа людей
        private void nextMan() {

            byte[] photo;
            Dictionary<string, object> manData = new Dictionary<string, object> { };


            bool trueSex = false;
            Random random = new Random();

            allowedIds();

            Console.WriteLine(idsList.Count);

            if (idsList.Count == 0 ) {
                PhotoPanel.BackgroundImage = new Bitmap(Utilities.Classes.RelativePath.GetFullPath(@"Source\img\end_find_back.png"));
                btn_dislike.Visible = false;
                btn_like.Visible = false;
                name_age_text.Visible = false;
                hobby_text.Visible=false;
                city_text.Visible=false;
                pictureBox1.Visible=false;
                return; }

            do {
                randomId = random.Next(0, idsList.Count-1);
                SQLHelper.SetNameDB("girlsDataBase.db");
                SQLQuery = $"SELECT \"name\",\"photo\",\"age\",\"hobby\",\"music\",\"city\",\"sex\",\"Reaction\" FROM \"girlsData\" WHERE \"id\" = {idsList[randomId]} AND \"Reaction\" = \"n/a\";";

                manData = SQLHelper.GetNext(SQLQuery);
                SQLHelper.CloseConnection();
                manData.TryGetValue("name", out name);
                manData.TryGetValue("age", out age);
                manData.TryGetValue("photo", out photoObj);
                manData.TryGetValue("hobby", out hobby);
                manData.TryGetValue("music", out music);
                manData.TryGetValue("city", out city);
                manData.TryGetValue("sex", out sex);
                manData.TryGetValue("Reaction", out reaction);

                if (reaction == null)
                {
                    PhotoPanel.BackgroundImage = new Bitmap(Utilities.Classes.RelativePath.GetFullPath(@"Source\img\end_find_back.png"));
                    return;
                }
                else {
                    trueSex = true;
                    break;
                }
                }  
            while (!trueSex && manData == null);


            name_age_text.Text = name + ", " + age;
            Console.WriteLine(photoObj);
            hobby_text.Text = hobby.ToString();
            city_text.Text = city.ToString();
            photo = (byte[])photoObj;
            PhotoPanel.BackgroundImage = ByteArrayToImage(photo);
            name_age_text.Refresh();
            ChangeLocation();
            name_age_text.Refresh();

        }

        // Кнопки лайк и дизлайк
        private void btn_like_Click(object sender, EventArgs e)
        {

            SQLHelper.SetNameDB("girlsDataBase.db");
            SQLQuery = $"UPDATE \"girlsData\" SET \"Reaction\" = @reaction WHERE \"id\" = @id;";
            parameters = new Dictionary<string, object>
            {
                    { "@reaction", "Like" },
                    { "@id", idsList[randomId] }
            };
            ExecuteUpdateWithParameters(SQLQuery, parameters);
            SQLHelper.CloseConnection();

            nextMan();
        }

        private void btn_dislike_Click(object sender, EventArgs e)
        {
            SQLHelper.SetNameDB("girlsDataBase.db");
            SQLQuery = $"UPDATE \"girlsData\" SET \"Reaction\" = @reaction WHERE \"id\" = @id;";
            parameters = new Dictionary<string, object>
            {
                    { "@reaction", "Dislike" },
                    { "@id", randomId }
            };
            ExecuteUpdateWithParameters(SQLQuery, parameters);
            SQLHelper.CloseConnection();
            nextMan();
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(profileForm);
            profileForm.Show();
        }

        private void btn_messenger_Click(object sender, EventArgs e)
        {
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(messengerForm);
            messengerForm.Show();
        }
    }
}
