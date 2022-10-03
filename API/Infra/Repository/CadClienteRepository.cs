using API.Infra.Context;
using API.Infra.Data.DbModels;
using API.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.Repository
{
    public class CadClienteRepository : ICadClienteRepository
    {
        public readonly MSSQLContext _context;
        public CadClienteRepository(MSSQLContext context)
        {
            _context = context;
        }
        public async Task<DbCadCliente> Create(DbCadCliente cadCliente)
        {
            try
            {
                _context.DbCadClientes.Add(cadCliente);
                await _context.SaveChangesAsync();

                return cadCliente;
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
                var entity = await _context.DbCadClientes.Where(del => del.Id == id).FirstOrDefaultAsync();
                if (entity == null) throw new Exception("Não encontrado registro para deletar");

                _context.DbCadClientes.Remove(entity);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DbCadCliente>> Get()
        {
            try
            {          

                return await _context.DbCadClientes.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<DbCadCliente> Get(int id)
        {
            try
            {
                var entity = await _context.DbCadClientes.FirstOrDefaultAsync(del => del.Id == id);
                if (entity == null) throw new Exception("Id informado não existe no banco de dados");

                return entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<DbCadCliente>> Get(string nome)
        {
            try
            {
                if (nome == null)
                {
                    throw new Exception("Numero informado é nulo.");
                }

                return await _context.DbCadClientes.Where(s => s.Nome.StartsWith(nome)).Select(s => new DbCadCliente()
                {
                    Id = s.Id,
                    Nome = s.Nome,
                    CPF = s.CPF,
                    Sexo = s.Sexo,
                    DataNasc = s.DataNasc,
                    Cidade = s.Cidade,
                    Endereco = s.Endereco,
                    Estado = s.Estado
                }).ToListAsync();
                              

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Update(DbCadCliente product)
        {
            try
            {
                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
