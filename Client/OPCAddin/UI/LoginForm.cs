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

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string username = this.txtUsername.Text;
            string password = this.txtPassword.Text;

            try
            {
                LoginResult result = await BackendServiceProxy.Login(username, password);

                if (result.Success) 
                {
                    AddinModule.CurrentInstance.UserToken = result.UserToken;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.Msg);
                }

                
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured while logging in.");
            }
        }
    }
}
