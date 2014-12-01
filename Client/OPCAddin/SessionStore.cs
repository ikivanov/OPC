using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;

namespace OPCAddin
{
    public class SessionStore
    {
        private static SessionStore s_instance = null;

        private SessionStore()
        {
        }

        public static SessionStore GetInstance()
        {
            if (s_instance == null)
            {
                s_instance = new SessionStore();
            }

            return s_instance;
        }

        public Cookie SessionCookie { get; set; }

        public HttpClientHandler GetHttpClientHandlerWithSID()
        {
            if (this.SessionCookie == null)
            {
                throw new InvalidOperationException("SessionCookie must be set first prior to ivolking this method.");
            }

            var cookies = new CookieContainer();
            var handler = new HttpClientHandler();
            handler.CookieContainer = cookies;
            handler.CookieContainer.Add(new Uri(AddinModule.CurrentInstance.ServiceUrl), this.SessionCookie);

            return handler;
        }
    }
}
