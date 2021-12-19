using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleBrowser.WebDriver;


namespace mantis_tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            AccountData account = new AccountData("administrator", "MantisTest85");
            
            //prepare
            //app.Auth.Logout(account);

            //app.Auth.Login(account);
            app.Auth.OpenAppAndLogin(account);

            //verification
            Assert.IsTrue(app.Auth.isLoggedIn(account));

        }
    }
}

