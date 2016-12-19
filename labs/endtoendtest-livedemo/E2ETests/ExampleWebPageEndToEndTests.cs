using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Linq;
using System.Threading;

namespace E2ETests
{
    [TestFixture]
    public class ExampleWebPageEndToEndTests
    {
        private IWebDriver _Driver;

        private IWebElement SearchButton
        {
            get { return _Driver.FindElement(By.ClassName("topbar-icons")); }
        }

        private IWebElement SearchField
        {
            get { return _Driver.FindElement(By.Id("edit-keys")); }
        }

        public static IWebDriver CreateChromeDriver()
        {
            return new ChromeDriver(ChromeDriverService.CreateDefaultService(), ChromeOptions());
        }

        [Test]
        public void GotoPratoSite_SearchForDeveloper_ShouldFindVacancies()
        {
            _Driver.Navigate().GoToUrl("http://www.prato-services.eu");
            SearchButton.Click();
            Thread.Sleep(1000);
            SearchField.SendKeys("developer");
            SearchField.SendKeys(Keys.Enter);
            var links = _Driver.FindElement(By.CssSelector("ol")).FindElements(By.CssSelector("a"));

            Assert.That(links.Any(), Is.True);
            Assert.That(links.Select(link => link.Text).ToList(), Contains.Item("Stagiair(e) Developer"));
        }

        [SetUp]
        public void SetUpDriver()
        {
            _Driver = CreateChromeDriver();
            _Driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 0, 500));
        }

        [TearDown]
        public void TearDownDriver()
        {
            if (_Driver != null)
            {
                _Driver.Close();
            }
        }

        private static ChromeOptions ChromeOptions()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("start-maximized");
            chromeOptions.AddArgument("disable-popup-blocking");
            chromeOptions.AddArgument("disable-translate");
            chromeOptions.AddArgument("ignore-certificate-errors");
            chromeOptions.AddArgument("no-sandbox");
            return chromeOptions;
        }
    }
}