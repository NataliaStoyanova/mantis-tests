using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;


namespace mantis_tests
{
    public class AuthHelper : HelperBase
    {
        private string baseUrl;
        public AuthHelper(ApplicationManager manager, String baseUrl) : base(manager)
        {
            this.baseUrl = baseUrl;
        }

        public IWebDriver OpenAppAndLogin(AccountData account)
        {
            //IWebDriver driver = new SimpleBrowserDriver();
            //driver.Url = baseUrl + "login_page.php";
            Type(By.Id("username"), account.Username);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
            
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector("input[value='Login']")).Click();
            return driver;
        }

        public void Login(AccountData account)
        {
            if (isLoggedIn(account))
            {
                Logout(account);
            }
            Type(By.Id("username"), account.Username);
            driver.FindElement(By.CssSelector("input[type=\"Submit\"]")).Click();
            Type(By.Id("password"), account.Password);
            driver.FindElement(By.CssSelector("input[type=\"Submit\"]")).Click();
        }
        public void Logout(AccountData account)
        {
            if (isLoggedIn(account))
            {
                driver.FindElement(By.XPath("//span[@class='user-info']")).Click();
                driver.FindElement(By.LinkText("Logout")).Click();
                driver.FindElement(By.Name("user"));
            }        
        }

        public bool isLoggedIn()
        {
            return IsElementPresent(By.XPath("//span[@class='user-info']"));
        }
        public bool isLoggedIn(AccountData account)
        {
            return isLoggedIn() && GetLoggedUserName() == account.Username;
        }
    
        public string GetLoggedUserName()
        {         
            string text =  driver.FindElement(By.XPath("//span[@class='user-info']")).Text;
            return text;
        }
    }
}
