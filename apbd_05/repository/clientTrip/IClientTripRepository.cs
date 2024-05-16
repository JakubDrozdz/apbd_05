using apbd_05.models;

namespace apbd_05.repository;

public interface IClientTripRepository
{
    Task<IEnumerable<ClientTrip>> GetClientTripList(int tripId);
}