using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.context;

public class TripContext(Apbd05Context apbd05Context) : ApbdDbContext(apbd05Context)
{
    public virtual DbSet<Trip> Trips()
    {
        return apbd05Context.Trips;
    }
}