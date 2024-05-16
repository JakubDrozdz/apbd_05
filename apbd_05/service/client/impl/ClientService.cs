using apbd_05.models;
using apbd_05.repository;

namespace apbd_05.service;

public class ClientService(IClientRepository clientRepository) : IClientService
    
{
    public async Task<IEnumerable<Client>> GetClients(IEnumerable<ClientTrip> clientTripList)
    {
        var clientsIds = clientTripList.Select(x => x.IdClient).ToList();
        return await clientRepository.GetClients(clientsIds);
    }

    public async Task<int> DeleteClient(int clientId)
    {
        return await clientRepository.DeleteClient(clientId);
    }
}