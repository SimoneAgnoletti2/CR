using CR.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CR.Interface
{
    public interface IConnect
    {
        HttpClient ClientConnectionAsync();
        Task<string> DatiRequestAsync(string apiCall, List<Parameter> parameter);
    }
}
