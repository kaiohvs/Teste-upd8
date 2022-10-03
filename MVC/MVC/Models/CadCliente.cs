using System;

namespace MVC.Models
{
    public class CadCliente
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public string Sexo { get; set; }
        public string Endereco { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}
