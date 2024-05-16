using apbd_05.context;
using apbd_05.models;

namespace apbd_05.repository;

public interface ITripRepository
{
    Task<IEnumerable<Trip>> GetAllTrips();
}