using WorkshopBDD.Settings;

namespace WorkshopBDD.Interfaces
{
    public interface IConfig
    {
        public BrowserType GetBrowser();

        public string GetValidCreditCardNumber();

        public string GetValidExpirationDate();

        public string GetValidCvc();

        public string GetInvalidCreditCardNumber();

        public string GetInvalidExpirationDate();

        public string GetInvalidCvc();

        public string GetWebsite();
    }
}