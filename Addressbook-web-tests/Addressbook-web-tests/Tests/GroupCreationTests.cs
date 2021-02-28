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

            GroupData group = new GroupData("XXX");
            group.Header = "YYY";
            group.Footer = "ZZZ";

            app.Groups.Create(group);
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}
