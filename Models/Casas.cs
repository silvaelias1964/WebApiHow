using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiHow.Models
{
    /// <summary>
    /// Casas
    /// </summary>
    public class Casas
    {
        /// <summary>
        /// Id de la Casa
        /// </summary>
        /// <value>Autoincrementable</value>
        [Key]
        public int Id { get; set; }        

        /// <summary>
        /// Nombre de la casa
        /// </summary>
        public string NombreCasa { get; set; }
        
        public virtual ICollection<Ingresos> Ingresos { get; set; }

    }
}
