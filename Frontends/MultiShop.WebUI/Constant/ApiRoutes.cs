namespace MultiShop.WebUI.Constant;

public static class ApiRoutes
{
    private const string IdentityBaseUrl = "http://localhost:5001/";
    private const string OcelotBaseUrl = "http://localhost:5000/";
    private const string CatalogService = $"{OcelotBaseUrl}services/catalog/";
    private const string CommentService = $"{OcelotBaseUrl}services/comment/";
    private const string BasketService = $"{OcelotBaseUrl}services/basket/";
    private const string DiscountService = $"{OcelotBaseUrl}services/discount/";
    private const string OrderService = $"{OcelotBaseUrl}services/order/";
    public static class Orderings
    {
        private const string Prefix = $"{OrderService}{nameof(Orderings)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
        public const string GetOrderingByUserId = $"{Prefix}{nameof(GetOrderingByUserId)}";
    }
    public static class OrderDetails
    {
        private const string Prefix = $"{OrderService}{nameof(OrderDetails)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }
    public static class Addresses
    {
        private const string Prefix = $"{OrderService}{nameof(Addresses)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }
    public static class Discounts
    {
        private const string Prefix = $"{DiscountService}{nameof(Discounts)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
        public const string GetCodeDetailByCode = $"{Prefix}{nameof(GetCodeDetailByCode)}";
    }

    public static class Baskets
    {
        private const string Prefix = $"{BasketService}{nameof(Baskets)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string SaveMyBasket = $"{Prefix}{nameof(SaveMyBasket)}";
        public const string DeleteMyBasket = $"{Prefix}{nameof(DeleteMyBasket)}";
        public const string AddBasketItem = $"{Prefix}{nameof(AddBasketItem)}";
        public const string RemoveBasketItem = $"{Prefix}{nameof(RemoveBasketItem)}";
        public const string UpdateQuantity = $"{Prefix}{nameof(UpdateQuantity)}";
    }

    public static class Users
    {
        private const string Prefix = $"{IdentityBaseUrl}api/{nameof(Users)}/";
        public const string GetUserInfo = $"{Prefix}{nameof(GetUserInfo)}";
    }

    public static class Registers
    {
        private const string Prefix = $"{IdentityBaseUrl}api/{nameof(Registers)}/";
        public const string Register = $"{Prefix}{nameof(Register)}";
    }

    public static class Logins
    {
        private const string Prefix = $"{IdentityBaseUrl}api/{nameof(Logins)}/";
        public const string Login = $"{Prefix}{nameof(Login)}";
    }

    public static class Connect
    {
        private const string Prefix = $"{IdentityBaseUrl}{nameof(Connect)}/";
        public const string Token = $"{Prefix}{nameof(Token)}";
    }

    public static class Categories
    {
        private const string Prefix = $"{CatalogService}{nameof(Categories)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class Contacts
    {
        private const string Prefix = $"{CatalogService}{nameof(Contacts)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class Abouts
    {
        private const string Prefix = $"{CatalogService}{nameof(Abouts)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class FeatureSliders
    {
        private const string Prefix = $"{CatalogService}{nameof(FeatureSliders)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class Features
    {
        private const string Prefix = $"{CatalogService}{nameof(Features)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class OfferDiscounts
    {
        private const string Prefix = $"{CatalogService}{nameof(OfferDiscounts)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class SpecialOffers
    {
        private const string Prefix = $"{CatalogService}{nameof(SpecialOffers)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class Comments
    {
        private const string Prefix = $"{CommentService}{nameof(Comments)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
        public const string GetAllByProductId = $"{Prefix}{nameof(GetAllByProductId)}";
    }

    public static class Brands
    {
        private const string Prefix = $"{CatalogService}{nameof(Brands)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
    }

    public static class Products
    {
        private const string Prefix = $"{CatalogService}{nameof(Products)}/";
        public const string GetAll = $"{Prefix}{nameof(GetAll)}";
        public const string GetById = $"{Prefix}{nameof(GetById)}";
        public const string Create = $"{Prefix}{nameof(Create)}";
        public const string Update = $"{Prefix}{nameof(Update)}";
        public const string Delete = $"{Prefix}{nameof(Delete)}";
        public const string GetAllWithCategory = $"{Prefix}{nameof(GetAllWithCategory)}";
        public const string GetCountByCategoryId = $"{Prefix}{nameof(GetCountByCategoryId)}";
        public const string GetAllWithCategoryByCategoryId = $"{Prefix}{nameof(GetAllWithCategoryByCategoryId)}";
    }
}