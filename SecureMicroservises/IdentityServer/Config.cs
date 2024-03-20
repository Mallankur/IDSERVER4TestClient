using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class Config
    {
        public static IEnumerable<Client> Clients =>

          new Client[]
          {
                new Client
                {
                    ClientId = "movieClient",
                     AllowedGrantTypes = GrantTypes.ClientCredentials,
                        ClientSecrets =
                        {
                            new Secret("ama".Sha256())
                        },
                        AllowedScopes = { "movieApi" }  

                }, 
              
               new Client
                {
                    ClientId = "movies_mvc_client",
                    ClientName = "Movies MVC Web App",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = false,
                    AllowRememberConsent = false,
                    RedirectUris = new List<string>
                    {
                        "https://localhost:7210/signin-oidc"
                    },
                    PostLogoutRedirectUris = new List<string>
                    {
                        "https://localhost:7210/signout-callback-oidc"
                    },
                    ClientSecrets = { new Secret("ama".Sha256()) },
                    AllowedScopes = new List<string>
                    {
                        "openid",
                        "profile",
                        "movieApi"
                    }
                }

          };
        public static IEnumerable<ApiScope> ApiScopes =>
              new ApiScope[]
              {
                       new ApiScope("movieApi", "Movie API")
              };

        public static IEnumerable<ApiResource> ApiResources =>
              new ApiResource[]
              {

              };
        public static IEnumerable<IdentityResource> IdentityResources =>
      new IdentityResource[]
      {
           new IdentityResources.OpenId(),
              new IdentityResources.Profile(),
              

      };


        public static List<TestUser> TestUser =>
            new List<TestUser>
            {
                 new TestUser
                {
                    SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
                    Username = "Ankur",
                    Password = "ama",
                    Claims = new List<Claim>
                    {
                        new Claim(JwtClaimTypes.GivenName, "ama"),
                        new Claim(JwtClaimTypes.FamilyName, "ama")
                    }
                }
            };


    }
}
