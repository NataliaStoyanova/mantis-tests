using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace mantis_tests
{
    public class ManagementMenuHelper: HelperBase
    {
        public ManagementMenuHelper(ApplicationManager manager) : base(manager) { }

        public void OpenManageProjectsTab()
        {
            driver.FindElement(By.XPath("//span[contains(text(),'Manage')]")).Click();
            driver.FindElement(By.XPath("//a[contains(text(),'Manage Projects')]")).Click();
        }
    }
}
