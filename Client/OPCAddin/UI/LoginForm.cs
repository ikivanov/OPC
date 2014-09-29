using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCAddin.UI
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private Credentials GetCredentials()
        {
            return new Credentials
            {
                Username = this.txtUsername.Text,
                Password = this.txtPassword.Text
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                LoginService.GetInstance().Login(this.GetCredentials());

                this.Invoke((MethodInvoker)delegate
                {
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while logging in: " + ex.Message);
            }
        }
    }
}