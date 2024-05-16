using apbd_05.context;
using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.repository;

public class StandardClientRepository(ClientContext _clientContext) : IClientRepository
{
    public async Task<IEnumerable<Client>> GetClients(IEnumerable<int> clientsIds)
    {
        return await _clientContext.Clients().Where(x => clientsIds.Contains(x.IdClient)).ToListAsync();
    }
}