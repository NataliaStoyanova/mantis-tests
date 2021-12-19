using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;


namespace mantis_tests
{
    [TestFixture]
    public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTestUI()
        {
            List<ProjectData> oldProjects = app.PMHelper.GetProjectListUI();
            ProjectData project = new ProjectData("ProjectX", "Description");
            app.PMHelper.Create(project);

            List<ProjectData> newProjects = app.PMHelper.GetProjectListUI();
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }

        [Test]
        public void ProjectCreationTestAPI()
        {
            AccountData account = new AccountData("administrator", "MantisTest85");
            List<ProjectData> oldProjects = app.API.GetProjectListAPI(account);
            ProjectData project = new ProjectData("ProjectX3444", "Description");
            app.API.Create(account, project);

            List<ProjectData> newProjects = app.API.GetProjectListAPI(account);
            oldProjects.Add(project);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
