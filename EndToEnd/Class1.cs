using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EndToEnd
{
    [TestFixture]
    public class Chrome_Sample_test
    {

        private IWebDriver driver;
        public string homeURL;

        [Test(Description = "Simulates a succesfull login")]
        public void Succesful_Login()
        {


            homeURL = "http://localhost:3000/login";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            driver.FindElement(By.Name("username")).SendKeys("elena");
            Thread.Sleep(3000);
            driver.FindElement(By.Name("password")).SendKeys("elena");
            Thread.Sleep(3000);
            driver.FindElement(By.TagName("button")).Click();
            Thread.Sleep(3000);
            IWebElement element = driver.FindElement(By.ClassName("navbar_list_link"));
            Assert.AreEqual("All Games", element.GetAttribute("text"));
            Thread.Sleep(5000);
            /*WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => driver.FindElement(By.XPath("/html/body/div/div/div/div/form/button")));
            IWebElement element = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/button"));
            Assert.AreEqual("Sign In", element.GetAttribute("text"));*/


        }



        [Test(Description = "Invalid login message")]
        public void InvalidLogin()
        {


            homeURL = "http://localhost:3000/login";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            driver.FindElement(By.Name("username")).SendKeys("elena");
            Thread.Sleep(3000);
            driver.FindElement(By.Name("password")).SendKeys("elena1");
            Thread.Sleep(3000);
            driver.FindElement(By.TagName("button")).Click();
            Thread.Sleep(3000);
            IWebElement element1 = driver.FindElement(By.ClassName("invalid-feedback"));
            Assert.AreEqual("Invalid password", element1.GetAttribute("text"));
            Thread.Sleep(3000);
            /*WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            wait.Until(driver => driver.FindElement(By.XPath("/html/body/div/div/div/div/form/button")));
            IWebElement element = driver.FindElement(By.XPath("/html/body/div/div/div/div/form/button"));
            Assert.AreEqual("Sign In", element.GetAttribute("text"));*/


        }

        [Test(Description = "Create a new account link")]
        public void NewAccount()
        {


            homeURL = "http://localhost:3000/login";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homeURL);
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            driver.FindElement(By.LinkText("Create a new account!")).Click();
            Thread.Sleep(3000);
            IWebElement element2 = driver.FindElement(By.LinkText("Back to login"));
            Assert.AreEqual("Back to login", element2.GetAttribute("text"));
            Thread.Sleep(3000);
        }


        [Test(Description = "LogoutTest")]
        public void Logout()
        {
            homeURL = "http://localhost:3000/login";
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(homeURL);
            WebDriverWait wait = new WebDriverWait(driver, System.TimeSpan.FromSeconds(15));
            driver.FindElement(By.Name("username")).SendKeys("elena");
            Thread.Sleep(3000);
            driver.FindElement(By.Name("password")).SendKeys("elena");
            Thread.Sleep(3000);
            driver.FindElement(By.TagName("button")).Click();
            Thread.Sleep(3000);
            driver.FindElement(By.ClassName("header-logout")).Click();
            Thread.Sleep(3000);
            IWebElement element = driver.FindElement(By.LinkText("Create a new account!"));
            Assert.AreEqual("Create a new account!", element.GetAttribute("text"));
   
        }






        [TearDown]
        public void TearDownTest()
        {
            driver.Close();
        }


        [SetUp]
        public void SetupTest()
        {
            homeURL = "http://localhost:3000/login";
            driver = new ChromeDriver();

        }


    }
}
