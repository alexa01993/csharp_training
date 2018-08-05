using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToHomeTab();
            app.Contacts.SelectContact();
            app.Contacts.RemoveContact();
            CheckforRemoving();
            app.Navigator.GoToHomeTab();
        }
    }
}
