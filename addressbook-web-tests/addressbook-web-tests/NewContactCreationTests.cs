using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class NewContactCreationTests : TestBase
    {
        [Test]
        public void NewContactCreation()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            ContactData contact = new ContactData("Anna");
            contact.Middlename = "Aleksandrovna";
            contact.Lastname = "Terentieva";
            contact.Nickname = "Kim";
            contact.Middlename = "Popova street, 5";
            contact.Homephone = "559-779-8";
            contact.Mobilephone = "+79859874545";
            contact.Byear = "1996";
            FillContactForm(contact);
            SubmitGroupOrContactCreation();
            ReturnToHomePage();
            //LogOut();
        }
    }
}

