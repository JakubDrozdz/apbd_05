namespace apbd_05.context;

public abstract class ApbdDbContext(Apbd05Context apbd05Context)
{
    private Apbd05Context _apbd05Context = apbd05Context;
    
    public Apbd05Context GetDbContext()
    {
        return apbd05Context;
    }
}