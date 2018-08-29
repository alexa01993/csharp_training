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
            ContactData newDataC = new ContactData("Monica", "Geller", "5 avenue", "7657675", "00978", "777");
            //newDataC.Middlename = null;
            //newDataC.Lastname = "Geller";
            //newDataC.Nickname = "Cool";
            //newDataC.Address = "5 Avenue";
            //newDataC.Homephone = "555-543-8";
            //newDataC.Mobilephone = "+453443";
            //newDataC.Byear = null;

            ContactData contact = new ContactData("Anna", "Terentieva", "popova", "7657675", "00978", "777");
            //contact.Middlename = "Aleksandrovna";
            //contact.Lastname = "Terentieva";

            app.Navigator.GoToHomeTab();
            if (!app.Contacts.IsContactExist())
            {
                app.Contacts.Create(contact);
            }
            List<ContactData> oldContacts = app.Contacts.GetContactList();
            ContactData oldData = oldContacts[0];

            app.Contacts.Modify(contact, 0, newDataC);

            Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Name = newDataC.Name;
            oldContacts[0].Lastname = newDataC.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contactM in newContacts)
            {
                if (contactM.Id == oldData.Id)
                {
                    Assert.AreEqual(newDataC.Name, contactM.Name);
                }
            }
        }
    }
}
