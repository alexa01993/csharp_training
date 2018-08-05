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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            GroupData group = new GroupData("Family");
            group.Header = "HoleyWel";
            group.Footer = "street";
            app.Groups.FillGroupFrom(group);
            app.Groups.SubmitGroupOrContactCreation();
            app.Navigator.GoBackToGroupsPage();
        }
    }
}
