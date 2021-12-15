using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using NUnit.Framework;

namespace mantis_tests
{
    [TestFixture]
    public class CreateAccountTests : TestBase
    {

      [TestFixtureSetUp]
        public void setUpConfig()
         {
             app.Ftp.BackupFile("/config_inc.php");
             using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
             {
                 app.Ftp.Upload("/config_inc.php", localFile);
             }           
         }
        [Test]
        public void AccountRegistrationTest()
        {
            AccountData account = new AccountData("testuser", "password", "testuser@localhost.localadmin");
            app.Registration.Register(account);
        }

        [TestFixtureTearDown]
        public void restoreConfig()
        {
            app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}
