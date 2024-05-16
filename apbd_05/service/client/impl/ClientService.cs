using apbd_05.exception;
using apbd_05.models;
using apbd_05.repository;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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

    public async Task<Client> AddClient(ClientTripDto clientTripDto)
    {
        Client client = new Client();
        client.IdClient = clientRepository.GetMaxId() + 1;
        client.FirstName = clientTripDto.FirstName;
        client.LastName = clientTripDto.LastName;
        client.Email = clientTripDto.Email;
        client.Telephone = clientTripDto.Telephone;
        client.Pesel = clientTripDto.Pesel;

        Client clientInDb = await clientRepository.FindWithPesel(client.Pesel);
        if (clientInDb != null)
        {
            //throw new ClientAlreadyExistException("Client with PESEL " + client.Pesel + " already exists");
            return clientInDb;
        }

        return await clientRepository.AddClient(client);
    }
}