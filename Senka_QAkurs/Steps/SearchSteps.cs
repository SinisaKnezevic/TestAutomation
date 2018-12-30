using NUnit.Framework;
using OpenQA.Selenium;
using Senka_QAkurs.Helpers;
using Senka_QAkurs.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Senka_QAkurs.Steps
{
    class SearchSteps : Base
    {
        [Given(@"user enters a '(.*)' search term")]
        public void GivenUserEntersASearchTerm(string termsearch)
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.EnterTextInElement(hp.search, termsearch);
        }

        [When(@"user submits the search")]
        public void WhenUserSubmitsTheSearch()
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.ClickOnElement(hp.searchBtn);
        }

        [Then(@"result for a '(.*)' search term are displayed")]
        public void ThenResultForASearchTermAreDisplayed(string title)
        {
            Utilities ut = new Utilities(Driver);
            SearchResults list = new SearchResults(Driver);
            //string results= ScenarioContext.Current.Get<string>(TestConstants.result);
            string res = ut.ReturnTextFromElement(list.res);
            Assert.That(res.Contains(title),  "Search results are not displayed");

        }

        [Then(@"every product contains '(.*)' in name")]
        public void ThenEveryProductContainsDressInName(string keyword)
        {
            Utilities ut = new Utilities(Driver);
            SearchResults srlp = new SearchResults(Driver);
            IList<IWebElement> results = Driver.FindElements(srlp.results);
            int ResultsCount = results.Count;
            for (int i = 0; i < ResultsCount - 1; i++)
            {
                string title = results[i].GetAttribute("title");
                Assert.True(title.Contains(keyword));
            }
        }



    }
}
