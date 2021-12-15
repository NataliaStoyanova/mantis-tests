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
    public class ProjectData : IEquatable<ProjectData>, IComparable<ProjectData>
    {
        private string projectName;
        private string status;
        private bool inheritGlobalCategories;
        private string viewStatus;
        private string description;

        public ProjectData(string projectName, string description)
        {
            this.ProjectName = projectName;
            this.Description = description;
        }

        public string ProjectName { get => projectName; set => projectName = value; }
        public string Description { get => description; set => description = value; }

        //returns "1" - if this object is grt with our compare rule then the second object
        //returns "0" - if objects are equal
        //returns "-1" - if this object is less with our compare rule the second object
        public int CompareTo(ProjectData other)
        {
            //if the second object  is null, then our object is greater
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Object.ReferenceEquals(other.ProjectName, ProjectName))

            {
                return Description.CompareTo(other.Description);
            }
            else
            {
                return ProjectName.CompareTo(other.ProjectName);
            }
        }

        public bool Equals(ProjectData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return ProjectName == other.ProjectName && Description == other.Description;
        }

        public override string ToString()
        {
            return "ProjectName= " + ProjectName + "\nDescription " + Description;
        }
    }
}