using System.Reflection;

namespace MuhasebeAPI.Persistence;

public class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(Assembly).Assembly;
}
