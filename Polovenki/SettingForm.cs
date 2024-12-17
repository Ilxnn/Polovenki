using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Utilities.Classes.RelativePath;
using static Utilities.Classes.FormTransition;
using static Utilities.Classes.ChangeParameters;
using static Utilities.Classes.Settings;

namespace Polovenki
{
    public partial class SettingForm : Form
    {

        public SettingForm()
        {
            InitializeComponent();
            if (bool.Parse(ReadParam("_notificationEnable").Trim('"'))) { btn_close.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_on.png"))); }
            else { btn_close.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_off.png"))); }
            if (bool.Parse(ReadParam("_soundEnable").Trim('"'))) { button1.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_on.png"))); }
            else { button1.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_off.png")));}
            this.DoubleBuffered = true;
        }

        private void kryptonPanel4_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void kryptonPanel4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            exitFromProfile();
        }

        private void btn_messenger_Click(object sender, EventArgs e)
        {
            GetLoadPanel().Controls.Clear();
            GetLoadPanel().Controls.Add(GetMessengerForm());
            GetMessengerForm().Show();
            
        }

        private void btn_profile_Click(object sender, EventArgs e)
        {
            GetLoadPanel().Controls.Clear();
            GetLoadPanel().Controls.Add(GetProfileForm());
            GetProfileForm().Show();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            if (!bool.Parse(ReadParam("_notificationEnable").Trim('"'))) { btn_close.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_on.png"))); SetParamValue("_notificationEnable", "true"); }
            else { btn_close.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_off.png"))); SetParamValue("_notificationEnable", "false"); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!bool.Parse(ReadParam("_soundEnable").Trim('"'))) { button1.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_on.png"))); SetParamValue("_soundEnable", "true"); }
            else { button1.BackgroundImage = new Bitmap((GetFullPath(@"Source\img\setting_off.png"))); SetParamValue("_soundEnable", "false"); }


        }
    }
}
