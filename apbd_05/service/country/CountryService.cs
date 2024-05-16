using apbd_05.models;

namespace apbd_05.service.country;

public class CountryService : ICountryService
{
    public IEnumerable<CountryDto> GetCountryDtos(IEnumerable<Country> countries)
    {
        List<CountryDto> countryDtos = new List<CountryDto>();
        foreach (var country in countries)
        {
            var countryDto = new CountryDto();
            countryDto.Name = country.Name;
            countryDtos.Add(countryDto);
        }

        return countryDtos;
    }
}