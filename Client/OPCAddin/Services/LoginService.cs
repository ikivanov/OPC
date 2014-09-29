using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OPCAddin
{
    public class LoginService
    {
        private static LoginService instance;
        private string userToken;

        public event EventHandler LogedIn;

        public string UserToken
        {
            get
            {
                return this.userToken;
            }
        }

        public static LoginService GetInstance()
        {
            if (instance == null)
            {
                instance = new LoginService();
            }

            return instance;
        }

        public async void Login(Credentials credentials)
        {
            var result = await BackendServiceProxy.Login(credentials);

            if (result.Success)
            {
                this.userToken = result.UserToken;

                if (this.LogedIn != null)
                {
                    this.LogedIn(this, EventArgs.Empty);
                }
            }
            else
            {
                throw new Exception(result.Msg);
            }
        }
    }
}