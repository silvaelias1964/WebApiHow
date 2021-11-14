using System;
using System.ComponentModel.DataAnnotations;

namespace WebApiHow.Models
{

	/// <summary>
	/// Solicitudes de Ingresos
	/// </summary>
	public class Ingresos
	{
		/// <summary>
		/// Id de Ingresos (solicitudes)
		/// </summary>
		/// <value>Autoincrementable</value>
		[Key]		
		public int Id { get; set; }

		/// <summary>
		/// Nombre
		/// </summary>
		[Required(ErrorMessage ="El nombre es requerido")]
		[MaxLength(20, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
		public string Nombre { get; set; }

		/// <summary>
		/// Apellido
		/// </summary>
		[Required(ErrorMessage = "El apellido es requerido")]
		[MaxLength(20, ErrorMessage = "El {0} debe tener un máximo de {1} caracteres")]
		public string Apellido { get; set; }

		/// <summary>
		/// Nro. de identificación
		/// </summary>
		[Required(ErrorMessage ="El número de identificación es obligatorio")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "La identificación debe tener solo números")]
		[MaxLength(10, ErrorMessage = "El {0} debe tener un máximo de {1} numeros")]
		public string Identificacion { get; set; }

		/// <summary>
		/// Edad
		/// </summary>
		[Required(ErrorMessage ="La Edad es obligatoria")]
		[Range(1, 99, ErrorMessage = "El valor debe estar entre 1 to 99")]
		public int Edad { get; set; }
		
		/// <summary>
		/// Casa 
		/// </summary>
		[Required(ErrorMessage = "La Casa es obligatoria")]
		[RegularExpression("^[0-9]*$", ErrorMessage = "El código de Casa debe tener solo números")]
		public int CasasId { get; set; }

		public Casas Casas { get; set; }

	}
}
