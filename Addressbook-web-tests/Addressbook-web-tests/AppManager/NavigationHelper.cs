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
    public class NavigationHelper : HelperBase
    {
        public string baseURL;
        public NavigationHelper(IWebDriver driver, string baseURL) 
            : base(driver)
        {
            this.baseURL = baseURL;
        }
        public void OpenMainPage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void GoToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }
    }
}