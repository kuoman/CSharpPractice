using System.Collections.Generic;
using System.Linq;
using MapperRefactor.DataBags;
using MapperRefactor.DataBags.Results;

namespace CodeKatas.Refactor___Live
{
    public class Mapper
    {
        public static ProviderSearchResults Transform(VitalsProviderSearch sourceData)
        {
            ProviderSearchResults newResult = new ProviderSearchResults();
            if (sourceData?._meta?.pages != null)
            {
                newResult.pages.total = sourceData._meta.pages.total;
                newResult.pages.current = sourceData._meta.pages.current;
            }

            if (sourceData?.providers == null) return newResult;
            foreach (var sourceProvider in sourceData.providers)
            {
                MapperRefactor.DataBags.Results.Address sourceProviderFirstLocationAddress = null;
                string phoneNumber = null;

                if (sourceProvider.locations != null && sourceProvider.locations.Count > 0)
                {
                    sourceProviderFirstLocationAddress = new MapperRefactor.DataBags.Results.Address();
                    sourceProviderFirstLocationAddress.addr_line1 = sourceProvider.locations[0].address?.addr_line1;
                    sourceProviderFirstLocationAddress.addr_line2 = sourceProvider.locations[0].address?.addr_line2;
                    sourceProviderFirstLocationAddress.city = sourceProvider.locations[0].address?.city;
                    sourceProviderFirstLocationAddress.state_code = sourceProvider.locations[0].address?.state_code;
                    sourceProviderFirstLocationAddress.sub_national = sourceProvider.locations[0].address?.sub_national;
                    sourceProviderFirstLocationAddress.county = sourceProvider.locations[0].address?.county;
                    sourceProviderFirstLocationAddress.country_code = sourceProvider.locations[0].address?.country_code;
                    sourceProviderFirstLocationAddress.postal_code = sourceProvider.locations[0].address?.postal_code;
                    sourceProviderFirstLocationAddress.latitude = sourceProvider.locations[0].address?.latitude;
                    sourceProviderFirstLocationAddress.longitude = sourceProvider.locations[0].address?.longitude;

                    phoneNumber = sourceProvider.locations?[0]?.phones?.voice?[0]?.number;
                }

                var provider = new MapperRefactor.DataBags.Results.Provider();
                provider.id = sourceProvider.id;
                provider.name = sourceProvider.name;
                provider.gender = sourceProvider.gender;
                provider.degrees = new List<string>();
                provider.languages = new List<string>();
                provider.address = sourceProviderFirstLocationAddress;
                provider.phone_number = phoneNumber;
                provider.affiliations = new List<string>();
                provider.specialties = new List<string>();
                provider.awards = new List<string>();

                if (sourceProvider.degrees != null)
                {
                    foreach (var degree in sourceProvider.degrees)
                    {
                        provider.degrees.Add(degree);
                    }
                }

                if (sourceProvider.languages != null)
                {
                    foreach (var lang in sourceProvider.languages)
                    {
                        provider.languages.Add(lang.name);
                    }
                }

                if (sourceProvider.locations != null)
                {
                    Location location = sourceProvider.locations.FirstOrDefault();

                    if (location?.contracts != null && location.contracts.Count > 0 && location.contracts[0].hospital_affiliations != null)
                    {
                        foreach (var affiliation in location.contracts[0].hospital_affiliations)
                        {
                            provider.affiliations.Add(affiliation.name);
                        }
                    }

                    if (sourceProvider.type == "F")
                    {
                        if (location != null)
                        {
                            if (location.contracts?[0].specializations != null)
                            {
                                foreach (var specialization in location.contracts[0].specializations)
                                {
                                    if (specialization.field_specialty != null)
                                    {
                                        provider.specialties.Add(specialization.field_specialty.name);
                                    }
                                }
                            }

                            if (sourceProvider.bdc?.bdtc != null)
                            {
                                foreach (var award in location.bdc.bdtc)
                                {
                                    if (award != null)
                                    {
                                        provider.awards.Add(award.name);
                                    }
                                }
                            }
                        }
                    }
                }

                if (sourceProvider.type == "P")
                {
                    if (sourceProvider.specializations != null)
                    {
                        foreach (var specialization in sourceProvider.specializations)
                        {
                            if (specialization.field_specialty != null)
                            {
                                provider.specialties.Add(specialization.field_specialty.name);
                            }
                        }
                    }

                    if (sourceProvider.bdc?.bdtc != null)
                    {
                        foreach (var award in sourceProvider.bdc.bdtc)
                        {
                            if (award != null)
                            {
                                provider.awards.Add(award.name);
                            }
                        }
                    }
                }

                newResult.providers.Add(provider);
            }

            return newResult;
        }
    }
}

