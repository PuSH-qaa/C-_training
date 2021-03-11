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
            GroupData newData = new GroupData("000");
            newData.Header = "999";
            newData.Footer = "888";

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.CheckAndCreateGroupIfItIsNotExist();

            app.Groups.UpdateGroup(newData, 0);
            app.Navigator.ReturnToGroupsPage();
            
            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups, newGroups);

            app.Auth.Logout();
        }
    }
}