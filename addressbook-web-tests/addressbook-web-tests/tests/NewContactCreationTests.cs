using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System.Collections.Generic;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class NewContactCreationTests : AuthTestBase
    {
        [Test]
        public void NewContactCreation()
        {
            
            ContactData contact = new ContactData("Anna", "Terentieva", "popova street 2", "559668", "8978568", "654654");
            //contact.Middlename = "Aleksandrovna";
            //contact.Lastname = "Terentieva";
            //contact.Nickname = "Kim";
            //contact.Middlename = "Popova street, 5";
            //contact.Homephone = "559-779-8";
            //contact.Mobilephone = "+79859874545";
            //contact.Byear = "1996";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            
            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void EmptyContactCreation()
        {

            ContactData contact = new ContactData("", "", "", "", "", "");
            //contact.Middlename = "";
            //contact.Lastname = "";
            //contact.Nickname = "";
            //contact.Middlename = "";
            //contact.Homephone = "";
            //contact.Mobilephone = "";
            //contact.Byear = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
            //LogOut();
        }
    }
}

