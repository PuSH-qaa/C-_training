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
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            AddNewContact();
            FillContactForm(new ContactData("FirstName", "MiddleName", "LastNBame"));
            SubmitContactCreation();
            GoToHomePage();
            Logout();
        }
    }
}
