using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("Colleagues");
            group.Header = "Head";
            group.Footer = "Goal";

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Remove(group, 1);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
