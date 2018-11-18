using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace MapperRefactor.DataBags.Results
{
    public class ProviderSearchResults
    {
        public Pages pages { get; set; }
        public List<Provider> providers { get; set; }

        public ProviderSearchResults()
        {
            pages = new Pages();
            providers = new List<Provider>();
        }
    }
    public class Pages
    {
        public int total { get; set; }
        public int current { get; set; }
    }

    public class Address
    {
        public string addr_line1 { get; set; }
        public string addr_line2 { get; set; }
        public string city { get; set; }
        public string state_code { get; set; }
        public string sub_national { get; set; }
        public string county { get; set; }
        public string country_code { get; set; }
        public string postal_code { get; set; }
        public double? latitude { get; set; }
        public double? longitude { get; set; }
    }

    public class Provider
    {
        public int id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public List<string> degrees { get; set; }
        public List<string> languages { get; set; }
        public Address address { get; set; }
        public string phone_number { get; set; }
        public List<string> affiliations { get; set; }
        public List<string> specialties { get; set; }
        public List<string> awards { get; set; }
    }
}