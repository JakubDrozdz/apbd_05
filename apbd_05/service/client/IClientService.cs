using apbd_05.models;

namespace apbd_05.service;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClients(IEnumerable<ClientTrip> clientTripList);
}