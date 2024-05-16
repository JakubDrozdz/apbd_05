using apbd_05.context;
using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.repository;

public class TripRepository(TripContext _tripContext) : ITripRepository
{
    public async Task<IEnumerable<TripDto>> GetAllTrips()
    {
        var trips = await _tripContext.Trips().Include(entity=>entity.ClientTrips).ToListAsync();
        List<TripDto> tripsDtos = new List<TripDto>();
        trips.ForEach(trip => tripsDtos.Add(TripDto.tripToTripDto(trip)));
        return tripsDtos;
    }
}