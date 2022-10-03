using API.Business.Interfaces;
using API.Infra.Data.Models;
using API.Infra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Business.Services
{
    public class CadClienteService : ICadClienteService
    {
        public readonly ICadClienteRepository _repository;

        public CadClienteService(ICadClienteRepository repository)
        {
            _repository = repository;
        }
        public async Task<CadCliente> Create(CadCliente cadCliente)
        {
            try
            {
               return await _repository.Create(cadCliente);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                 await _repository.Delete(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CadCliente>> Get()
        {
            try
            {
                var listDb = await _repository.Get();
                return listDb.Select(x => (CadCliente)x).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<CadCliente> Get(int id)
        {
            try
            {
                return await _repository.Get(id);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<CadCliente>> Get(string nome)
        {
            try
            {
                var listDb = await _repository.Get(nome);
                return listDb.Select(x => (CadCliente)x).ToList();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public async Task Update(CadCliente cadCliente)
        {
            try
            {
                await _repository.Update(cadCliente);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
