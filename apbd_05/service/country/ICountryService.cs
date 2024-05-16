using apbd_05.models;

namespace apbd_05.service.country;

public interface ICountryService
{
    IEnumerable<CountryDto> GetCountryDtos(IEnumerable<Country> countries);
}