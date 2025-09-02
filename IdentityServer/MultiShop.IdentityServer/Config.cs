using IdentityServer4.Models;
using System.Collections.Generic;
using IdentityServer4;

namespace MultiShop.IdentityServer;

public static class Config
{
    public static IEnumerable<ApiResource> ApiResources =>
    [
        new("ResourceCatalog") { Scopes = { "CatalogFullPermission", "CatalogReadPermission" } },
        new("ResourceDiscount")
            { Scopes = { "DiscountFullPermission", "DiscountReadPermission", "DiscountHalfPermission" } },
        new("ResourceOrder") { Scopes = { "OrderFullPermission" } },
        new("ResourceCargo") { Scopes = { "CargoFullPermission" } },
        new("ResourceBasket") { Scopes = { "BasketFullPermission" } },
        new("ResourceComment")
            { Scopes = { "CommentFullPermission", "CommentHalfPermission", "CommentReadPermission" } },
        new("ResourcePayment") { Scopes = { "PaymentFullPermission" } },
        new("ResourceImages") { Scopes = { "ImagesFullPermission" } },
        new("ResourceOcelot") { Scopes = { "OcelotFullPermission" } },
        new("ResourceMessage")
            { Scopes = { "MessageFullPermission", "MessageReadPermission", "MessageHalfPermission" } },
        new(IdentityServerConstants.LocalApi.ScopeName)
    ];

    public static IEnumerable<IdentityResource> IdentityResources =>
    [
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResources.Email()
    ];

    public static IEnumerable<ApiScope> ApiScopes =>
    [
        new("CatalogFullPermission", "Full access to Catalog"),
        new("CatalogReadPermission", "Read access to Catalog"),
        new("DiscountFullPermission", "Full access to Discount"),
        new("DiscountHalfPermission", "Half access to Discount"),
        new("DiscountReadPermission", "Read access to Discount"),
        new("OrderFullPermission", "Full access to Order"),
        new("CargoFullPermission", "Full access to Cargo"),
        new("BasketFullPermission", "Full access to Basket"),
        new("OcelotFullPermission", "Full access to Ocelot"),
        new("PaymentFullPermission", "Full access to Payment"),
        new("ImagesFullPermission", "Full access to Images"),
        new("CommentFullPermission", "Full access to Comment"),
        new("CommentReadPermission", "Read access to Comment"),
        new("CommentHalfPermission", "Half access to Comment"),
        new("MessageFullPermission", "Full access to Message"),
        new("MessageHalfPermission", "Half access to Message"),
        new("MessageReadPermission", "Read access to Message"),
        new(IdentityServerConstants.LocalApi.ScopeName)
    ];

    public static IEnumerable<Client> Clients =>
    [
        new()
        {
            ClientId = "MultiShopVisitorId",
            ClientName = "Multi Shop Visitor User",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes =
            {
                "CatalogReadPermission", "OcelotFullPermission", "CommentReadPermission", "DiscountReadPermission",
                IdentityServerConstants.LocalApi.ScopeName,
            }
        },
        new()
        {
            ClientId = "MultiShopManagerId",
            ClientName = "Multi Shop Manager User",
            AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
            ClientSecrets = { new Secret("multishopsecret".Sha256()) },
            AllowedScopes =
            {
                "CatalogReadPermission", "OcelotFullPermission", "CommentHalfPermission", "BasketFullPermission",
                "DiscountHalfPermission", "MessageReadPermission", "MessageHalfPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OpenId,
            }
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
                "CargoFullPermission",
                "BasketFullPermission",
                "OcelotFullPermission",
                "CommentFullPermission",
                "ImagesFullPermission",
                "PaymentFullPermission",
                "MessageFullPermission",
                IdentityServerConstants.LocalApi.ScopeName,
                IdentityServerConstants.StandardScopes.Email,
                IdentityServerConstants.StandardScopes.Profile,
                IdentityServerConstants.StandardScopes.OpenId
            },
            AccessTokenLifetime = 600
        }
    ];
}