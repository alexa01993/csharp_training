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
    public class NavigationHelper : HelperBase
    {

        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) 
            : base(driver) 
        {          
            this.baseURL = baseURL;
        }

        public void GoToHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "addressbook/edit.php");
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoBackToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }

        public void ReturnToHomePage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
        }

        public void GoToHomeTab()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
    }
}
