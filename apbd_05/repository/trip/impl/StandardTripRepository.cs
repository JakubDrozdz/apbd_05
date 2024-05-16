using apbd_05.context;
using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.repository;

public class StandardTripRepository(TripContext _tripContext) : ITripRepository
{
    public async Task<IEnumerable<Trip>> GetAllTripsOrderByFromDateDesc()
    {
        return await _tripContext.Trips()
            .Include(np=>np.ClientTrips)
            .Include(np => np.IdCountries)
            .OrderByDescending(x => x.DateFrom)
            .ToListAsync();
    }
}