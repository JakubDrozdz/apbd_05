using apbd_05.context;
using apbd_05.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace apbd_05.repository;

public class StandardClientRepository(ClientContext _clientContext) : IClientRepository
{
    public async Task<IEnumerable<Client>> GetClients(IEnumerable<int> clientsIds)
    {
        return await _clientContext.Clients().Where(x => clientsIds.Contains(x.IdClient)).ToListAsync();
    }

    public async Task<int> DeleteClient(int clientId)
    {
        return await _clientContext.Clients().Where(x => x.IdClient == clientId).ExecuteDeleteAsync();
    }

    public async Task<Client> FindWithPesel(string pesel)
    {
        return await _clientContext.Clients().Include(np=>np.ClientTrips).Where(x => x.Pesel == pesel).FirstOrDefaultAsync();
    }

    public async Task<Client> AddClient(Client client)
    {
        Client persistedClient = (await _clientContext.Clients().AddAsync(client)).Entity;
        await _clientContext.GetDbContext().SaveChangesAsync();
        return persistedClient;
    }

    public int GetMaxId()
    {
        return _clientContext.Clients().Max(x => x.IdClient);
    }
}