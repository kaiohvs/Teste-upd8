using API.Infra.Data.Base;
using API.Infra.Data.DbModels;
using Microsoft.OData.Edm;
using System;
using System.ComponentModel.DataAnnotations;

namespace API.Infra.Data.Models
{
    public class CadCliente : BaseEntity
    {
        public static implicit operator CadCliente(DbCadCliente dbCadCliente)
        {
            if (dbCadCliente == null)
            {
                return null;
            }
            return new CadCliente
            {
                Id = dbCadCliente.Id,
                CPF = dbCadCliente.CPF,
                Nome = dbCadCliente.Nome,
                DataNasc = dbCadCliente.DataNasc,
                Sexo = dbCadCliente.Sexo,
                Endereco = dbCadCliente.Endereco,
                Estado = dbCadCliente.Estado,
                Cidade = dbCadCliente.Cidade,
            };
        }


        [Required(ErrorMessage = "O CPF do usuário é obrigatório")]
        public string CPF { get; set; }
        [Required(ErrorMessage = "O Nome do usuário é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "A Data de Nascimento do usuário é obrigatório")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy")]
        public DateTime DataNasc { get; set; }
        [Required(ErrorMessage = "O Sexo do usuário é obrigatório")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "O Endereço do usuário é obrigatório")]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O Estado do usuário é obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "A Cidade do usuário é obrigatório")]
        public string Cidade { get; set; }


    }
}
