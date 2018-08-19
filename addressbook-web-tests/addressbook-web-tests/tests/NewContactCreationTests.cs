using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressBookTests
{
    [TestFixture]
    public class NewContactCreationTests : AuthTestBase
    {
        [Test]
        public void NewContactCreation()
        {
            
            ContactData contact = new ContactData("Anna");
            //contact.Middlename = "Aleksandrovna";
            contact.Lastname = "Terentieva";
            //contact.Nickname = "Kim";
            //contact.Address = "Popova street, 5";
            //contact.Homephone = "559-779-8";
            //contact.Mobilephone = "+79859874545";
            //contact.Byear = "1996";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
                        
            //LogOut();
        }

        [Test]
        public void EmptyContactCreation()
        {

            ContactData contact = new ContactData("");
            //contact.Middlename = "";
            contact.Lastname = "";
            //contact.Nickname = "";
            //contact.Address = "";
            //contact.Homephone = "";
            //contact.Mobilephone = "";
            //contact.Byear = "";

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Create(contact);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            //LogOut();
        }
    }
}

