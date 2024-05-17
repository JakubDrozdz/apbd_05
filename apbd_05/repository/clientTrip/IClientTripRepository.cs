using apbd_05.models;

namespace apbd_05.repository;

public interface IClientTripRepository
{
    Task<IEnumerable<ClientTrip>> GetClientTripList(int tripId);

    Task<IEnumerable<ClientTrip>> GetClientTrips(int clientId);

    Task<ClientTrip> RegisterClientToTrip(ClientTrip clientTrip);
}