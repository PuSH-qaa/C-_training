﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {

            ContactData contact = new ContactData("FirstName");
            contact.Middlename = "MiddleName";
            contact.Lastname = "LastName";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts
               .AddNewContact()
               .FillContactForm(contact)
               .SubmitContactCreation();
            
            List<ContactData> newContacts = app.Contacts.GetContactList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
