using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        #region Constructor
        /// <summary>
        /// Attributos
        /// </summary>
        private readonly ApplicationDBContext _context; //Conexion a BD

        private readonly IIngresoService _ingresoService;  //Servicio 

        // Constructor contexto de datos
        public IngresosController(ApplicationDBContext context, IngresoService ingresoService)
        {
            _context = context;
            _ingresoService = ingresoService;
        }
        #endregion

        #region Metodos Request
        /// <summary>
        /// Lista todos las solicitudes de ingresos    
        /// </summary>
        /// <returns>Datos básicos de ingresos de cada persona</returns>
        /// GET: api/Ingresos
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
        /// Lista todos las solicitudes de ingresos    
        /// </summary>
        /// <param name="id">Código Id de la persona</param>
        /// <returns>Datos básicos de ingresos de una persona</returns>
        /// GET: api/Ingresos/id
        [HttpGet("{id}")]
        public IActionResult GetIngresos([Required(ErrorMessage = "Debes ingresar el Id de la solicitud de ingreso")] int id)
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
        /// Inserta una solicitud de ingreso por persona 
        /// </summary>
        /// <param name="ingresos">Campos de la solicitud de ingreso: 
        /// Nombre: alfanumérico de 20 caracteres máximo.
        /// Apellido: alfanumérico de 20 caracteres máximo.
        /// Identificación: solo números son permitidos, 10 dígitos máximo.
        /// Edad: solo números, 2 dígitos máximo.
        /// CasasId: solo número, en este caso para este proyecto solo se contemplan 4 casas, del 1 al 4  </param>
        /// <returns>Datos de la solicitud agregados</returns>
        /// POST: api/Ingresos         
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
        /// Editar una solicitud de ingreso
        /// </summary>
        /// <param name="id">Código Id de la solicitud de ingreso</param>
        /// <param name="ingresos">Campo con su contenido a modificar</param>
        /// <returns>Mensaje indicando que la solicitud fué modificados</returns>
        /// <remarks>
        ///      {
        ///        "nombre": "string",
        ///        "apellido": "string",
        ///        "identificacion": "string",
        ///        "edad": 99,
        ///        "casasId": 0
        ///      } 
        /// </remarks>
        /// PUT: api/Ingresos/id        
        [HttpPut("{id}")]
        public IActionResult PutIngresos([Required(ErrorMessage = "Debes ingresar el Id de la solicitud de ingreso")] int id, Ingresos ingresos)
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
        /// Borrado de una solicitud de ingreso
        /// </summary>
        /// <param name="id">Código Id de la solicitud de ingreso</param>
        /// <returns>Mensaje indicando borrado exitoso</returns>
        /// DELETE: api/Ingresos/id
        [HttpDelete("{id}")]
        public IActionResult DeleteIngresos([Required(ErrorMessage = "Debes ingresar el Id de la solicitud de ingreso")] int id)
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

        #endregion
    }
}
