using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.Contracts.Interfaces.Services;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Response;

namespace HandlingExtinguishers.Core.Services
{
    public class ServiceExpenses: IServiceExpenses 
    {
        private readonly IRepositoryExpenses _repositoryExpenses; 
        private readonly IMapper _mapper;

        public ServiceExpenses(IRepositoryExpenses repositoryExpenses, IMapper mapper) 
        {
            _repositoryExpenses = repositoryExpenses;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ExpenseResponseDto>> GetExpenses(FilterExpenses filter) 
        {
            var expenses = await _repositoryExpenses.ConsultData(filter);  
            var expensesdt = _mapper.Map<IEnumerable<ExpenseResponseDto>>(expenses);
            return expensesdt;
        }

        /*public GastosDTO GetGasto(int id)
        {
            var gastobd = _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                return _mapper.Map<GastosDTO>(gastobd);
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto no existe en la base de datos" });
            }
        }

        public async Task<GastosBase> CrearGasto(GastosBase gastobs)
        {
            var gasto = _mapper.Map<Gastos>(gastobs);
            await _repositorio.Crear(gasto);
            gastobs = _mapper.Map<GastosBase>(gasto);
            return gastobs;
        }

        public async Task<GastosBase> ActualizarGasto(int id, GastosBase gastoac)
        {
            var gastobd = _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                gastobd.Descripcion = gastoac.Descripcion;
                gastobd.Fecha = gastoac.Fecha;
                gastobd.Cantidad = gastoac.Cantidad;
                gastobd.Total = gastoac.Total;

                await _repositorio.Actualizar(gastobd);
                var gastoA = _mapper.Map<GastosBase>(gastobd);
                return gastoA;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El registro de gasto que desea actualizar no existe en la base de datos" });
            }
        }

        public async Task<GastosDTO> EliminarGasto(int id)
        {
            var gastobd = _repositorio.ConsultaPorId(c => c.IdGastos == id);
            if (gastobd != null)
            {
                await _repositorio.Eliminar(gastobd);
                var gastoE = _mapper.Map<GastosDTO>(gastobd);
                return gastoE;
            }
            else
            {
                throw new ManejoExcepciones(HttpStatusCode.NotFound, new { Mensaje = "El gasto no existe en la base de datos" });
            }
        }*/

    }
}
