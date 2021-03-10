﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            app.Groups.CheckAndCreateGroupIfItIsNotExist();

            app.Groups.UpdateGroup(newData, 0);
            app.Navigator.ReturnToGroupsPage();
            app.Auth.Logout();
        }
    }
}