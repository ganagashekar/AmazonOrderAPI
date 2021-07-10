using IdentityServer4;
using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmazonOrderAPI.Configuration
{
    internal class Clients
    {
        public static IEnumerable<Client> Get()
        {
            return new List<Client> {
                new Client {
                    ClientId = "Bombax",
                    ClientSecrets = new List<Secret> {
                        new Secret("bombax")},
                    ClientName = "Example Implicit Client Application",
                    AllowedGrantTypes = GrantTypes.Hybrid,
                    RequireConsent = false,
            AllowAccessTokensViaBrowser = true,
              AccessTokenType = AccessTokenType.Jwt,

              AllowOfflineAccess=true,

                    AllowedScopes = new List<string>
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.StandardScopes.Email,
                        "role",
                        //"customAPI.read",
                        //"customAPI.write"
                    },
                    //RedirectUris = new List<string> {"https://localhost:44316/signin-oidc"},
                    //PostLogoutRedirectUris = new List<string> { "https://localhost:44316/signout-callback-oidc" }
                },
            };
        }
    }

    internal class Resources
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource> {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile(),
                new IdentityResources.Email(),
                new IdentityResource {
                    Name = "role",
                    UserClaims = new List<string> {"role"}
                }
            };
        }

        public static IEnumerable<ApiResource> GetApiResources()
        {
            return new List<ApiResource> {
                //new ApiResource {
                //    Name = "api1",
                //    DisplayName = "Custom API",
                //    Description = "Custom API Access",
                //    UserClaims = new List<string> {"role"},
                //    ApiSecrets = new List<Secret> {new Secret("bombax")},
                //    Scopes = new List<Scope> {
                //        //new Scope("customAPI.read"),
                //        //new Scope("customAPI.write")
                //    },
                //},
                 new ApiResource("api1", "My API 1"),
                 //new ApiResource("my-api", "SignalR Test API")
            };
        }
    }

    //internal class Users
    //{
    //    public static List<TestUser> Get()
    //    {
    //        return new List<TestUser> {
    //            new TestUser {
    //                SubjectId = "5BE86359-073C-434B-AD2D-A3932222DABE",
    //                Username = "scott",
    //                Password = "password",
    //                Claims = new List<Claim> {
    //                    new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
    //                    new Claim(JwtClaimTypes.Role, "admin"),
    //                }
    //            },
    //            new TestUser {
    //                SubjectId = "5BE86359-073C-434B-AD2D-A3932Ganga",
    //                Username = "GangaShekar",
    //                Password = "Gangashekar",
    //                Claims = new List<Claim> {
    //                    new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
    //                    new Claim(JwtClaimTypes.Role, "admin"),
    //                new Claim(JwtClaimTypes.Name, "GangaShekar Adumulla"),
    //                new Claim(JwtClaimTypes.GivenName, "GangaShekar"),
    //                new Claim(JwtClaimTypes.FamilyName, "Smith"),

    //                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
    //                new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
    //                new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json),
    //                new Claim("location", "somewhere")
    //                }
    //            },

    //            new TestUser{SubjectId =Guid.NewGuid().ToString(), Username = "alice", Password = "alice",
    //            Claims =
    //            {
    //                new Claim(JwtClaimTypes.Name, "Alice Smith"),
    //                new Claim(JwtClaimTypes.GivenName, "Alice"),
    //                new Claim(JwtClaimTypes.FamilyName, "Smith"),
    //                new Claim(JwtClaimTypes.Email, "AliceSmith@email.com"),
    //                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
    //                new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
    //                new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json)
    //            }
    //        },
    //        new TestUser{SubjectId = "88421113", Username = "bob", Password = "bob",
    //            Claims =
    //            {
    //                new Claim(JwtClaimTypes.Name, "Bob Smith"),
    //                new Claim(JwtClaimTypes.GivenName, "Bob"),
    //                new Claim(JwtClaimTypes.FamilyName, "Smith"),
    //                new Claim(JwtClaimTypes.Email, "BobSmith@email.com"),
    //                new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
    //                new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
    //                new Claim(JwtClaimTypes.Address, @"{ 'street_address': 'One Hacker Way', 'locality': 'Heidelberg', 'postal_code': 69118, 'country': 'Germany' }", IdentityServerConstants.ClaimValueTypes.Json),
    //                new Claim("location", "somewhere")
    //            }
    //        },

    //            //new TestUser {
    //            //    SubjectId = "5BE86359-073C-434B-AD2D-A3932Shekar",
    //            //    Username = "Shekar",
    //            //    Password = "Shekar",
    //            //    Claims = new List<Claim> {
    //            //        new Claim(JwtClaimTypes.Email, "scott@scottbrady91.com"),
    //            //        new Claim(JwtClaimTypes.Role, "admin")
    //            //    }
    //            //}
    //        };
    //    }
    //}
}