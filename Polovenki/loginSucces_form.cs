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

namespace Polovenki
{
    public partial class loginSucces_form : KryptonForm
    {
        Form parent;
        public loginSucces_form(Form parentForm, string answer)
        {
            InitializeComponent();
            this.CenterToParent();

        }

        private void loginSucces_form_Shown(object sender, EventArgs e)
        {
            System.Threading.Thread.Sleep(4000);
            this.Close();
        }
    }
}
