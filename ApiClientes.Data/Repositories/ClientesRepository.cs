using ApiClientes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiClientes.Data.Repositories
{
    public interface ClientesRepository
    {
        Task<IEnumerable<ClientesCo>> GetAllClientes();
        Task<ClientesCo> GetClientes(string Cliente);
    }
}
