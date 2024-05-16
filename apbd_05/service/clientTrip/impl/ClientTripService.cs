using apbd_05.models;
using apbd_05.repository;

namespace apbd_05.service;

public class ClientTripService(IClientTripRepository clientTripRepository, IClientService clientService) : IClientTripService
{
    public async Task<IEnumerable<ClientDto>> GetClientDtos(int tripId)
    {
        var clientTripList = await clientTripRepository.GetClientTripList(tripId);
        var clients = await clientService.GetClients(clientTripList);
        List<ClientDto> clientDtos = new List<ClientDto>();
        foreach (var client in clients)
        {
            var clientDto = new ClientDto();
            clientDto.FirstName = client.FirstName;
            clientDto.LastName = client.LastName;
            clientDtos.Add(clientDto);
        }
        return clientDtos;
    }

    public async Task<int> GetNumberOfTripsForClient(int clientId)
    {
        var clientTrips = await clientTripRepository.GetClientTrips(clientId);
        return clientTrips.Count();
    }

    public async Task<int> AddClientToTrip(ClientTripDto clientTripDto)
    {
        return 0;
    }
}