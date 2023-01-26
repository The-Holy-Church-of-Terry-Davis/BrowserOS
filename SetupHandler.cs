using BrowserOS.OS;

namespace BrowserOS;

public class SetupHandler
{
    public static async Task<Kernel> StartOS()
    {
        Kernel k = new Kernel();
        return k;
    }
}