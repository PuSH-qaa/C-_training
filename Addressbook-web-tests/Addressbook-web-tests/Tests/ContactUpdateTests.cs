﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            app.Contacts.CheckAndCreateContactIfItIsNotExist();

            app.Contacts.UpdateContact(newData, 1);
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
