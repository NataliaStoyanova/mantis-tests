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
using System.Collections.Generic;

namespace mantis_tests
{
    public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager) { }

        public bool DoesTheProjectExist(int i)
        {
            manager.Menu.OpenManageProjectsTab();
            return IsElementPresent(By.XPath("//body[1]/div[2]/div[2]/div[2]/div[1]/div[1]/" +
                "div[2]/div[2]/div[1]/div[2]/table[1]/tbody[1]/tr["+(i)+"]"));
        }

        private List<ProjectData> projectData = null;

        //Zadanie 22. изменить вспомогательную функцию для получения списка проектов таким образом,
        //чтобы она работала через веб-сервис MantisConnect (операция mc_projects_get_user_accessible)

        public List<ProjectData> GetProjectList()
        {
            projectData = new List<ProjectData>();

            manager.Menu.OpenManageProjectsTab();
            ICollection<IWebElement> elements = driver
                .FindElements(By.XPath("//div[@class='widget-box widget-color-blue2']//table/tbody/tr"));
            foreach (IWebElement element in elements)
            {
                var tds = element.FindElements(By.TagName("td"));
                if (tds.Count < 5) continue;
                ProjectData project = new ProjectData(tds[0].Text, tds[4].Text);
                projectData.Add(project);
            }
            return projectData;
        }

        public void Create(ProjectData project)
        {
            manager.Menu.OpenManageProjectsTab();
            CreateNewProjectBtn();
            FillProjectForm(project);
            SubmitProject();
        }

        public void Remove(int i)
        {
            manager.Menu.OpenManageProjectsTab();
            driver.FindElement(By.XPath("//div[@class='widget-box widget-color-blue2']//table/tbody/tr[" + (i) + "]/td[1]/a")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
               .Until(d => d.FindElements(By.XPath("//input[@value='Delete Project']")).Count > 0);

            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
            .Until(d => d.FindElements(By.XPath("//input[@value='Delete Project']")).Count > 0);

            driver.FindElement(By.XPath("//input[@value='Delete Project']")).Click();
        }


        public void SubmitProject()
        {
            driver.FindElement(By.XPath("//input[@value='Add Project']")).Click();
        }

        public void FillProjectForm(ProjectData project)
        {
            driver.FindElement(By.Id("project-name")).SendKeys(project.ProjectName);
            driver.FindElement(By.Id("project-description")).SendKeys(project.Description);
        }

        public void CreateNewProjectBtn()
        {
            driver.FindElement(By.XPath("//button[contains(text(),'Create New Project')]")).Click();
        }
    }
}
