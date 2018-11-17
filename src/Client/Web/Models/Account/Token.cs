using System;

namespace NetCore21Angular.Client.Web.Models.Account
{
    public class Token
    {
        public string Value { get; set; }

        public DateTime Expiry { get; set; }
    }
}