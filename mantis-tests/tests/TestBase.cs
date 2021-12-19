using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleBrowser.WebDriver;
//TestBase is responsible for initialisation and for stopping the browser 

namespace mantis_tests
{
    public class TestBase
    {
        //protected bool acceptNextAlert = true;
        protected ApplicationManager app;

        [TestFixtureSetUp]
        public void SetUpApplicationManager()
        {
            //Singletone
            app = ApplicationManager.GetInstance();
        }
    }
}
