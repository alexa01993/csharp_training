using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressBookTests
{
    [TestFixture]

    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationForEdit()
        {
            app.Navigator.GoToHomePage();
            app.Contacts.GetNumberOfSearchResults();
            app.Contacts.FillSearchField("G");
            app.Contacts.GetNumberOfSearchResults();

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(1);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(1);
                        
            //verify
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.Emails, fromForm.Emails);
        }
    

            [Test]
        public void TestContactInformationForPerson()
        {
            app.Navigator.GoToHomePage();

            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(1);
            app.Navigator.GoToHomePage();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(1);

            //verify
            Assert.AreEqual(fromDetails.ContactInformationDetails, fromForm.ContactInformationDetails);
        }
    }
}
