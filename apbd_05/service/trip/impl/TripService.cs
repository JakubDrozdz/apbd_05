using apbd_05.models;
using apbd_05.repository;

namespace apbd_05.service;

public class TripService(ITripRepository _tripRepository, IClientTripService _clientTripService) : ITripService
{
    public async Task<IEnumerable<TripDto>> GetAllTrips()
    {
        var allTrips = await _tripRepository.GetAllTripsOrderByFromDateDesc();
        List<TripDto> tripsDtos = new List<TripDto>();
        foreach (var trip in allTrips)
        {
            tripsDtos.Add(await prepareTripDto(trip));
        }
        return tripsDtos;
    }

    private async Task<TripDto> prepareTripDto(Trip trip)
    {
        TripDto tripDto = new TripDto();
        tripDto.Name = trip.Name;
        tripDto.Description = trip.Description;
        tripDto.DateFrom = trip.DateFrom;
        tripDto.DateTo = trip.DateTo;
        tripDto.MaxPeople = trip.MaxPeople;
        foreach (var clientDto in await _clientTripService.GetClientDtos(trip.IdTrip))
        {
            tripDto.Clients.Add(clientDto);
        }
        //tripDto.Countries = trip.IdCountries;
        return tripDto;
    }
}