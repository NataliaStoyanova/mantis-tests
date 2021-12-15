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
    public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTestUI()
        {
            List<ProjectData> oldProjects;

            if (app.PMHelper.DoesTheProjectExist(1))
            {
                oldProjects = app.PMHelper.GetProjectList();
            }
            else
            {
                ProjectData Project = new ProjectData("Project1", "description");
                app.PMHelper.Create(Project);
                oldProjects = app.PMHelper.GetProjectList();
            }
            ProjectData toBeRemoved = oldProjects[0];
            app.PMHelper.Remove(1);
          

            List<ProjectData> newProjects = app.PMHelper.GetProjectList();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
