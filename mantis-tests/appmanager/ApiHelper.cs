using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using SimpleBrowser.WebDriver;
using OpenQA.Selenium;

namespace mantis_tests
{
    public class ApiHelper : HelperBase
    {
        public ApiHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void CreateNewIssue(AccountData account, ProjectData project, IssueData issueData)
        {
            //mantis.MantisConnectPortTypeClient client = new mantis.MantisConnectPortTypeClient();

            mantis.MantisConnectPortTypeClient client = 
                new mantis.MantisConnectPortTypeClient
                ("MantisConnectPort", "http://localhost/mantisbt-2.25.2/api/soap/mantisconnect.php?WSDL");


            mantis.IssueData issue = new mantis.IssueData();
            issue.summary = issueData.Summary;
            issue.description = issueData.Description;
            issue.category = issueData.Category;
            issue.project = new mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Username, account.Password, issue);
        }
    }
}
