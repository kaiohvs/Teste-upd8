using API.Infra.Data.Base;
using API.Infra.Data.Models;
using Microsoft.OData.Edm;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Infra.Data.DbModels
{
    [Table("TbCadCliente")]
    public class DbCadCliente : BaseEntity
    {

        public static implicit operator DbCadCliente(CadCliente cadCliente)
        {
            if (cadCliente == null)
            {
                return null;
            }
            return new DbCadCliente
            {
                Id = cadCliente.Id,
                CPF = cadCliente.CPF,
                Nome = cadCliente.Nome,
                DataNasc = cadCliente.DataNasc,
                Sexo = cadCliente.Sexo,
                Endereco = cadCliente.Endereco,
                Estado = cadCliente.Estado,
                Cidade = cadCliente.Cidade,
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

