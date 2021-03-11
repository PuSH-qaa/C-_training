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
            ContactData newData = new ContactData("FirstName");
            newData.Middlename = "MiddleName";
            newData.Lastname = "LastName";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.CheckAndCreateContactIfItIsNotExist();

            app.Contacts.UpdateContact(newData, 1);
            app.Navigator.ReturnToHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts[1].Firstname = newData.Firstname;
            oldContacts[1].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }
    }
}
