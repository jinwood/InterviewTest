using System.IO;
using System.Web;
using Testsolution.Data.Interfaces;

namespace Testsolution.Data.Providers
{
    public class StreamProvider : IStreamProvider
    {
        public StreamReader GetStreamReader()
        {
            return new StreamReader(HttpContext.Current.Server.MapPath(@"~/bin/Data/MOCK_DATA.json"));
        }
    }
}
