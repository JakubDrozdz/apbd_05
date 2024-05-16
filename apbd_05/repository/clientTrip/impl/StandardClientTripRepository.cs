using apbd_05.context;
using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.repository;

public class StandardClientTripRepository(ClientTripContext _clientTripContext) : IClientTripRepository
{
    public async Task<IEnumerable<ClientTrip>> GetClientTripList(int tripId)
    {
        return await _clientTripContext.ClientTrips()
            .Where(x => x.IdTrip == tripId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ClientTrip>> GetClientTrips(int clientId)
    {
        return await _clientTripContext.ClientTrips().Where(x => x.IdClient == clientId).ToListAsync();
    }
}