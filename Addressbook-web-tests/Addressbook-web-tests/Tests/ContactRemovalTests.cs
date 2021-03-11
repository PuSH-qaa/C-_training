using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {


        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.CheckAndCreateContactIfItIsNotExist();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Remove(2);
            app.Navigator.GoToHomePage();

            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.RemoveAt(1);

            Assert.AreEqual(oldContacts, newContacts);

            app.Auth.Logout();
        }
    }
}
