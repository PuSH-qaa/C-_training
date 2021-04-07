using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace Addressbook_web_tests
{
    [TestFixture]
    public class GroupUpdateTests : GroupTestBase
    {
 
        [Test]
        public void GroupUpdateTest()
        {
            GroupData newData = new GroupData("111");
            newData.Header = "999";
            newData.Footer = "888";

            app.Groups.CheckAndCreateGroupIfItIsNotExist();

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.UpdateGroup(newData, oldData);
            app.Navigator.ReturnToGroupsPage();

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();

            oldData.Name = newData.Name;
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

            //app.Auth.Logout();
        }
    }
}