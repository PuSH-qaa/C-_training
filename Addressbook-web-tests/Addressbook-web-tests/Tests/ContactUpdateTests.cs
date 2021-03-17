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
            ContactData newData = new ContactData("FirstNameUpdate", "LastNameUpdate");
            newData.Middlename = "MiddleUpdate";

            app.Contacts.CheckAndCreateContactIfItIsNotExist();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.UpdateContact(newData, 0);
            app.Navigator.ReturnToHomePage();

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }
    }
}
