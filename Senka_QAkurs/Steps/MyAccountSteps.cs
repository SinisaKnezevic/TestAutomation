using NUnit.Framework;
using Senka_QAkurs.Helpers;
using Senka_QAkurs.Pages;
using System;
using TechTalk.SpecFlow;

namespace Senka_QAkurs.Steps
{
    [Binding]
    public class MyAccountSteps : Base
    {
        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.ClickOnElement(hp.SignIn);

        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.username, TestConstants.Username);
            ut.EnterTextInElement(ap.password, TestConstants.Password);
        }
        
        [StepDefinition(@"user submits the login form")]
        public void WhenUserSubmitsTheLoginForm()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signInBtn);
        }
        [When(@"user opens my wishlist")]
        public void WhenUserOpensMyWishlist()
        {
            Utilities ut = new Utilities(Driver);
            MyAccountPage ma = new MyAccountPage(Driver);
            ut.ClickOnElement(ma.wishlist);
        }


        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Utilities ut = new Utilities(Driver);
            MyAccountPage ma = new MyAccountPage(Driver);
            Assert.True(ut.ElementDisplayed(ma.logout), "User is not logged in");
        }

        [Then(@"user can add new wishlist")]
        public void ThenUserCanAddNewWishlist()
        {
            Utilities ut = new Utilities(Driver);
            MyWishlistPage ma = new MyWishlistPage(Driver);
            Assert.True(ut.ElementDisplayed(ma.newWish), "User isn't on wishlist page");
        }
        [Given(@"initiates a flow for creating an acount")]
        public void GivenInitiatesAFlowForCreatingAnAcount()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            string email = ut.GenerateRandomEmail();
            ut.EnterTextInElement(ap.emailField, email);
            ut.ClickOnElement(ap.createAcc);
        }
        [Given(@"user enters all required personal details")]
        public void GivenUserEntersAllRequiredPersonalDetails()
        {
            Utilities ut = new Utilities(Driver);
            SignUpPage sup = new SignUpPage(Driver);
            ut.EnterTextInElement(sup.firstName, TestConstants.FirstName);
            ut.EnterTextInElement(sup.lastName, TestConstants.LastName);
            string fullname = TestConstants.FirstName + " " +TestConstants.LastName;
            ScenarioContext.Current.Add(TestConstants.FullName, fullname);
            ut.EnterTextInElement(sup.password, TestConstants.Password);
            ut.EnterTextInElement(sup.fistNameAddress, TestConstants.FirstName);
            ut.EnterTextInElement(sup.lastNameAddress, TestConstants.LastName);
            ut.EnterTextInElement(sup.address, TestConstants.Address);
            ut.EnterTextInElement(sup.city, TestConstants.City);
            ut.DropdownSelect(sup.state, TestConstants.State);
            ut.EnterTextInElement(sup.zipPostalCode, TestConstants.ZipCode);
            ut.EnterTextInElement(sup.mobile, TestConstants.MobilePhone);
            ut.EnterTextInElement(sup.addressAlias, TestConstants.AddressAlias);
        }
        [When(@"submits the sign up form")]
        public void WhenSubmitsTheSignUpForm()
        {
            Utilities ut = new Utilities(Driver);
            SignUpPage sup = new SignUpPage(Driver);
            ut.ClickOnElement(sup.registerBtn);

        }

        [Then(@"user's full name is displayed")]
        public void ThenUserSFullNameIsDisplayed()
        {
            Utilities ut = new Utilities(Driver);
            string fullName = ScenarioContext.Current.Get<string>(TestConstants.FullName);
            Assert.True(ut.TextPresentInElement(fullName).Displayed, "User's full name is not displayed");
        }





    }
}
