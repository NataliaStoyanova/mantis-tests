using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;

        public RegistrationHelper Registration { get; set; }
        public AuthHelper Auth { get; set; }
        public ProjectManagementHelper PMHelper { get; set; }
        public ManagementMenuHelper Menu { get; set; }
        public FtpHelper Ftp { get; set; }

        //ThreadLocal<ApplicationManager> is a special objects that defines the mapping between the current thread and the instance of ApplicationManager 
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        public IWebDriver Driver { get => driver; }

        //no one outside ApplicatinManager class must not create other instances 
        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            baseURL = "http://localhost";
            Registration = new RegistrationHelper(this);
            Ftp = new FtpHelper(this);
            Auth = new AuthHelper(this);
            PMHelper = new ProjectManagementHelper(this);
            Menu = new ManagementMenuHelper(this);

        }

        [TearDown]
        //method Stop moved in destructor 
        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        //GetInstance returns different instances for different threads 
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/login_page.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
    }
}
