using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources =>
        [
            new ApiResource("ResourceCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
            new ApiResource("ResourceDiscount") { Scopes = { "DiscountFullPermission" } },
            new ApiResource("ResourceOrder") { Scopes = { "OrderFullPermission" } },
            new ApiResource("ResourceCargo") { Scopes = { "CargoFullPermission" } },
            new ApiResource("ResourceBasket") { Scopes = { "BasketFullPermission" } },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        ];

        public static IEnumerable<IdentityResource> IdentityResources =>
        [
            new IdentityResources.OpenId(),
            new IdentityResources.Profile(),
            new IdentityResources.Email()
        ];

        public static IEnumerable<ApiScope> ApiScopes =>
        [
            new ApiScope("CatalogFullPermission", "Full access to Catalog"),
            new ApiScope("CatalogReadPermission", "Read access to Catalog"),
            new ApiScope("DiscountFullPermission", "Full access to Discount"),
            new ApiScope("OrderFullPermission", "Full access to Order"),
            new ApiScope("CargoFullPermission", "Full access to Cargo"),
            new ApiScope("BasketFullPermission", "Full access to Basket"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        ];

        public static IEnumerable<Client> Clients =>
        [
            new()
            {
                ClientId = "MultiShopVisitorId",
                ClientName = "Multi Shop Visitor User",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogReadPermission" }
            },
            new()
            {
                ClientId = "MultiShopManagerId",
                ClientName = "Multi Shop Manager User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes = { "CatalogFullPermission", "OrderFullPermission" }
            },
            new()
            {
                ClientId = "MultiShopAdminId",
                ClientName = "Multi Shop Admin User",
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets = { new Secret("multishopsecret".Sha256()) },
                AllowedScopes =
                {
                    "CatalogFullPermission",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CatalogReadPermission",
                    "CargoFullPermission",
                    "BasketFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.Profile,
                    IdentityServerConstants.StandardScopes.OpenId,
                },
                AccessTokenLifetime = 600
            }
        ];
    }
}