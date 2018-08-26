using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newDataG = new GroupData("Friends");
            newDataG.Header = null;
            newDataG.Footer = null;

            GroupData group = new GroupData("Colleagues");
            group.Header = "Head";
            group.Footer = "Goal";

            app.Navigator.GoToGroupsPage();
            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Modify(group, 1, newDataG);

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups[0].Name = newDataG.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
