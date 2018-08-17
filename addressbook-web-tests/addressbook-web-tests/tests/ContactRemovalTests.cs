using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Anna");
            contact.Middlename = "Aleksandrovna";
            contact.Lastname = "Terentieva";

            app.Contacts.Remove(contact, 31);
                      
        }
    }
}
