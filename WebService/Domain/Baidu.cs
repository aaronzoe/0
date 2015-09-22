namespace WebService.Domain
{
    public class Baidu
    {
        public class BaiduLocation
        {
            public string address { get; set; }
            public BaiduLContent content { get; set; }


        }

        public class BaiduLContent
        {
            public string address { get; set; }
            public address_detail address_detail { get; set; }
            public point point { get; set; }
        }

        public class address_detail
        {
            public string city { get; set; }
            public string city_code { get; set; }
            public string district { get; set; }
            public string province { get; set; }
            public string street { get; set; }
            public string street_number { get; set; }
        }

        public class point
        {
            public string x { get; set; }
            public string y { get; set; }
        }

        public class result
        {
            public string formatted_address { get; set; }
        }

        public class AddressNew
        {
            public result result { get; set; }
        }
    }
}