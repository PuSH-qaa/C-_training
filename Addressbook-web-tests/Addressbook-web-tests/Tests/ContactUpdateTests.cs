using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactUpdateTests : AuthTestBase
    {

        [Test]
        public void ContactUpdateTest()
        {
            ContactData newData = new ContactData("111", "888");
            newData.Middlename = "999";

            app.Contacts.CheckAndCreateContactIfItIsNotExist();

            List<ContactData> oldContacts = ContactData.GetAll();
            ContactData oldData = oldContacts[0];

            app.Contacts.UpdateContact(newData, oldData);
            app.Navigator.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAll();

            oldData.Firstname = newData.Firstname;
            oldData.Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            //app.Auth.Logout();
        }
    }
}
