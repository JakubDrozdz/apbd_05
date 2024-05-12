using apbd_05.models;
using Microsoft.EntityFrameworkCore;

namespace apbd_05.context;

public class TripContext(Apbd05Context apbd05Context)
{
    private Apbd05Context _apbd05Context = apbd05Context;
    
    public virtual DbSet<Trip> Trips()
    {
        return apbd05Context.Trips;
    }
}