using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiHow.Data;
using WebApiHow.Models;
using WebApiHow.Services;

namespace WebApiHow.Controllers
{

    /// <summary>
    ///  Controlador Ingresos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class IngresosController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        private readonly IIngresoService _ingresoService;

        // Constructor contexto de datos
        public IngresosController(ApplicationDBContext context, IngresoService ingresoService)
        {
            _context = context;
            _ingresoService = ingresoService;
        }


        /// <summary>
        /// GET: api/Ingresos
        /// </summary>
        /// <returns>list</returns>
        [HttpGet]
        public IActionResult GetIngresos()   
        {
            try
            {

                List<IngresosDTO> lista = new List<IngresosDTO>();

                var datos = _context.Ingresos.ToList(); 
                foreach (var item in datos)
                {
                    var nombre = _context.Casas.FirstOrDefault(i => i.Id.Equals(item.CasasId));
                    lista.Add(new IngresosDTO
                    {
                        Id_Ingreso = item.Id,
                        Nombre = item.Nombre,
                        Apellido = item.Apellido,
                        Identificacion = item.Identificacion,
                        Edad = item.Edad,          
                        NombreCasa=nombre.NombreCasa
                    }); 

                }

                return Ok(new { statusCode = "200", result = lista });
            }
            catch (Exception ex)
            {

                return BadRequest(new { statusCode = "400", errorMesage = ex.Message, result = "" });
            }
            
        }


        /// <summary>
        /// GET: api/Ingresos/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list</returns>
        [HttpGet("{id}")]
        public IActionResult GetIngresos(int id)
        {

            try
            {

                List<IngresosDTO> lista = new List<IngresosDTO>();

                var datos = _context.Ingresos.Find(id);
                if (datos != null)
                {
                    var nombre = _context.Casas.FirstOrDefault(i => i.Id.Equals(datos.CasasId));
                    lista.Add(new IngresosDTO
                    {
                        Id_Ingreso = datos.Id,
                        Nombre = datos.Nombre,
                        Apellido = datos.Apellido,
                        Identificacion = datos.Identificacion,
                        Edad = datos.Edad,
                        NombreCasa = nombre.NombreCasa
                    });

                    return Ok(new { statusCode = "200", result = lista });
                }
                else
                {
                    return Ok(new { statusCode = "200", result = "Solicitud de Ingreso no encontrada" });
                }
            }
            catch (Exception ex)
            {
                return BadRequest(new { statusCode = "400", errorMesage = ex.Message, result = "" });
            }

        }

        /// <summary>
        /// PUT: api/Ingresos/id        
        /// </summary>
        /// <param name="id"></param>
        /// <param name="ingresos"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutIngresos(int id, Ingresos ingresos)
        {

            int estado = _ingresoService.EditIngresos(id,ingresos);
            if (estado == 1)
            {
                return Ok(new { statusCode = "200", result = "La Casa no está registrada.." });
            }
            else if (estado == 2)
            {
                return Ok(new { statusCode = "200", result = "Solicitud de Ingreso no encontrada" });
            }
            else if (estado == 9)
            {
                return BadRequest(new { statusCode = "400", result = "Error de datos.." });
            }

            return Ok(new { statusCode = "200", result = "Solicitud de Ingreso modificado exitosamente" });
        }

        
        /// <summary>
        /// POST: api/Ingresos         
        /// </summary>
        /// <param name="ingresos"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostIngresos(Ingresos ingresos)
        {

            int estado = _ingresoService.AddIngresos(ingresos);
            if (estado == 1)
            {
                return Ok(new { statusCode = "200", result = "La Casa no está registrada.." });
            }
            else if (estado == 9)
            {
                return BadRequest(new { statusCode = "400", result = "Error de datos.." });
            }

            return CreatedAtAction("PostIngresos", new { id = ingresos.Id }, ingresos);
        }

        /// <summary>
        /// DELETE: api/Ingresos/id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteIngresos(int id)
        {

            int estado = _ingresoService.DeleteIngreso(id);
            if (estado == 2)
            {
                return Ok(new { statusCode = "200", result = "Solicitud de Ingreso no encontrada" });
            }
            else if (estado == 9)
            {
                return BadRequest(new { statusCode = "400", result = "Error de datos.." });
            }

            return Ok(new { statusCode = "200", result = "Solicitud de Ingreso eliminada exitosamente" });
        }

    }
}
