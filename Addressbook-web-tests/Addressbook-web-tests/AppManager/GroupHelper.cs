using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Addressbook_web_tests
{
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            return this;
        }
        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            if (! IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("XXX");
                group.Header = "YYY";
                group.Footer = "ZZZ";
                Create(group);
                manager.Navigator.ReturnToGroupsPage();
            }
            SelectGroup(index);
            RemoveGroup();
            return this;
        }
        public GroupHelper UpdateGroup(GroupData newData, int a)
        {
            manager.Navigator.GoToGroupsPage();
            if (! IsElementPresent(By.Name("selected[]")))
            {
                GroupData group = new GroupData("XXX");
                group.Header = "YYY";
                group.Footer = "ZZZ";
                Create(group);
                manager.Navigator.ReturnToGroupsPage();
            }
            SelectGroup(a);
            EditGroup();
            FillGroupForm(newData);
            SubmitGroupUpdating();
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public GroupHelper EditGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupUpdating()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }
    }
}
