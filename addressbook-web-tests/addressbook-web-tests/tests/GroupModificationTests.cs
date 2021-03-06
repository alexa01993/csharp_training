﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            app.Groups.Modify(group, 1, newDataG);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData groupM in newGroups)
            {
                if (groupM.Id == oldData.Id)
                {
                    Assert.AreEqual(newDataG.Name, groupM.Name);
                }
            }

        }
    }
}
