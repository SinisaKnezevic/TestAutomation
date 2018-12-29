using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senka_QAkurs.Pages
{
    class CartSummaryPage
    {
        readonly IWebDriver driver;

        public By name = By.CssSelector(".cart_description .product-name");
        public CartSummaryPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("order")));
        }
    }
}
