using AutoMapper;
using HandlingExtinguishers.Contracts.Interfaces.Repositorios;
using HandlingExtinguishers.DTO.Filters;
using HandlingExtinguishers.DTO.Models;
using Microsoft.EntityFrameworkCore;

namespace HandlingExtinguishers.Infrastructure.Repositories
{
    public class ExpensesRepository: BaseRepository<Expenses>,IRepositoryExpenses
    {
        private readonly IMapper _mapper;
        public HandlingExtinguishersDbContext handlingExtinguishersDbContext { get; set; }
        public ExpensesRepository(HandlingExtinguishersDbContext context, IMapper mapper) : base(context)
        {
            handlingExtinguishersDbContext = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Expenses>> ConsultData(FilterExpenses filter) 
        {
            var expenses = await handlingExtinguishersDbContext.Expenses!.ToListAsync();
            if (filter.Description != null)
            {
                expenses = expenses.Where(x => (x.Description!.ToLower().Contains(filter.Description.ToLower()))).ToList();
            }

            if (filter.Date != null)
            {
                expenses = expenses.Where(x => x.Date == filter.Date).ToList();
            }
            return expenses;
        }
    }
}
