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
    public class NewContactCreationTests : AuthTestBase
    {
        [Test]
        public void NewContactCreation()
        {
            
            ContactData contact = new ContactData("Anna");
            contact.Middlename = "Aleksandrovna";
            contact.Lastname = "Terentieva";
            contact.Nickname = "Kim";
            contact.Middlename = "Popova street, 5";
            contact.Homephone = "559-779-8";
            contact.Mobilephone = "+79859874545";
            contact.Byear = "1996";

            app.Contacts.Create(contact);
                        
            //LogOut();
        }

        [Test]
        public void EmptyContactCreation()
        {

            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            contact.Nickname = "";
            contact.Middlename = "";
            contact.Homephone = "";
            contact.Mobilephone = "";
            contact.Byear = "";

            app.Contacts.Create(contact);
                        
            //LogOut();
        }
    }
}

