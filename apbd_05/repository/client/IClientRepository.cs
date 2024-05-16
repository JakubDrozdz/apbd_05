using apbd_05.models;

namespace apbd_05.repository;

public interface IClientRepository
{
    Task<IEnumerable<Client>> GetClients(IEnumerable<int> clientsIds);
    Task<int> DeleteClient(int clientId);
}