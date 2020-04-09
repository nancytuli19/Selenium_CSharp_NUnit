using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineStores.PageObjects
{
    class HomePage
    {
        private readonly IWebDriver driver = null;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement MyAccount => driver.FindElement(By.LinkText("My Account"));

        public IWebElement Dismiss => driver.FindElement(By.LinkText("Dismiss"));

        public IWebElement UserName_txtBox => driver.FindElement(By.Name("username"));

        public IWebElement Passwd_txtBox => driver.FindElement(By.Name("password"));

        public IWebElement Login_btn => driver.FindElement(By.Name("login"));

    }
}
