using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenMainPage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("XXX");
            group.Header = "YYY";
            group.Footer = "ZZZ";
            app.Groups.FillGroupForm(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        } 
    }
}
