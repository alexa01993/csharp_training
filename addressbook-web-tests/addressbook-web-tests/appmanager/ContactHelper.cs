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
        protected bool acceptNextAlert;

        public ContactHelper(ApplicationManager manager) 
            : base(manager)
        {

        }

        
        public ContactHelper Create(ContactData contact)
        {
            
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitGroupOrContactCreation();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Modify(ContactData contact, int p, int contactdefine, ContactData newDataC)
        {
            manager.Navigator.GoToHomeTab();
          
            SelectContact(p);
            InitContactModification(contactdefine);
            FillContactForm(newDataC);
            SubmitContactModification();

            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public bool IsContactExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper Remove(ContactData contact, int p)
        {
            manager.Navigator.GoToHomeTab();
            
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

        
        public ContactHelper SubmitGroupOrContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public ContactHelper SelectContact(int number)
        {
            driver.FindElement(By.Id(number.ToString())).Click();
            return this;
        }

        public ContactHelper CheckforRemoving()
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
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
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int contactdefine)
        {
            driver.FindElement(By.XPath("(//img[@alt='Edit'])[" + contactdefine + "]")).Click();
            return this;
        }
    }
}
