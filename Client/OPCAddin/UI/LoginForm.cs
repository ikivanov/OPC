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
                LoginResult result = await BackendServiceProxy.Login(new Credentials { Username = username, Password = password });

                if (result.Success) 
                {
                    AddinModule.CurrentInstance.UserToken = result.UserToken;
                    this.Invoke((MethodInvoker)delegate
                    {
                        this.Close();
                    });
                }
                else
                {
                    this.Invoke((MethodInvoker)delegate
                    {
                        MessageBox.Show(result.Msg);
                    }); 
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured while logging in. " + ex.Message + " " + ex.StackTrace);
            }
        }
    }
}
