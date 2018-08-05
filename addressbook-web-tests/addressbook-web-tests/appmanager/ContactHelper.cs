using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(IWebDriver driver) 
            : base(driver)
        {

        }
        
        public void InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Name);
            driver.FindElement(By.Name("middlename")).Clear();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Clear();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            driver.FindElement(By.Name("address")).Clear();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            driver.FindElement(By.Name("home")).Clear();
            driver.FindElement(By.Name("home")).SendKeys(contact.Homephone);
            driver.FindElement(By.Name("mobile")).Clear();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobilephone);
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys(contact.Byear);
        }
        public void SelectContact()
        {
            driver.FindElement(By.Id("6")).Click();
        }

        public void RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
        } 
    }
}
