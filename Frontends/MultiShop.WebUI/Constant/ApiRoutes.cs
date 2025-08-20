namespace MultiShop.WebUI.Constant;

public static class ApiRoutes
{
    private const string IdentityBaseUrl = "http://localhost:5001/";
    private const string CatalogBaseUrl = "http://localhost:5150/";
    private const string CommentBaseUrl = "http://localhost:5151/";

    public static class Registers
    {
        private const string Prefix = $"{IdentityBaseUrl}api/Registers/";
        public const string Register = $"{Prefix}Register";
    }

    public static class Connect
    {
        private const string Prefix = $"{IdentityBaseUrl}Connect/";
        public const string Token = $"{Prefix}Token";
    }

    public static class Logins
    {
        private const string Prefix = $"{IdentityBaseUrl}api/Logins/";
        public const string Login = $"{Prefix}Login";
    }

    public static class Categories
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Categories/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class Contacts
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Contacts/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class Comments
    {
        private const string Prefix = $"{CommentBaseUrl}api/Comments/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
        public const string GetAllByProductId = $"{Prefix}GetAllByProductId";
    }

    public static class Brands
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Brands/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class Abouts
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Abouts/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class FeatureSliders
    {
        private const string Prefix = $"{CatalogBaseUrl}api/FeatureSliders/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class Products
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Products/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
        public const string GetAllWithCategory = $"{Prefix}GetAllWithCategory";
        public const string GetCountByCategoryId = $"{Prefix}GetCountByCategoryId";
        public const string GetAllWithCategoryByCategoryId = $"{Prefix}GetAllWithCategoryByCategoryId";
    }

    public static class SpecialOffers
    {
        private const string Prefix = $"{CatalogBaseUrl}api/SpecialOffers/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class Features
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Features/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }

    public static class OfferDiscounts
    {
        private const string Prefix = $"{CatalogBaseUrl}api/OfferDiscounts/";
        public const string GetAll = $"{Prefix}GetAll";
        public const string GetById = $"{Prefix}GetById";
        public const string Create = $"{Prefix}Create";
        public const string Update = $"{Prefix}Update";
        public const string Delete = $"{Prefix}Delete";
    }
}