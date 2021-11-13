using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApiHow.Data;
using WebApiHow.Models;

namespace WebApiHow.Services
{
    public class IngresoService : IIngresoService
    {
        /// <summary>
        ///  Servicio para Solicitudes de ingreso
        /// </summary>

        private readonly ApplicationDBContext _context;

        // Constructor contexto de datos
        public IngresoService(ApplicationDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Add Ingresos
        /// </summary>
        /// <param name="entity"></param>
        /// <returns>1-Casa no encontrada 3-Ok 9-Error</returns>
        public int AddIngresos(Ingresos entity)
        {
            var nombreCasa = _context.Casas.FirstOrDefault(i => i.Id.Equals(entity.CasasId));
            if (nombreCasa == null)
            {
                return 1;  // No existe la casa
            }

            try
            {                
                _context.Ingresos.Add(entity);
                _context.SaveChanges();
                return 3;  // Guardado correcto
            }
            catch (Exception)
            {
                return 9;  // Error al guardar
            }
        }


        /// <summary>
        /// Edit Ingreso 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns>1-Casa no encontrada 2-solicitud no encontrada 3-Ok 9-Error </returns>
        public int EditIngresos(int id, Ingresos entity) 
        {
            if (id != entity.Id)
            {
                return 2;  // No existe la solicitud
            }

            var nombreCasa = _context.Casas.FirstOrDefault(i => i.Id.Equals(entity.CasasId));
            if (nombreCasa == null)
            {
                return 1; // No existe la casa
            }

            _context.Entry(entity).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresosExists(id))
                {

                    return 2;  // Solicitud no encontrada
                }
                else
                {
                    return 9;  // Error en datos
                }
            }

            return 3; // Guardado correcto
        }


        public int DeleteIngreso(int id) 
        {
            var ingresos = _context.Ingresos.Find(id);
            if (ingresos == null)
            {

                return 2;  // No existe la solicitud
            }

            try
            {
                _context.Ingresos.Remove(ingresos);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                return 9;  // Error en datos
            }
            
            return 3; // Borrado correcto

        }

        /// <summary>
        /// Chequea existencia de solicitud
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool IngresosExists(int id)
        {
            return _context.Ingresos.Any(e => e.Id == id);
        }


    }
}
