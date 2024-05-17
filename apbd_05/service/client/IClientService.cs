using apbd_05.models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace apbd_05.service;

public interface IClientService
{
    Task<IEnumerable<Client>> GetClients(IEnumerable<ClientTrip> clientTripList);
    Task<IEnumerable<ClientDto>> GetClientDtos(IEnumerable<ClientTrip> clientTrips);

    Task<int> DeleteClient(int clientId);

    Task<Client> AddClient(ClientTripDto clientTripDto);
}