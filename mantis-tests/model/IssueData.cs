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
    public class IssueData
    {
        public IssueData(string summary, string description, string category)
        {
            Summary = summary;
            Description = description;
            Category = category;
        }

        public string Summary { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}