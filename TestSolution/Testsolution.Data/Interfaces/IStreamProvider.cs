using System.IO;

namespace Testsolution.Data.Interfaces
{
    public interface IStreamProvider
    {
        StreamReader GetStreamReader();
    }
}
