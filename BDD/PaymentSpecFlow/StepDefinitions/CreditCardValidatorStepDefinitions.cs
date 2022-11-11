using OpenQA.Selenium;
using System.Text.RegularExpressions;
using WorkshopBDD.BaseClasses;
using WorkshopBDD.ComponentHelper;

namespace ProjetRenduFinal.StepDefinitions
{
    [Binding]
    public class CreditCardValidatorStepDefinitions
    {
        private static readonly Regex ExpDateRegex = new(@"^(0[1-9]|1[0-2])\/?([0-9]{4})$");

        private static void TestLengthAndAllDigits(int length, string value, bool isAssertTrue)
        {
            bool condition = value.Length == length && value.All(char.IsDigit);

            if (isAssertTrue)
                Assert.IsTrue(condition);
            else
                Assert.IsFalse(condition);
        }

        [Given(@"user fills the three inputs")]
        public static void GivenUserFillsTheThreeInputs()
        {
            Dictionary<string, string> inputValues = new()
            {
                { "creditCardNumber", ObjectRepository.Config.GetValidCreditCardNumber()},
                { "expirationDate", ObjectRepository.Config.GetValidExpirationDate() },
                { "cvc", ObjectRepository.Config.GetValidCvc() }
            };

            foreach (string id in inputValues.Keys)
                TextBoxHelper.TypeInTextBox(By.Id(id), inputValues[id]);
        }

        [Given(@"credit card number is sixteen digits long")]
        public static void GivenCreditCardNumberIsSixteenDigitsLong()
        {
            string value = GenericHelper.GetElement(By.Id("creditCardNumber")).GetAttribute("value");
            TestLengthAndAllDigits(16, value, true);
        }

        [Given(@"expiration date is at format MM/YYYY")]
        public static void GivenExpirationDateIsAtFormatMMYYYY()
        {
            string value = GenericHelper.GetElement(By.Id("expirationDate")).GetAttribute("value");
            Assert.IsTrue(ExpDateRegex.IsMatch(value));
        }

        [Given(@"cvc is three digits long")]
        public static void GivenCvcIsThreeDigitsLong()
        {
            string value = GenericHelper.GetElement(By.Id("cvc")).GetAttribute("value");
            TestLengthAndAllDigits(3, value, true);
        }

        [When(@"submit button is pressed")]
        public static void WhenSubmitButtonIsPressed()
        {
            ButtonHelper.ClickButton(By.Id("submitCard"));
        }

        [Then(@"user is on page paymentConfirmed")]
        public static void ThenUserIsOnPagePaymentConfirmed()
        {
            NavigationHelper.NavigateToUrl("http://localhost/paymentExam/paymentConfirmed.html");
            /*
            Another way to test
            Assert.AreEqual(PageHelper.GetPageTitle(), "Payment confirmed");
            */
        }

        [Given(@"credit card number is not sixteen digits long")]
        public static void GivenCreditCardNumberIsNotSixteenDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"), ObjectRepository.Config.GetInvalidCreditCardNumber());

            string value = GenericHelper.GetElement(By.Id("creditCardNumber")).GetAttribute("value");
            TestLengthAndAllDigits(16, value, false);
        }

        [Then(@"user is on homePage")]
        public static void ThenUserIsOnHomePage()
        {
            NavigationHelper.NavigateToHomePage();
        }

        [Given(@"expiration date is not at format MM/YYYY")]
        public static void GivenExpirationDateIsNotAtFormatMMYYYY()
        {
            TextBoxHelper.TypeInTextBox(By.Id("expirationDate"), ObjectRepository.Config.GetInvalidExpirationDate());

            string value = GenericHelper.GetElement(By.Id("expirationDate")).GetAttribute("value");
            Assert.IsFalse(ExpDateRegex.IsMatch(value));
        }

        [Given(@"cvc is not three digits long")]
        public static void GivenCvcIsNotThreeDigitsLong()
        {
            TextBoxHelper.TypeInTextBox(By.Id("cvc"), ObjectRepository.Config.GetInvalidCvc());

            string value = GenericHelper.GetElement(By.Id("cvc")).GetAttribute("value");
            TestLengthAndAllDigits(3, value, false);
        }
    }
}