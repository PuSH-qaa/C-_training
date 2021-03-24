using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Text.RegularExpressions;

namespace Addressbook_web_tests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        internal ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.GoToHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                                            .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allemails = cells[4].Text;
            string allphones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllEmails = allemails,
                AllPhones = allphones
            };
        }

        internal ContactData GetContactInformationFromDetails(int detailsIndex)
        {
            manager.Navigator.GoToHomePage();
            GoToDetails(detailsIndex);
            string allData = driver.FindElement(By.Id("content")).Text;
            return new ContactData("", "")
            {
                AllData = allData
            };
        }

        internal ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.GoToHomePage();
            EditContact(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email0 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Middlename = middleName,
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email0 = email0,
                Email1 = email1,
                Email2 = email2
            };
        }

        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        private List<ContactData> contactCache= null;


        public List<ContactData> GetContactList()
        {
            if(contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> fields = element.FindElements(By.TagName("td"));
                    string lastname = fields[1].Text;
                    string firstname = fields[2].Text;
                    contactCache.Add(new ContactData(firstname, lastname));
                }
            }
            
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public ContactHelper UpdateContact(ContactData newData, int i)
        {

            EditContact(i);
            FillContactForm(newData);
            SubmitContactUpdating();
            return this;
        }

        public ContactHelper Remove(int n)
        {
            SelectContact(n);
            RemoveContact();
            AcceptRemoving();
            return this;
        }
        public void CheckAndCreateContactIfItIsNotExist()
        {
            manager.Navigator.GoToHomePage();
            if (!IsElementPresent(By.XPath("//img[@alt='Edit']")))
            {
                AddNewContact();
                ContactData contact = new ContactData("OldName1", "OldName3");
                contact.Middlename = "OldName2";
                FillContactForm(contact);
                SubmitContactCreation();
                manager.Navigator.ReturnToHomePage();
            }
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+2) + "]/td")).Click();
            return this;
        }
        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        private void AcceptRemoving()
        {
            driver.SwitchTo().Alert().Accept();
        }
        public ContactHelper EditContact(int contactIndex)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + (contactIndex+1) + "]")).Click();
            return this;
        }
        public ContactHelper SubmitContactUpdating()
        {
            driver.FindElement(By.XPath("(//input[@name='update'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper GoToDetails(int detailsIndex)
        {
            driver.FindElement(By.XPath("(//img[@alt='Details'])[" + (detailsIndex + 1) + "]")).Click();
            return this;
        }
    }
}
