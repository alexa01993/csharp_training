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

            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(group);
            }
            app.Groups.Modify(group, 1, newDataG);

        }
    }
}
