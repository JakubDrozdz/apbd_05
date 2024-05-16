using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.context;

public class ClientTripContext(Apbd05Context apbd05Context) : ApbdDbContext(apbd05Context)
{
    public virtual DbSet<ClientTrip> ClientTrips()
    {
        return apbd05Context.ClientTrips;
    }
}