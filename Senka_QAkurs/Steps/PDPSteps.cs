using NUnit.Framework;
using OpenQA.Selenium;
using Senka_QAkurs.Helpers;
using Senka_QAkurs.Pages;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace Senka_QAkurs.Steps
{
    [Binding]
    public class PDPSteps : Base
    {
        [Given(@"user open dresses section")]
        public void GivenUserOpenDressesSection()
        {
            HomePage hp = new HomePage(Driver);
            IList<IWebElement> dresses = Driver.FindElements(hp.dresses);
            dresses[1].Click();
        }
        
        [Given(@"opens first product from the list")]
        public void GivenOpensFirstProductFromTheList()
        {
            Utilities ut = new Utilities(Driver);
            PLPPage plp = new PLPPage(Driver);
            ut.ClickOnElement(plp.first);
        }
        
        [Given(@"increases quantity to (.*)")]
        public void GivenIncreasesQuantityTo(string qty)
        {
            Utilities ut = new Utilities(Driver);
            Driver.SwitchTo().Frame(Driver.FindElement(By.ClassName("fancybox-iframe")));
            PDPPage pdp = new PDPPage(Driver);
            Driver.FindElement(pdp.quantity).Clear();
            ut.EnterTextInElement(pdp.quantity, qty);
            string productName = ut.ReturnTextFromElement(pdp.productName);
            ScenarioContext.Current.Add(TestConstants.ProductName, productName);
        }
        
        [When(@"user clicks on add to cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            Utilities ut = new Utilities(Driver);
            PDPPage p = new PDPPage(Driver);
            ut.ClickOnElement(p.addButton);
            
        }

        [When(@"proceed to checkout")]
        public void WhenProceedToCheckout()
        {
            Utilities ut = new Utilities(Driver);
            ShoppingCartPage sp = new ShoppingCartPage(Driver);
            ut.ClickOnElement(sp.button);
        }


        [Then(@"product is added to the cart")]
        public void ThenProductIsAddedToTheCart()
        {
            Utilities ut = new Utilities(Driver);
            CartSummaryPage csp = new CartSummaryPage(Driver);
            string product = ScenarioContext.Current.Get<string>(TestConstants.ProductName);
            string name = ut.ReturnTextFromElement(csp.name);
            Assert.AreEqual(name, product, "Invalid checkout");
        }
    }
}
