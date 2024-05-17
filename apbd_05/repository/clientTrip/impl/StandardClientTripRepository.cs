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

    public async Task<ClientTrip> RegisterClientToTrip(ClientTrip clientTrip)
    {
        ClientTrip persistedClientTrip = (await _clientTripContext.ClientTrips().AddAsync(clientTrip)).Entity;
        await _clientTripContext.GetDbContext().SaveChangesAsync();
        return persistedClientTrip;
    }
}