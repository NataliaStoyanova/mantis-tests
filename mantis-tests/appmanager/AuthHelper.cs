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
    public class AuthHelper : HelperBase
    {
        public AuthHelper(ApplicationManager manager) : base(manager)
        {
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

        //string.Format("(${0})", account.Username ~~ ${0}=account.Username
        public string GetLoggedUserName()
        {         
            string text =  driver.FindElement(By.XPath("//span[@class='user-info']")).Text;
            return text;
        }
    }
}
