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
            app.Contacts.FillSearchField("w");
            app.Contacts.GetNumberOfSearchResults();

            ContactData fromTable = app.Contacts.GetContactInformationFromTable(2);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(2);
                        
            //verify
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    

            [Test]
        public void TestContactInformationForPerson()
        {
            app.Navigator.GoToHomePage();

            ContactData fromDetails = app.Contacts.GetContactInformationFromDetails(2);
            app.Navigator.GoToHomePage();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(2);

            //verify
            Assert.AreEqual(fromDetails.ContactInformationDetails, fromForm.ContactInformationDetails);
        }
    }
}
