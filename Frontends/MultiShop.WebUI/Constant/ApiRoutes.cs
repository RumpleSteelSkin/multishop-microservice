namespace MultiShop.WebUI.Constant;

public static class ApiRoutes
{
    private const string CatalogBaseUrl = "http://localhost:5150/";

    public static class Categories
    {
        private const string Prefix = $"{CatalogBaseUrl}api/Categories/";
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
    }
}