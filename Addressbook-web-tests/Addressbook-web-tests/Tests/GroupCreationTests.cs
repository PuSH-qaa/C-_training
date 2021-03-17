using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
     

        [Test]
        public void GroupCreationTest()
        {

            GroupData group = new GroupData("XXX");
            group.Header = "YYY";
            group.Footer = "ZZZ";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group); 
            app.Navigator.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.Logout();
        }
        [Test]
        public void EmptyGroupCreationTest()
        {

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            app.Navigator.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.Logout();
        }
        [Test]
        public void BadNameGroupCreationTest()
        {

            GroupData group = new GroupData("X'X");
            group.Header = "YYY";
            group.Footer = "ZZZ";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);
            app.Navigator.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count + 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.Logout();
        }
    }
}
