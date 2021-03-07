﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {


        [Test]
        public void ContactRemovalTest()
        {
            app.Contacts.Remove(5);
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }
    }
}