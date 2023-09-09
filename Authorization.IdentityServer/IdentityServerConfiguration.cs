using System.Collections.Generic;
using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;

namespace Authorization.IdentityServer
{
    public static class IdentityServerConfiguration
    {
        public static IEnumerable<Client> GetClients() =>
        new List<Client>
        {
             new Client
            {
                ClientId = "client_id",
                ClientSecrets = { new Secret("client_secret".ToSha256()) },

                AllowedGrantTypes = GrantTypes.ClientCredentials,
                AllowedScopes =
                {
                    "DeliveryAPI"
                }
            },
new Client
{
    ClientId = "client_id_mvc",
    ClientSecrets = { new Secret("client_secret_mvc".ToSha256()) },

    AllowedGrantTypes = GrantTypes.Code, // Змінено на authorization_code
    AllowedScopes =
    {
        "DeliveryAPI",
        IdentityServerConstants.StandardScopes.OpenId,
        IdentityServerConstants.StandardScopes.Profile
    },
    RedirectUris = { "https://localhost:7279/signin-oidc" },
    RequirePkce = true, // Додано для використання PKCE
},


                // AlwaysIncludeUserClaimsInIdToken = true
            
        };


        public static IEnumerable<ApiResource> GetApiResources()
        {
            yield return new ApiResource("DeliveryAPI");
            
        }

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            yield return new IdentityResources.OpenId();
            yield return new IdentityResources.Profile();

        }


        /// <returns></returns>
        public static IEnumerable<ApiScope> GetApiScopes()
        {
            yield return new ApiScope("DeliveryAPI");
        }
    }
}
