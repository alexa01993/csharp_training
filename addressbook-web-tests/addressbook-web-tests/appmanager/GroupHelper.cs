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
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            
            InitNewGroupCreation();
            FillGroupFrom(group);
            SubmitGroupOrContactCreation();

            manager.Navigator.GoBackToGroupsPage();
            return this;
        }

        

        public GroupHelper Modify(GroupData group, int v, GroupData newDataG)
        {
           
            SelectGroup(v);
            InitGroupModification();
            FillGroupFrom(newDataG);
            SubmitGroupModification();

            manager.Navigator.GoBackToGroupsPage();
            
            return this;
        }

        public bool IsGroupExist()
        {
            return IsElementPresent(By.Name("selected[]"));
        }

        public GroupHelper Remove(GroupData group, int v)
        {
                        
            SelectGroup(v);
            RemoveGroup();

            manager.Navigator.GoBackToGroupsPage();
            return this;
        }

        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupFrom(GroupData group)
        {
            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        public GroupHelper SubmitGroupOrContactCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }


        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.XPath("(//input[@name='delete'])[2]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigator.GoToGroupsPage();
            ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }
            return groups;
        }
    }
}
