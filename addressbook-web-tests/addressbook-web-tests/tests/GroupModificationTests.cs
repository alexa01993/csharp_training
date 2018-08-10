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

            app.Groups.Modify(1, newDataG);
        }
    }
}
