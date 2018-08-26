using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataC = new ContactData("Monica", "Geller");
            //newDataC.Middlename = null;
            //newDataC.Lastname = "Geller";
            //newDataC.Nickname = "Cool";
            //newDataC.Address = "5 Avenue";
            //newDataC.Homephone = "555-543-8";
            //newDataC.Mobilephone = "+453443";
            //newDataC.Byear = null;

            ContactData contact = new ContactData("Anna", "Terentieva");
            //contact.Middlename = "Aleksandrovna";
            //contact.Lastname = "Terentieva";

            app.Navigator.GoToHomeTab();
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(contact, 79, 1, newDataC);
            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Name = newDataC.Name;
            oldContacts[0].Lastname = newDataC.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
