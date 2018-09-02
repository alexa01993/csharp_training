using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        protected bool acceptNextAlert = true;

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {

        }

        

        public ContactHelper Create(ContactData contact)
        {
            
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact, int contactdefine, ContactData newDataC)
        {
                      
            //SelectContact(p);
            InitContactModification(contactdefine);
            FillContactForm(newDataC);
            SubmitContactModification();

            manager.Navigator.ReturnToHomePage();
            return this;
        }

        
        private List<ContactData> contactCache = null;

        
        public List<ContactData> GetContactList()
        {
            if (contactCache == null)
            {
                contactCache = new List<ContactData>();
                manager.Navigator.GoToHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    IWebElement lastname = cells[1];
                    IWebElement name = cells[2];
                                       
                    contactCache.Add(new ContactData(name.Text, lastname.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    });
                }
            }
            return new List<ContactData>(contactCache);
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.Name("entry")).Count;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper Remove(ContactData contact, int p)
        {
            
            
            SelectContact(p);
            RemoveContact();
            CheckforRemoving();
            manager.Navigator.GoToHomeTab();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Name);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.HomePhone);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            return this;
        }

        
        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SelectContact(int number)
        {
            driver.FindElement(By.Id(number.ToString())).Click();
            return this;
            //driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + number + "]")).Click();
            //return this;
        }

        public ContactHelper CheckforRemoving()
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
           // IAlert alert = driver.SwitchTo().Alert();
            return this;
        }

        public string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper InitContactModification(int contactdefine)
        {
            //driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + contactdefine + "]")).Click();
            driver.FindElements(By.Name("entry"))[contactdefine]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
            return this;
        }

        public ContactData GetContactInformationFromTable(int contactdefine)
        {
            //manager.Navigator.GoToHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[contactdefine]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string emails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstName, lastName)
            {
                Address = address,
                Emails = emails,
                AllPhones = allPhones,
                
            };

        }

        public ContactData GetContactInformationFromEditForm(int contactdefine)
        {
            //manager.Navigator.GoToHomePage();
            InitContactModification(contactdefine);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3,
            };
            
        }

        public ContactData GetContactInformationFromDetails(int contactdefine)
        {
            manager.Navigator.GoToHomePage();
            ContactDetails(contactdefine);
            string contactInformationDetails = driver.FindElement(By.Id("content")).Text.Replace(" ", "").Replace("\r\n", "");
            return new ContactData()
            {
                ContactInformationDetails = contactInformationDetails
            };
            
        }

        public ContactHelper ContactDetails(int contactdefine)
        {
            driver.FindElements(By.Name("entry"))[contactdefine]
                .FindElements(By.TagName("td"))[6]
                .FindElement(By.TagName("a")).Click();
            return this;
        }


        public int GetNumberOfSearchResults()
        {
            //manager.Navigator.GoToHomePage();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public ContactHelper FillSearchField(string searchElement)
        {
            driver.FindElement(By.Name("searchstring")).Click();
            driver.FindElement(By.Name("searchstring")).SendKeys(searchElement);
            return this;
        }
    }
}
