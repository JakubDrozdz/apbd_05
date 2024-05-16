using apbd_05.models;
using apbd_05.repository;

namespace apbd_05.service;

public class TripService(ITripRepository _tripRepository) : ITripService
{
    public async Task<IEnumerable<TripDto>> GetAllTrips()
    {
        return await _tripRepository.GetAllTrips();
    }
}