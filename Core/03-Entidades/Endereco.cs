using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    class Endereco
    {
        public int IdEndereco { get; set; }          // PRIMARY KEY, AUTO_INCREMENT
        public string CEP { get; set; }              // VARCHAR(8)
        public int? TipoVia { get; set; }            // INT(1), pode ser NULL
        public string NomeVia { get; set; }          // VARCHAR(45)
        public string Numero { get; set; }           // VARCHAR(5)
        public string Complemento { get; set; }      // VARCHAR(45)
        public string Bairro { get; set; }           // VARCHAR(45)
        public string Cidade { get; set; }           // VARCHAR(45)
        public string UF { get; set; }               // VARCHAR(2)
    }
}
