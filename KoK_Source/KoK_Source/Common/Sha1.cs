using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static System.Web.Security.FormsAuthentication;

namespace KoK_Source.Common
{
    public class Sha1
    {
        public string Mahoa(string pass)
        {
            var newpass = HashPasswordForStoringInConfigFile(pass.Trim(), "SHA1");
            return newpass;
        }
    }
}