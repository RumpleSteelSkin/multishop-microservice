namespace MultiShop.RapidApi.WebUI.Models;

public class ExchangeViewModel
{
    public class RootObject
    {
        public string status { get; set; }
        public string request_id { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public string from_symbol { get; set; }
        public string to_symbol { get; set; }
        public string type { get; set; }
        public double exchange_rate { get; set; }
        public double previous_close { get; set; }
        public string last_update_utc { get; set; }
    }
}