using System;
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
            app.Contacts.CheckAndCreateContactIfItIsNotExist();

            app.Contacts.Remove(2);
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }
    }
}
