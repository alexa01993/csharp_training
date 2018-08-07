using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newDataC = new ContactData("Monica");
            newDataC.Middlename = "Lis";
            newDataC.Lastname = "Geller";
            newDataC.Nickname = "Cool";
            newDataC.Middlename = "5 Avenue";
            newDataC.Homephone = "555-543-8";
            newDataC.Mobilephone = "+453443";
            newDataC.Byear = "1976";

            app.Contacts.Modify(7, 7, newDataC);
        }
    }
}
