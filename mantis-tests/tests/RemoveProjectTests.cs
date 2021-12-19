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
                oldProjects = app.PMHelper.GetProjectListUI();
            }
            else
            {
                ProjectData Project = new ProjectData("Project1", "description");
                app.PMHelper.Create(Project);
                oldProjects = app.PMHelper.GetProjectListUI();
            }
            ProjectData toBeRemoved = oldProjects[0];
            app.PMHelper.Remove(1);
          
            List<ProjectData> newProjects = app.PMHelper.GetProjectListUI();
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }



        [Test]
        public void ProjectRemovalTestAPI()
        {
            //Zadanie 22
            //повысить интеллектуальность тестов для удаления, чтобы они предварительно проверяли наличие проекта,
            //который можно удалить, и если ни одного проекта не нашлось 
            //--создавали какой - нибудь проект, и делали это через веб - сервис MantisConnect(операция mc_project_add)
            
            AccountData account = new AccountData("administrator", "MantisTest85");

            List<ProjectData> oldProjects;
            if (app.API.GetProjectListAPI(account).Count>1)
            {
                oldProjects = app.API.GetProjectListAPI(account);
            }
            else
            {
                ProjectData project = new ProjectData("Project1", "description");
                app.API.Create(account,project);
                oldProjects = app.API.GetProjectListAPI(account);
            }
            ProjectData toBeRemoved = oldProjects[0];
            app.PMHelper.Remove(1);

            List<ProjectData> newProjects = app.API.GetProjectListAPI(account);
            oldProjects.RemoveAt(0);
            oldProjects.Sort();
            newProjects.Sort();
            Assert.AreEqual(oldProjects, newProjects);
        }
    }
}
