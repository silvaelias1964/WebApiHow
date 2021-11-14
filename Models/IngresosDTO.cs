namespace WebApiHow.Models
{
    /// <summary>
    /// Ingresos (Data Transfer Object) se usa para desplegar los datos
    /// </summary>
    public class IngresosDTO
    {

        public int Id_Ingreso { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Identificacion { get; set; }

        public int Edad { get; set; }

        public string NombreCasa { get; set; }


    }
}
