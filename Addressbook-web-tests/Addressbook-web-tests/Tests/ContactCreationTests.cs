using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.AddNewContact();
            app.Contacts.FillContactForm(new ContactData("FirstName", "MiddleName", "LastNBame"));
            app.Contacts.SubmitContactCreation();
            app.Navigator.GoToHomePage();
            app.Auth.Logout();
        }
    }
}
