using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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

            if (!app.Groups.IsGroupExist())
            {
                app.Groups.Create(group);
            }
            app.Groups.Remove(group, 1);
        }
    }
}
