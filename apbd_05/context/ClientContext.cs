using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.context;

public class ClientContext(Apbd05Context apbd05Context) : ApbdDbContext(apbd05Context)
{

    public virtual DbSet<Client> Clients()
    {
        return apbd05Context.Clients;
    }
}