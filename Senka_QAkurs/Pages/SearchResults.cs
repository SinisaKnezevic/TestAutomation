using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senka_QAkurs.Pages
{
    class SearchResults
    {
        readonly IWebDriver driver;
        public By res= By.ClassName("lighter");
        public By results = By.CssSelector(".product-name[itemprop='url']");
        public SearchResults(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("search")));
        }
    }
}
