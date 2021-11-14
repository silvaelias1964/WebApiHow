using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiHow.Models;

namespace WebApiHow.Services
{
    /// <summary>
    /// Interface Servicio Ingreso
    /// </summary>
    public interface IIngresoService
    {
        /// <summary>
        /// Agregar Ingresos
        /// </summary>
        /// <param name="entity">modelo-entidad</param>
        /// <returns>Código de estado: 1-Casa no encontrada 3-Ok 9-Error</returns>
        int AddIngresos(Ingresos entity);

        /// <summary>
        /// Editar Ingresos 
        /// </summary>
        /// <param name="id">Id de Ingresos</param>
        /// <param name="entity">Modelo-entidad</param>
        /// <returns>Código de estado: 1-Casa no encontrada 2-solicitud no encontrada 3-Ok 9-Error </returns>
        int EditIngresos(int id, Ingresos entity);

        /// <summary>
        /// Eliminar ingreso
        /// </summary>
        /// <param name="id">Id de Ingreso</param>
        /// <returns>Código de estado: 2-solicitud no encontrada 3-Ok 9-Error </returns>
        int DeleteIngreso(int id);
    }
}
