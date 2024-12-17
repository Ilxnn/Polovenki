using Polovenki;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Utilities.Classes
{
    public static class FormTransition
    {
        static findForm findForm;
        static profileForm profileForm;
        static messengerForm messengerForm;
        static SettingForm settingForm;
        static Panel loadPanel;

        public static void setFindForm(findForm FindForm) { findForm = FindForm; }
        public static void setProfileForm(profileForm ProfileForm) { profileForm = ProfileForm; }
        public static void setMessengerForm(messengerForm MessengerForm) { messengerForm = MessengerForm; }
        public static void setSettingForm(SettingForm SettingForm) { settingForm = SettingForm; }
        public static void setLoadPanel(Panel LoadPanel) { loadPanel = LoadPanel; }
        public static findForm GetFindForm() { return findForm; }
        public static profileForm GetProfileForm() {  return profileForm; }
        public static messengerForm GetMessengerForm() {  return messengerForm; }
        public static SettingForm GetSettingForm() { return settingForm; }
        public static Panel GetLoadPanel() { return loadPanel; }
    }
}
