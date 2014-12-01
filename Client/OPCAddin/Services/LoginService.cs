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

        public event EventHandler LogedIn;

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