using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleBrowser.WebDriver;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace mantis_tests
{
    public class ApiHelper : HelperBase
    {
        mantis.MantisConnectPortTypeClient _client;

        public ApiHelper(ApplicationManager manager) : base(manager)
        {
            _client = new mantis.MantisConnectPortTypeClient
                ("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");
        }
        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            mantis.IssueData issue = new mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantis.ObjectRef();
            issue.project.id = project.Id;
            _client.mc_issue_add(account.Username, account.Password, issue);
        }

        //Zadanie 22. изменить вспомогательную функцию для получения списка проектов таким образом,
        //чтобы она работала через веб-сервис MantisConnect (операция mc_projects_get_user_accessible)

        private List<ProjectData> projectDataList = null;
        public List<ProjectData> GetProjectListAPI(AccountData account)
        {
            projectDataList = new List<ProjectData>();

            //mantis.ProjectData mantisProject = new mantis.ProjectData();

            mantis.ProjectData[]  mantisProjects = _client.mc_projects_get_user_accessible(account.Username, account.Password);
            foreach (mantis.ProjectData pr in mantisProjects)
            {
                ProjectData myProject = new ProjectData();
                myProject.ProjectName = pr.name;
                myProject.Description = pr.description;
                projectDataList.Add(myProject);
            }
            return projectDataList;
        }

        public void Create(AccountData account,ProjectData project)
        {
            mantis.ProjectData mProject = new mantis.ProjectData();
            mProject.name = project.ProjectName;
            mProject.description = project.Description;
            _client.mc_project_add(account.Username, account.Password, mProject);
        }
    }
}
