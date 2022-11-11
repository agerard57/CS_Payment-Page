using System;
using System.Collections.Generic;
using System.Text;

namespace WorkshopBDD.Configuration
{
    public class GameSettings
    {
        public string Browser { get; set; }
        public string ValidCreditCardNumber { get; set; }
        public string ValidExpirationDate { get; set; }
        public string ValidCvc { get; set; }
        public string InvalidCreditCardNumber { get; set; }
        public string InvalidExpirationDate { get; set; }
        public string InvalidCvc { get; set; }
        public string Website { get; set; }
    }
}