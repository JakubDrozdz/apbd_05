using apbd_05.models;
using apbd_05.repository;
using apbd_05.service.country;

namespace apbd_05.service;

public class TripService(ITripRepository tripRepository, IClientService clientService, ICountryService countryService) : ITripService
{
    public async Task<IEnumerable<TripDto>> GetAllTrips()
    {
        var allTrips = await tripRepository.GetAllTripsOrderByFromDateDesc();
        List<TripDto> tripsDtos = new List<TripDto>();
        foreach (var trip in allTrips)
        {
            tripsDtos.Add(await PrepareTripDto(trip));
        }
        return tripsDtos;
    }

    public async Task<Trip> GetTrip(int tripId, string tripName)
    {
        return await tripRepository.GetTrip(tripId, tripName);
    }

    private async Task<TripDto> PrepareTripDto(Trip trip)
    {
        TripDto tripDto = new TripDto();
        tripDto.Name = trip.Name;
        tripDto.Description = trip.Description;
        tripDto.DateFrom = trip.DateFrom;
        tripDto.DateTo = trip.DateTo;
        tripDto.MaxPeople = trip.MaxPeople;
        foreach (var clientDto in await clientService.GetClientDtos(trip.ClientTrips))
        {
            tripDto.Clients.Add(clientDto);
        }
        foreach (var countryDto in countryService.GetCountryDtos(trip.IdCountries))
        { 
            tripDto.Countries.Add(countryDto);
        }
        return tripDto;
    }
}