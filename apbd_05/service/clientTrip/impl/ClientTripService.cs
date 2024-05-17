using System.Text.RegularExpressions;
using apbd_05.exception;
using apbd_05.models;
using apbd_05.repository;
using Microsoft.IdentityModel.Tokens;

namespace apbd_05.service;

public class ClientTripService(IClientTripRepository clientTripRepository, IClientService clientService, ITripService tripService) : IClientTripService
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

    public async Task<int> AddClientToTrip(Client client, ClientTripDto clientTripDto)
    {
        var trip = await tripService.GetTrip(clientTripDto.IdTrip, clientTripDto.TripName);
        if (trip == null)
        {
            throw new IllegalClientTripArgumentException("Trip with ID " + clientTripDto.IdTrip + " and name " + clientTripDto.TripName + " does not exists");
        }
        if (client.ClientTrips.Select(x=>x.IdTrip).ToList().Contains(clientTripDto.IdTrip))
        {
            throw new IllegalClientTripArgumentException("Client is already registered for the trip");
        }

        ClientTrip clientTrip = new ClientTrip();
        clientTrip.IdClient = client.IdClient;
        clientTrip.IdTrip = clientTripDto.IdTrip;
        clientTrip.RegisteredAt = DateTime.Now;
        clientTrip.PaymentDate = clientTripDto.PaymentDate;
        return await clientTripRepository.RegisterClientToTrip(clientTrip) != null ? 1 : 0;
    }

    public void ClientTripDtoIsNotValid(ClientTripDto clientTripDto)
    {
        var peselRegex = new Regex("^[0-9]{11}$");
        var phoneNumberRegex = new Regex("^.+{0,1}[0-9]{9,15}$");
        var emailRegex = new Regex("^\\w{1,}@\\w{1,}\\.\\w{2,}$");
        if (!peselRegex.IsMatch(clientTripDto.Pesel) 
            || !phoneNumberRegex.IsMatch(clientTripDto.Telephone)
            || !emailRegex.IsMatch(clientTripDto.Email))
        {
            throw new IllegalClientTripArgumentException("Request body is not valid. Check your requests fields");
        }

        if (clientTripDto.TripName.IsNullOrEmpty() || clientTripDto.FirstName.IsNullOrEmpty() ||
            clientTripDto.LastName.IsNullOrEmpty())
        {
            throw new IllegalClientTripArgumentException("Request body is not valid. Requests fields cannot be blank");
        }
    }
}