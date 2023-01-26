using System.Reflection;
using System.Reflection.Emit;

namespace BrowserOS.OS;

public class Kernel
{
    internal List<Proc>? Running { get; set; }
    public async Task ExecuteBytes(byte[] bts, object[] args, Type returntype)
    {
        Proc p = await BuildProcess();
        
        Assembly asmbly = Assembly.Load(bts);
        MethodInfo entrypoint = asmbly.EntryPoint ?? throw new Exception("Could not interpret bytes!");
        object? rval = entrypoint.Invoke(null, args);
    }

    internal async Task<Proc> BuildProcess()
    {
        Guid gd = Guid.NewGuid();
        AppDomain dmn = AppDomain.CreateDomain(gd.ToString());

        Proc p = new Proc(gd, dmn);
        Running?.Add(p);

        return p;
    }
}