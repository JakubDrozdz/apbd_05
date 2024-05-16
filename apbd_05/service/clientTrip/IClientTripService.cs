using System.Collections;
using apbd_05.models;

namespace apbd_05.service;

public interface IClientTripService
{
    Task<IEnumerable<ClientDto>> GetClientDtos(int tripId);
}