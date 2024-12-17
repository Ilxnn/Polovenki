using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using Utilities.Classes;
using static Utilities.Classes.ChangeParameters;
using static Utilities.Classes.Settings;

namespace Polovenki
{
    public partial class mainForm : KryptonForm
    {
        static bool _unauthorizedUser = bool.Parse(ReadParam("_unauthorizedUser").Trim('"'));
        bool _INTRAY = false; 

        login__signin_Form login__Signin_Form;
        findForm findForm;
        SettingForm settingForm;

        public mainForm()
        {
            InitializeComponent();

            login__Signin_Form = new login__signin_Form(this) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            findForm = new findForm(loadPanel) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            settingForm = new SettingForm() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            FormTransition.setFindForm(findForm);
            FormTransition.setSettingForm(settingForm);
            FormTransition.setLoadPanel(loadPanel);
            this.DoubleBuffered = true;
            if (_unauthorizedUser)
            {
                this.loadPanel.Controls.Add(login__Signin_Form);
                login__Signin_Form.loginsigninResult += loginsigninForm_loginsigninResult;
                login__Signin_Form.Show();
            }
            else {              
                logo.Visible = true;
                this.loadPanel.Controls.Clear();
                findForm.setIsLogin(true);
                this.loadPanel.Controls.Add(findForm);
                findForm.Show();
            }
        }

        // Обработчик поведения при переходе из формы логина/регистрации
        private void loginsigninForm_loginsigninResult(object sender, loginsigninResult e)
        {
            bool loginSuccess = e.loginsignin;
            bool isLoginForm = e.isLoginForm;

            if (isLoginForm)
            {
                if (loginSuccess)
                {
                    this.loadPanel.Controls.Clear();
                    findForm.setIsLogin(isLoginForm);
                    this.loadPanel.SuspendLayout();
                    this.loadPanel.Controls.Add(findForm);
                    this.loadPanel.ResumeLayout();
                    findForm.Show();

                }
                else
                {
                }
            }
            else {
                if (loginSuccess)
                {
                    this.loadPanel.Controls.Clear();
                    findForm.setIsLogin(isLoginForm);
                    this.loadPanel.Controls.Add(findForm);
                    findForm.Show();
                }
                else
                {
                }
            }
        }

        // Перемещение окна
        private int x, y;

        private void Win_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left = (this.Left + e.X) - x;
                this.Top = (this.Top + e.Y) - y;
            }
        }

        private void Win_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        // Кнопки управления окном
        private void btn_close_Click(object sender, EventArgs e)
        {
            if (!_INTRAY) {
                this.Hide();
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(1000);
                _INTRAY = true;
            }
            else {
                notifyIcon1.Visible = false;
            }
        }

        private void btn_max_CLick(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void mainForm_LocationChanged(object sender, EventArgs e)
        {

        }

        private void mainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!dataBuffer.getValue())
            {
                this.loadPanel.Controls.Clear();
                this.loadPanel.Controls.Add(settingForm);
                settingForm.Show();
                dataBuffer.setValue(true);
            }
            else {
                this.loadPanel.Controls.Clear();
                this.loadPanel.Controls.Add(findForm);
                findForm.Show();
                dataBuffer.setValue(false);
            }

        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipTitle = "Поloveнки";
            notifyIcon1.BalloonTipText = "Приложение свернуто";
            notifyIcon1.Text = "Поloveнки";
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            _INTRAY = false;
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void выйтиИзПрофиляToolStripMenuItem_Click(object sender, EventArgs e)
        {
            exitFromProfile();
        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            _INTRAY = false;
        }

        private void btn_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

    }
}
