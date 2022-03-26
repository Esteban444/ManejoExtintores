using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using Microsoft.AspNetCore.Mvc;

namespace HandlingExtinguishers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly IServiceExpenses _serviceExpenses;
        

        public ExpensesController(IServiceExpenses serviceExpenses ) 
        {
            _serviceExpenses = serviceExpenses;
            
        }

        [HttpGet]
        public async Task<IActionResult> ConsultExpenses([FromQuery] FilterExpenses filter) 
        {
            var expenses = await _serviceExpenses.GetExpenses(filter);
            return Ok(expenses);
        }

        /*[HttpGet("{id}")]
        public IActionResult ConsultaGastoPorId(int id)
        {
            var gasto = _servicioGasto.GetGasto(id);
            var response = new Respuesta<GastosDTO>(gasto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CrearGasto(GastosBase gastosbase)
        {
            var Validacion = _validator.Validate(gastosbase);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                await _servicioGasto.CrearGasto(gastosbase);
                var response = new Respuesta<GastosBase>(gastosbase);
                return Ok(response);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarGasto(int id, GastosBase actualizar)
        {
            var Validacion = _validator.Validate(actualizar);
            if (!Validacion.IsValid)
            {
                var errors = Validacion.Errors.Select(e => e.ErrorMessage);

                return BadRequest(new RespuestaGasto { Errors = errors });
            }
            else
            {
                var result = await _servicioGasto.ActualizarGasto(id, actualizar);
                var response = new Respuesta<GastosBase>(result);
                return Ok(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _servicioGasto.EliminarGasto(id);
            var response = new Respuesta<GastosDTO>(result);
            return Ok(response);

        }*/
    }
}
