namespace MultiShop.WebUI.Constant;

public class ApiRoutes
{
    private const string CategoryBaseUrl = "http://localhost:5150/";

    public static class Categories
    {
        private const string Prefix = $"{CategoryBaseUrl}api/Categories/";
        public const string GetAll = $"{Prefix}GetAll";
    }
}