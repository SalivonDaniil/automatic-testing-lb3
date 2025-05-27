using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace lb3
{
    internal class TestClass
    {
        [Test]
        public void FalseBookOrdering()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost/VKR2/main.php");

            IWebElement search = driver.FindElement(By.Id("search"));
            search.SendKeys("Енеїда");
            driver.FindElement(By.ClassName("search_button")).Click();
            driver.FindElement(By.Id("mainbut_buying")).Click();
            Thread.Sleep(1000);

            String expectedAlert = "Потрібно увійти в акаунт.";
            String actualAlert = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual(expectedAlert, actualAlert);

            String expectedUrl = "http://localhost/VKR2/book.php";
            String actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);

            driver.Quit();
        }
        [Test]
        public void TrueBookOrdering()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost/VKR2/main.php");

            driver.FindElement(By.Id("login")).Click();
            IWebElement login = driver.FindElement(By.Name("log"));
            IWebElement password = driver.FindElement(By.Name("pass"));

            Thread.Sleep(1000);
            login.SendKeys("Alex12");
            password.SendKeys("12341234");
            driver.FindElement(By.Name("mainbut")).Click();

            Thread.Sleep(1000);
            IWebElement search = driver.FindElement(By.Id("search"));
            search.SendKeys("Енеїда");
            driver.FindElement(By.ClassName("search_button")).Click();
            driver.FindElement(By.Id("mainbut_buying")).Click();
            Thread.Sleep(1000);


            String expectedUrl = "http://localhost/VKR2/main.php";
            String actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);

            driver.Quit();
        }
        [Test]
        public void ExitingAccount()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost/VKR2/main.php");

            driver.FindElement(By.Id("login")).Click();
            IWebElement login = driver.FindElement(By.Name("log"));
            IWebElement password = driver.FindElement(By.Name("pass"));

            Thread.Sleep(1000);
            login.SendKeys("Alex12");
            password.SendKeys("12341234");
            driver.FindElement(By.Name("mainbut")).Click();
            driver.FindElement(By.Id("login")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("logout")).Click();
            Thread.Sleep(1000);

            String expectedUrl = "http://localhost/VKR2/main.php";
            String actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);

            driver.Quit();
        }
        [Test]
        public void Navigation()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost/VKR2/main.php");

            IWebElement nav = driver.FindElement(By.Id("menu_img"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(nav).Perform();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Поеми")).Click();
            Thread.Sleep(1000);

            String expectedUrl = "http://localhost/VKR2/poems.php";
            String actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);

            driver.Quit();
        }
        [Test]
        public void NavigationBookInteraction()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost/VKR2/main.php");

            IWebElement nav = driver.FindElement(By.Id("menu_img"));
            Actions actions = new Actions(driver);
            actions.MoveToElement(nav).Perform();
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Поеми")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.Id("Енеїда")).Click();
            Thread.Sleep(1000);

            String expectedUrl = "http://localhost/VKR2/book.php";
            String actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);

            driver.Quit();
        }
        [Test]
        public void InvalidEmailRegistration()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            driver.Navigate().GoToUrl("http://localhost/VKR2/main.php");

            driver.FindElement(By.Id("login")).Click();
            driver.FindElement(By.Id("mainbut2")).Click();

            IWebElement name = driver.FindElement(By.Name("name"));
            IWebElement email = driver.FindElement(By.Name("email"));
            IWebElement pass1 = driver.FindElement(By.Name("pass1"));
            IWebElement pass2 = driver.FindElement(By.Name("pass2"));

            name.SendKeys("Alex13");
            email.SendKeys("email");
            pass1.SendKeys("12341234");
            pass2.SendKeys("12341234");
            Thread.Sleep(1000);


            driver.FindElement(By.Id("mainbut2")).Click();
            Thread.Sleep(1000);
            

            String expectedAlert = "Потрібно ввести валідну електронну пошту";
            String actualAlert = driver.SwitchTo().Alert().Text;
            driver.SwitchTo().Alert().Accept();
            Assert.AreEqual(expectedAlert, actualAlert);

            String expectedUrl = "http://localhost/VKR2/registration.php";
            String actualUrl = driver.Url;
            Assert.AreEqual(expectedUrl, actualUrl);

            driver.Quit();
        }
    }
}