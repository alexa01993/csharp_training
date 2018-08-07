using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class NewGroupCreationTests : TestBase
    {
        [Test]
        public void NewGroupCreation()
        {
            GroupData group = new GroupData("Family");
            group.Header = "HoleyWel";
            group.Footer = "street";

            app.Groups.Create(group);
        }

        [Test]
        public void EmptyGroupCreation()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            app.Groups.Create(group);
        }
    }
}
