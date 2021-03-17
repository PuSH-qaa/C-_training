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
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {
        }
        public ContactHelper AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigator.GoToHomePage();
            ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));

            foreach (IWebElement element in elements)
            {
                IList<IWebElement> fields = element.FindElements(By.TagName("td"));
                string lastname = fields[1].Text;
                string firstname = fields[2].Text;
                contacts.Add(new ContactData(firstname, lastname));
            }
            return contacts;
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
            return this;
        }
    }
}
