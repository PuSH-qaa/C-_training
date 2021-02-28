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
            OpenMainPage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("XXX");
            group.Header = "YYY";
            group.Footer = "ZZZ";
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            Logout();
        } 
    }
}
