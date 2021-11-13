using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiHow.Models
{

	/// <summary>
	/// Clase Entidad Ingresos
	/// </summary>
	public class Ingresos
	{

		[Key]		
		public int Id { get; set; }

		[Required(ErrorMessage ="El nombre es requerido")]
		[MaxLength(20, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
		public string Nombre { get; set; }

		[Required(ErrorMessage = "El apellido es requerido")]
		[MaxLength(20, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
		public string Apellido { get; set; }

		[Required(ErrorMessage ="El número de identificacion es obligatorio")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "La identificación debe tener solo números")]
		[MaxLength(10, ErrorMessage = "El {0} debe tener un máximo de {1} numeros")]
		public string Identificacion { get; set; }

		[Required(ErrorMessage ="La Edad es obligatoria")]
		[Range(1, 99, ErrorMessage = "El valor debe estar entre 1 to 99")]
		public int Edad { get; set; }
		
		[Required(ErrorMessage = "La Casa es obligatoria")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "El código de Casa debe tener solo números")]
		public int CasasId { get; set; }

		public Casas Casas { get; set; }

	}
}
