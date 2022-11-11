using System;
using TechTalk.SpecFlow;

namespace SnekFlow.StepDefinitions
{
    [Binding]
    public class GameStartScenarioStepDefinitions
    {
        [Given(@"I am on the homepage")]
        public void GivenIAmOnTheHomepage()
        {
            throw new PendingStepException();
        }

        [Given(@"I fill in ""([^""]*)"" with ""([^""]*)""")]
        public void GivenIFillInWith(string p0, string p1)
        {
            throw new PendingStepException();
        }

        [Given(@"I click on ""([^""]*)""")]
        public void GivenIClickOn(string submitPlayers)
        {
            throw new PendingStepException();
        }

        [Then(@"I should be on the game page")]
        public void ThenIShouldBeOnTheGamePage()
        {
            throw new PendingStepException();
        }
    }
}
