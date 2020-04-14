using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineStoresProject.Core;

namespace OnlineStores.PageObjects
{
    class HomePage
    {
        private readonly IWebDriver driver = null;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement MyAccount => driver.FindElement(By.LinkText("My Account"));

        private IWebElement Dismiss => driver.FindElement(By.LinkText("Dismiss"));

        private IWebElement UserName_txtBox => driver.FindElement(By.Name("username"));

        private IWebElement Passwd_txtBox => driver.FindElement(By.Name("password"));

        private IWebElement Login_btn => driver.FindElement(By.Name("login"));

        public void clickOnDismissButton()
        {
            Dismiss.Click();
        }

        public void clickOnMyAccountTab()
        {
            MyAccount.Click();
        }
        public void loginToApplicationWithCredentials(String username, String password)
        {
            UserName_txtBox.SendKeys(username);
            Passwd_txtBox.SendKeys(password);
            Login_btn.Click();
        }

    }
}
