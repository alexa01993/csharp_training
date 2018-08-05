﻿using System;
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
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();
            GroupData group = new GroupData("Family");
            group.Header = "HoleyWel";
            group.Footer = "street";
            FillGroupFrom(group);
            SubmitGroupOrContactCreation();
            GoBackToGroupsPage();
        }
    }
}
