using apbd_05.models;
using apbd_05.repository;

namespace apbd_05.service;

public class ClientTripService(IClientTripRepository _clientTripRepository, IClientService _clientService) : IClientTripService
{
    public async Task<IEnumerable<ClientDto>> GetClientDtos(int tripId)
    {
        var clientTripList = await _clientTripRepository.GetClientTripList(tripId);
        var clients = await _clientService.GetClients(clientTripList);
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
}