using API.Infra.Data.Models;

namespace API.Business.Interfaces
{
    public interface ICadClienteService
    {
        Task<IEnumerable<CadCliente>> Get();
        Task<CadCliente> Get(int id);
        Task<IEnumerable<CadCliente>> Get(string nome);
        Task<CadCliente> Create(CadCliente cadCliente);
        Task Update(CadCliente cadCliente);
        Task Delete(int id);
    }
}
