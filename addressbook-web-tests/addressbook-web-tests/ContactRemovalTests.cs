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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToHomeTab();
            SelectContact();
            RemoveContact();
            CheckforRemoving();
            GoToHomeTab();
        }
    }
}
