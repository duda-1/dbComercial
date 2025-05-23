using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core._03_Entidades
{
    [Table("Departamento")]
    public class Departamento
    {
        [Key] // Como é chave primária auto-increment, usamos [Key]
        public int idDepartamento { get; set; }          // INT, AUTO_INCREMENT, PK parcial

        public string NomeDepartamento { get; set; }     // VARCHAR(45), pode ser NULL
        public string TelefoneDepartamento { get; set; } // VARCHAR(10), pode ser NULL
        public string CelularDepartamento { get; set; }  // VARCHAR(11), pode ser NULL
        public string EmailDepartamento { get; set; }    // VARCHAR(45), pode ser NULL

        public int Endereco_IdEndereco { get; set; }     // INT, FK, PK parcial
    }
}
