using apbd_05.models;

namespace apbd_05.service;

public interface ITripService
{
    Task<IEnumerable<TripDto>> GetAllTrips();

    Task<Trip> GetTrip(int tripId, string tripName);
}