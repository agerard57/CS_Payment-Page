using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using WorkshopBDD.CustomExceptions;
using WorkshopBDD.Interfaces;
using WorkshopBDD.Settings;

namespace WorkshopBDD.Configuration
{
    public class ConfigReader : IConfig
    {
        private readonly GameSettings settings;

        public ConfigReader()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile(@"C:\Users\stagiaire\source\repos\WorkshopBDD\WorkshopBDD\appsetings.json")
                .AddEnvironmentVariables()
                .Build();

            settings = config.GetRequiredSection(nameof(GameSettings)).Get<GameSettings>();
        }

        public BrowserType GetBrowser()
        {
            string browser = settings.Browser;

            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (ArgumentException)
            {
                throw new NoSuitableDriverFound("Aucun driver n'a été trouvé  : " + settings.Browser);
            }
        }

        public string GetInvalidCreditCardNumber()
        {
            return settings.InvalidCreditCardNumber;
        }

        public string GetInvalidCvc()
        {
            return settings.InvalidCvc;
        }

        public string GetInvalidExpirationDate()
        {
            return settings.InvalidExpirationDate;
        }

        public string GetValidCreditCardNumber()
        {
            return settings.ValidCreditCardNumber;
        }

        public string GetValidCvc()
        {
            return settings.ValidCvc;
        }

        public string GetValidExpirationDate()
        {
            return settings.ValidExpirationDate;
        }

        public string GetWebsite()
        {
            return settings.Website;
        }
    }
}