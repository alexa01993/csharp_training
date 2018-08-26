using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Anna", "Terentieva");
            //contact.Middlename = "Aleksandrovna";
            //contact.Lastname = "Terentieva";

            app.Navigator.GoToHomeTab();
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }
            
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            app.Contacts.Remove(contact, 81);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.RemoveAt(0);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
