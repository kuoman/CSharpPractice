using FluentAssertions;
using MapperRefactor.DataBags;
using MapperRefactor.DataBags.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Provider = CodeKatas.Provider;

namespace CodeKatas.Refactor___Live
{
    [TestClass]
    public class MappingTests
    {
        private static readonly string ProviderNameSearchVitalsJson = File.ReadAllText(@"..\..\Refactor - Mapper\testData.json");
        private VitalsProviderSearch _sourceData;

        [TestInitialize]
        public void TestSetup()
        {
            _sourceData = JsonConvert.DeserializeObject<VitalsProviderSearch>(ProviderNameSearchVitalsJson);
        }
        
        [TestMethod, TestCategory("Unit")]
        public void ShouldMapVitalsToProviderResultsForPages()
        {
            //arrange

            //act
            ProviderSearchResults result = Mapper.Transform(_sourceData);

            //assert
            _sourceData._meta.pages.total.Should().Be(result.pages.total);
            _sourceData._meta.pages.current.Should().Be(result.pages.current);
        }

        [TestMethod, TestCategory("Unit")]
        public void TestTransformEmptyVitalsSearch()
        {
            VitalsProviderSearch sourceData = new VitalsProviderSearch();
            ProviderSearchResults result = Mapper.Transform(sourceData);
        }

        [TestMethod, TestCategory("Unit")]
        public void TestTransformEmptyAddressForFirstProviderTypeP()
        {
            VitalsProviderSearch sourceData = new VitalsProviderSearch();
            sourceData.providers = new List<Provider> { new Provider() };
            sourceData.providers[0].type = "P";

            ProviderSearchResults result = Mapper.Transform(sourceData);

            result.providers[0].address.Should().BeNull();
        }

        [TestMethod, TestCategory("Unit")]
        public void TestTransformAddressForFirstProviderTypeP()
        {
            VitalsProviderSearch sourceData = new VitalsProviderSearch();
            sourceData.providers = new List<Provider> { new Provider() };
            sourceData.providers[0].type = "P";
            sourceData.providers[0].locations = new List<Location> { new Location(), new Location(), new Location() };
            sourceData.providers[0].locations[0].address = new Address() { addr_line1 = "123 main st" };
            ProviderSearchResults result = Mapper.Transform(sourceData);

            result.providers[0].address.addr_line1.Should().Be("123 main st");
        }

        [TestMethod, TestCategory("Unit")]
        public void TestTransformAffiliationsFirstProviderTypeFacility()
        {
            VitalsProviderSearch sourceData =
                new VitalsProviderSearch { providers = new List<Provider> { new Provider() } };
            sourceData.providers[0].type = "F";
            sourceData.providers[0].locations = new List<Location> { new Location() };
            sourceData.providers[0].locations[0].contracts = new List<Contract> { new Contract() };
            sourceData.providers[0].locations[0].contracts[0].hospital_affiliations =
                new List<HospitalAffiliation> { new HospitalAffiliation() { name = "foo" } };

            ProviderSearchResults result = Mapper.Transform(sourceData);

            result.providers[0].affiliations[0].Should().Be("foo");
        }

        [TestMethod, TestCategory("Unit")]
        public void TestTransformLanguagesForFirstProvider()
        {
            VitalsProviderSearch sourceData =
                new VitalsProviderSearch { providers = new List<Provider> { new Provider() } };
            sourceData.providers[0].languages = new List<Language> { new Language { name = "Esperanto" }, new Language { name = "Catalan" } };

            ProviderSearchResults result = Mapper.Transform(sourceData);

            result.providers[0].languages[0].Should().Be("Esperanto");
            result.providers[0].languages[1].Should().Be("Catalan");
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldMapVitalsToProviderResultsForFirstProvider()
        {
            //arrange

            //act
            ProviderSearchResults result = Mapper.Transform(_sourceData);

            //assert
            result.providers.Should().NotBeNull();
            result.providers.Count.Should().Be(2);
            MapperRefactor.DataBags.Results.Provider provider = result.providers[0];
            provider.id.Should().Be(1007346649);
            provider.name.Should().Be("Deana Marie Gazzola");
            provider.gender.Should().Be("F");
            provider.degrees.Count.Should().Be(1);
            provider.degrees[0].Should().Be("MD");
            provider.languages.Count.Should().Be(0);
            Address addr =
                new Address
                {
                    addr_line1 = "223 E 34th St",
                    addr_line2 = null,
                    city = "New York",
                    state_code = "NY",
                    sub_national = null,
                    county = "New York",
                    country_code = null,
                    postal_code = "10016",
                    latitude = 40.745324,
                    longitude = -73.976885
                };

            provider.address.ShouldBeEquivalentTo(addr);
            provider.phone_number.Should().Be("2122638710");
            provider.affiliations.Count.Should().Be(2);
            provider.affiliations[0].Should().Be("NYU Langone Medical Center");
            provider.affiliations[1].Should().Be("Hospital for Joint Diseases Orthopedic Institute");
            provider.specialties.Count.Should().Be(2);
            provider.specialties[0].Should().Be("Psychiatrist Pro");
            provider.specialties[1].Should().Be("Neurologist Pro");
            provider.awards.Count.Should().Be(0);
        }

        [TestMethod, TestCategory("Unit")]
        public void ShouldMapVitalsToProviderResultsForSecondProvider()
        {
            //arrange

            //act
            ProviderSearchResults result = Mapper.Transform(_sourceData);

            //assert
            result.providers.Should().NotBeNull();
            result.providers.Count.Should().Be(2);

            MapperRefactor.DataBags.Results.Provider provider = result.providers[1];
            provider.id.Should().Be(1007346793);
            provider.name.Should().Be("Erica K Kass");
            provider.gender.Should().Be("F");
            provider.degrees.Count.Should().Be(1);
            provider.degrees[0].Should().Be("MD");
            provider.languages.Count.Should().Be(0);
            Address addr =
                new Address
                {
                    addr_line1 = "3959 Broadway",
                    addr_line2 = null,
                    city = "New York",
                    state_code = "NY",
                    sub_national = null,
                    county = "New York",
                    country_code = null,
                    postal_code = "10032",
                    latitude = 40.839768,
                    longitude = -73.941483

                };

            provider.address.ShouldBeEquivalentTo(addr);
            provider.phone_number.Should().Be("2123055437");
            provider.affiliations.Count.Should().Be(0);
            provider.specialties.Count.Should().Be(2);
            provider.specialties.Count.Should().Be(2);
            provider.specialties[0].Should().Be("Neurologist");
            provider.specialties[1].Should().Be("Psychiatrist");
            provider.awards.Count.Should().Be(0);
        }

        [TestMethod]
        public void ShouldNotThrowGivenEmptyJsonString()
        {
            VitalsProviderSearch vitalsProviderSearch = JsonConvert.DeserializeObject<VitalsProviderSearch>("");
            ProviderSearchResults result = Mapper.Transform(vitalsProviderSearch);
        }

        [TestMethod]
        public void ShouldDeserializeProviderResultsFromVitals()
        {
            string jsonRaw = File.ReadAllText(@"..\..\Refactor - Mapper\testData.json");
            VitalsProviderSearch vitalsProviderSearch = JsonConvert.DeserializeObject<VitalsProviderSearch>(jsonRaw);
            ProviderSearchResults result = Mapper.Transform(vitalsProviderSearch);
        }

    }
}
