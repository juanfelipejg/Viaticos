using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Viaticos.Common.Models;

namespace Viaticos.Common.Services
{
    public interface IApiService
    {
        Task<Response> GetListAsync<T>(string urlBase, string servicePrefix, string controller);
    }
}
