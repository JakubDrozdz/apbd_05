using apbd_05.models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace apbd_05.repository;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClients(IEnumerable<int> clientsIds);
    Task<int> DeleteClient(int clientId);

    Task<Client> FindWithPesel(string pesel);

    Task<Client> AddClient(Client client);

    int GetMaxId();
}