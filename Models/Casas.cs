using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHow.Models
{
    /// <summary>
    /// Clase Entidad Casas
    /// </summary>
    public class Casas
    {
        [Key]
        public int Id { get; set; }        

        public string NombreCasa { get; set; }

        public virtual ICollection<Ingresos> Ingresos { get; set; }

    }
}
