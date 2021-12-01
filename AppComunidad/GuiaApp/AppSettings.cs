using System.Collections.Generic;

namespace GuiaApp
{
    public class AppSettings
    {
        public Authentication Authentication { get; set; }
    }

    public class Authentication
    {
        public AzureAdB2C AzureAdB2C { get; set; }
    }

    public class AzureAdB2C
    {
        public AzureAdB2CTenant Tenant { get; set; }
        public AzureAdB2CClient Client { get; set; }
        public IEnumerable<AzureAdB2CPolicy> Policies { get; set; }
        public AzureAdB2CApi Api { get; set; }

        public class AzureAdB2CTenant
        {
            public string Name { get; set; }
            public string Uri { get; set; }
        }
        public class AzureAdB2CClient
        {
            public string Id { get; set; }
            public string Secret { get; set; }
        }
        public class AzureAdB2CPolicy : GenericKeyName
        {
            public string RedirectUri { get; set; }
        }
        public class AzureAdB2CApi
        {
            public string AppIdUri { get; set; }
            public IEnumerable<AzureAdB2CApiScope> Scopes { get; set; }

            public class AzureAdB2CApiScope : GenericKeyName
            {

            }
        }

        public class GenericKeyName
        {
            public string KeyName { get; set; }
            public string Name { get; set; }
        }
    }

}
