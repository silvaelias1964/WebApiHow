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
        /// Add Ingresos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int AddIngresos(Ingresos entity);

        /// <summary>
        /// Edit Ingresos
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        int EditIngresos(int id, Ingresos entity);

        /// <summary>
        /// Delete ingresos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DeleteIngreso(int id);
    }
}
