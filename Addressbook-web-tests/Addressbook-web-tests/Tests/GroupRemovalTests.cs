using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        

        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.SelectGroup(1);
            app.Groups.RemoveGroup();
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    } 
}
