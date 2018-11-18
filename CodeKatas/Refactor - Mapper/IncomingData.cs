using System.Collections.Generic;

// ReSharper disable InconsistentNaming - Json Mapping
#pragma warning disable IDE1006 // Naming Styles

namespace CodeKatas
{
    public class VitalsProviderSearch
    {
        public Meta _meta { get; set; }
        public List<Provider> providers { get; set; }
    }

    public class Pages
    {
        public int total { get; set; }
        public int current { get; set; }
    }

    public class Meta
    {
        public Pages pages { get; set; }
    }

    public class Bdc
    {
        public List<Bdtc> bdtc { get; set; }
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
        public double latitude { get; set; }
        public double longitude { get; set; }
    }

    public class Voice
    {
        public string number { get; set; }
    }

    public class Phones
    {
        public List<Voice> voice { get; set; }
    }

    public class Bdtc
    {
        public string name { get; set; }
    }

    public class HospitalAffiliation
    {
        public string name { get; set; }
    }

    public class FieldSpecialty
    {
        public string name { get; set; }
    }

    public class Specialization
    {
        public FieldSpecialty field_specialty { get; set; }
    }

    public class Contract
    {
        public List<HospitalAffiliation> hospital_affiliations { get; set; }
        public List<Specialization> specializations { get; set; }
    }

    public class Location
    {
        public Address address { get; set; }
        public Bdc bdc { get; set; }
        public Phones phones { get; set; }
        public List<Contract> contracts { get; set; }
    }

    public class Provider
    {
        public int id { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string gender { get; set; }
        public List<string> degrees { get; set; }
        public Bdc bdc { get; set; }
        public List<Language> languages { get; set; }
        public List<Location> locations { get; set; }
        public List<Specialization> specializations { get; set; }
    }

    public class Language
    {
        public string name { get; set; }
    }
}