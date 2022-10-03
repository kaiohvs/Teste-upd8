using API.Infra.Data.DbModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Infra.Interfaces
{
    public interface ICadClienteRepository
    {
        Task<IEnumerable<DbCadCliente>> Get();
        Task<DbCadCliente> Get(int id);
        Task<IEnumerable<DbCadCliente>> Get(string nome);
        Task<DbCadCliente> Create(DbCadCliente cadCliente);
        Task Update(DbCadCliente cadCliente);
        Task Delete(int id);
    }
}
