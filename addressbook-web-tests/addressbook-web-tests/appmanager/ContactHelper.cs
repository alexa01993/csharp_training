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

        public ContactHelper Modify(ContactData contact, int p, int contactdefine, ContactData newDataC)
        {
                      
            SelectContact(p);
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
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Homephone);
            Type(By.Name("mobile"), contact.Mobilephone);
            Type(By.Name("byear"), contact.Byear);
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
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + contactdefine + "]")).Click();
            return this;
        }
    }
}
