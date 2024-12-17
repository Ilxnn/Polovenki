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
using static Utilities.Classes.SQLHelper;
using static Utilities.Classes.RelativePath;
using Utilities.Classes;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace Polovenki
{
    public partial class profileForm : Form
    {

        Panel LoadPanel;
        findForm Findform;
        messengerForm MessengerForm;

        int percent = 0;

        List<object> senders = new List<object>();

        public profileForm(findForm findform, messengerForm messengerForm ,Panel loadPanel)
        {
            InitializeComponent();
            
            LoadPanel = loadPanel;
            MessengerForm = messengerForm;
            Findform = findform;
            this.DoubleBuffered = true;
        }
        static Image ByteArrayToImage(byte[] byteArray)
        {
            using (MemoryStream ms = new MemoryStream(byteArray))
            {
                Image image = Image.FromStream(ms);
                return image;
            }
        }

        static byte[] ImageToArrayByte(Image image) {
            using (MemoryStream ms = new MemoryStream())
            {
                ((Bitmap)image).Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                return imageBytes;   
            }
        }

        public void uploadUserData() {
            SetNameDB("1cef673ireh4.db");
            string SQLQuery = "SELECT \"mail/number\" FROM \"user_data\" WHERE \"id\" = " + dataBuffer.getUserID() + ";";
            email_input.Text = getValue(SQLQuery, "mail/number");

            SQLHelper.CloseConnection();


            object name, photoObj, borndate, city, height, weight, hobby, music;
            byte[] photo;
            Dictionary<string, object> userData = new Dictionary<string, object> { };

            SQLHelper.SetNameDB("usersData.db");
            SQLQuery = "SELECT \"name\",\"borndate\",\"Image\",\"city\",\"height\",\"weight\",\"hobby\",\"music\" FROM \"users_data\" WHERE \"id\" = " + dataBuffer.getUserID() + ";";


            userData = SQLHelper.GetUsersData(SQLQuery);
            SQLHelper.CloseConnection();

            userData.TryGetValue("name", out name);
            userData.TryGetValue("born_date", out borndate);
            userData.TryGetValue("Image", out photoObj);
            userData.TryGetValue("city", out city);
            userData.TryGetValue("height", out height);
            userData.TryGetValue("weight", out weight);
            userData.TryGetValue("hobby", out hobby);
            userData.TryGetValue("music", out music);

            if (photoObj == null) { userPhoto.BackgroundImage = new Bitmap(Utilities.Classes.RelativePath.GetFullPath(@"Source\img\prof_sett_img_back.png")); }
            else {
                Console.WriteLine($"fwefwe {photoObj}");
                photo = (byte[])photoObj; userPhoto.BackgroundImage = ByteArrayToImage(photo); addPercentAtProgressBar(); }

            if ( city == null) { city_input.Text = string.Empty; }
            else { city_input.Text = city.ToString(); }
            if (borndate == null) { borndate_input.Text = string.Empty; }
            else { borndate_input.Text = borndate.ToString(); }
            if (name == null) { name_input.Text = string.Empty; }
            else { name_input.Text = name.ToString(); }
            if ( height == null) { height_input.Text = string.Empty; }
            else { height_input.Text = height.ToString(); }
            if ( weight == null) { weight_input.Text = string.Empty; }
            else { weight_input.Text = weight.ToString(); }
            if (hobby == null) { hobby_input.Text = string.Empty; }
            else { hobby_input.Text = hobby.ToString(); }
            if ( music == null) { music_input.Text = string.Empty; }
            else { music_input.Text = music.ToString(); }
            
            List<RichTextBox> list = new List<RichTextBox>();
            list.Add(city_input);
            list.Add(height_input);
            list.Add(hobby_input);
            list.Add(city_input);
            list.Add(music_input);
            list.Add(name_input);
            list.Add(borndate_input);

            foreach (RichTextBox rch in list) {
                if (rch.Text != string.Empty) {
                    senders.Add(rch);
                    addPercentAtProgressBar();
                }
            }

        }

        private void btn_back_Click_1(object sender, EventArgs e)
        {
            SetNameDB("1cef673ireh4.db");
            string SQLQuery;
            Dictionary<string, object> parameters;
            if (pass_input.Text != string.Empty) { 
                SQLQuery = "UPDATE \"user_data\" SET \"mail/number\" = @email_input, \"password\" = @password WHERE \"id\" = " + dataBuffer.getUserID() + ";";
                parameters = new Dictionary<string, object>
                {
                    { "@email_input", email_input.Text },
                    { "@password", pass_input.Text }
                };
            }
            else {
                SQLQuery = "UPDATE \"user_data\" SET \"mail/number\" = @email_input WHERE \"id\" = " + dataBuffer.getUserID() + ";";
                parameters = new Dictionary<string, object>
                {
                    { "@email_input", email_input.Text }
                };
            }
            ExecuteUpdateWithParameters(SQLQuery, parameters);
            CloseConnection();

            SQLHelper.SetNameDB("usersData.db");
            SQLQuery = "UPDATE \"users_data\" SET \"name\" = @name,\"borndate\" = @borndate,\"Image\" = @Image,\"city\" = @city,\"height\" = @height,\"weight\" = @weight,\"hobby\" = @hobby,\"music\" = @music WHERE \"id\" = " + dataBuffer.getUserID() + ";";
            parameters = new Dictionary<string, object>
            {
                { "@name", name_input.Text },
                { "@borndate", borndate_input.Text },
                { "@Image", ImageToArrayByte(userPhoto.BackgroundImage) },
                { "@city", city_input.Text },
                { "@height", height_input.Text },
                { "@weight", weight_input.Text },
                { "@hobby", hobby_input.Text },
                { "@music", music_input.Text }
            };
            ExecuteUpdateWithParameters(SQLQuery, parameters);
            CloseConnection();

            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(Findform);
            Findform.Show();
        }

        private void userPhoto_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void userPhoto_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void userPhoto_Click(object sender, EventArgs e)
        {
            
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "Image Files(*.PNG;*.JPG;*.JPEG)|*.PNG;*.JPG;*.JPEG";
                openFileDialog.FilterIndex = 0;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }

                    userPhoto.BackgroundImage = new Bitmap(filePath);
                    addPercentAtProgressBar();
                }
            }
        }

        public void addPercentAtProgressBar() {
            progressBar.Width = progressBar.Width + 149;
            progressBar.Refresh();
            if (percent == 84) { percent = percent + 16; }
            else { percent = percent + 12; }
            
            kryptonLabel3.Location = new Point(progressBar.Width+25, 584);
            kryptonLabel3.Text = percent + "%";
            kryptonLabel3.Refresh();
        }

        public void delPercentAtProgressBar() {
            Console.WriteLine(progressBar.Width);
            progressBar.Width = progressBar.Width - 149;
            progressBar.Refresh();
            if (percent == 100) { percent = percent - 16; }
            else { percent = percent - 12; }

            kryptonLabel3.Location = new Point(progressBar.Width + 25, 584);
            kryptonLabel3.Text = percent + "%";
            kryptonLabel3.Refresh();
        }

        private void btn_messenger_Click(object sender, EventArgs e)
        {
            LoadPanel.Controls.Clear();
            LoadPanel.Controls.Add(MessengerForm);
            MessengerForm.Show();
        }

        private void city_input_Leave(object sender, EventArgs e)
        {
            RichTextBox tb = sender as RichTextBox;
            if (!senders.Contains(sender) && tb.Text != string.Empty) { addPercentAtProgressBar(); senders.Add(sender); }
            if (senders.Contains(sender) && tb.Text == string.Empty) { delPercentAtProgressBar();  senders.Remove(sender); }
            

        }

        private void profileForm_Shown(object sender, EventArgs e)
        {
            userPhoto.BackgroundImage = new Bitmap(Utilities.Classes.RelativePath.GetFullPath(@"Source\img\prof_sett_img_back.png"));
            uploadUserData();
        }
    }
}
