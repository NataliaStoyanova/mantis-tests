using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class AddNewIssueTests: AuthTestBase
    {
        [Test]
        public void AddNewIssue()
        {
            AccountData account = new AccountData("administrator", "MantisTest85");
            IssueData issue = new IssueData("Some summary", "Some description", "General");
            ProjectData project = new ProjectData() { Id = "1"};
            app.API.CreateNewIssue(account, project, issue);
        }
    }
}
