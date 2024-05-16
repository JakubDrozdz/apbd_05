namespace apbd_05.models;

public class ClientTripDto
{
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Telephone { get; set; } = null!;

    public string Pesel { get; set; } = null!;
    public int IdTrip { get; set; }
    public string TripName { get; set; } = null!;
    public DateTime LocalDate { get; set; }
}