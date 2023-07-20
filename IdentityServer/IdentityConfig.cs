﻿using IdentityServer.Configurations.Client;
using IdentityServer.Models.Constants;
using IdentityServer.Models.Enums;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public class IdentityConfig
    {
        public static IEnumerable<Client> Clients(ClientSettings settings)
        {
            return new Client[]
            {
                new Client
                {
                    ClientId = settings.MovieApiSettings.ClientId,
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret(settings.MovieApiSettings.ClientSecret.Sha512())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        ApprovedScopes.MovieApi.ToString()
                    }
                }
            };
        }
            

        public static IEnumerable<ApiScope> ApiScopes => 
            new ApiScope[] 
            { 
                new ApiScope(ApprovedScopes.MovieApi.ToString(), ScopeName.MovieApi)
            };

        public static IEnumerable<ApiResource> ApiResources =>
            new ApiResource[]
            {

            };

        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static List<TestUser> TestUsers =>
            new List<TestUser>
            {
                new TestUser
                {
                    SubjectId = "abc1",
                    Username = "Frank",
                    Password = "FrankPass",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Frank"),
                        new Claim("family_name", "Ozz")
                    } 
                },
                new TestUser
                {
                    SubjectId = "abc2",
                    Username = "Seros",
                    Password = "SerosPass",
                    Claims = new List<Claim>
                    {
                        new Claim("given_name", "Seros"),
                        new Claim("family_name", "Ozz")
                    }
                }
            };
    }
}
