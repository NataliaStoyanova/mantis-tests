using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleBrowser.WebDriver;


namespace mantis_tests
{
    public class AuthTestBase : TestBase
    {
        [SetUp]
        public void SetUpLogin()
        {
            //app.Auth.Login(new AccountData("administrator", "MantisTest85"));
            app.Auth.OpenAppAndLogin(new AccountData("administrator", "MantisTest85"));
        }
    }
}

