using API.Infra.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Infra.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DbCadCliente>().HasData(
                new DbCadCliente
                {
                    Id = 1,
                    CPF = "431.502.818-57",
                    Nome = "Kaio Santos",
                    DataNasc = new DateTime(1997, 03, 06),
                    Sexo = "M",
                    Endereco = "Rua Adelia da Silva Mendes",
                    Estado = "SP",
                    Cidade = "São Paulo"
                },
                   new DbCadCliente
                   {
                       Id = 2,
                       CPF = "431.502.818-11",
                       Nome = "Rebeca Silva",
                       DataNasc = new DateTime(2000, 04, 19),
                       Sexo = "F",
                       Endereco = "Rua Adelia da Silva Mendes",
                       Estado = "SP",
                       Cidade = "São Paulo"
                   },
                      new DbCadCliente
                      {
                          Id = 3,
                          CPF = "431.502.818-22",
                          Nome = "Cassio Santos",
                          DataNasc = new DateTime(1999, 06, 15),
                          Sexo = "M",
                          Endereco = "Rua Adelia da Silva Mendes",
                          Estado = "SP",
                          Cidade = "São Paulo"
                      },
                         new DbCadCliente
                         {
                             Id = 4,
                             CPF = "431.502.818-33",
                             Nome = "Caua Santos",
                             DataNasc = new DateTime(2007, 02, 18),
                             Sexo = "M",
                             Endereco = "Rua Adelia da Silva Mendes",
                             Estado = "SP",
                             Cidade = "São Paulo"
                         },
                            new DbCadCliente
                            {
                                Id = 5,
                                CPF = "431.502.818-44",
                                Nome = "Marinalva Santos",
                                DataNasc = new DateTime(1975, 12, 20),
                                Sexo = "F",
                                Endereco = "Rua Adelia da Silva Mendes",
                                Estado = "SP",
                                Cidade = "São Paulo"
                            },
                               new DbCadCliente
                               {
                                   Id = 6,
                                   CPF = "431.502.818-55",
                                   Nome = "Josafa Santos",
                                   DataNasc = new DateTime(1964, 01, 12),
                                   Sexo = "M",
                                   Endereco = "Rua Adelia da Silva Mendes",
                                   Estado = "SP",
                                   Cidade = "São Paulo"
                               },
                                  new DbCadCliente
                                  {
                                      Id = 7,
                                      CPF = "431.502.818-66",
                                      Nome = "Dina Santos",
                                      DataNasc = new DateTime(1996, 04, 09),
                                      Sexo = "F",
                                      Endereco = "Rua Adelia da Silva Mendes",
                                      Estado = "SP",
                                      Cidade = "São Paulo"
                                  },
                                     new DbCadCliente
                                     {
                                         Id = 8,
                                         CPF = "431.502.818-77",
                                         Nome = "Felipe Vasconcelos",
                                         DataNasc = new DateTime(1995, 05, 18),
                                         Sexo = "M",
                                         Endereco = "Rua Adelia da Silva Mendes",
                                         Estado = "SP",
                                         Cidade = "São Paulo"
                                     }
                );

        }

        public DbSet<DbCadCliente> DbCadClientes { get; set; }
    }
}
