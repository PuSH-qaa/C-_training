using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupUpdateTests : AuthTestBase
    {
 
        [Test]
        public void GroupUpdateTest()
        {
            GroupData newData = new GroupData("123");
            newData.Header = "999";
            newData.Footer = "888";

            app.Groups.CheckAndCreateGroupIfItIsNotExist();

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

            app.Groups.UpdateGroup(newData, 0);
            app.Navigator.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach(GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

            app.Auth.Logout();
        }
    }
}