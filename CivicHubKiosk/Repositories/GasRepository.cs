using Microsoft.EntityFrameworkCore;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Domain.Domain.Entities;
using System;

namespace CivicHubKiosk.Repositories

{
    public class GasRepository : IGasRepository
    {
        private readonly CivicHubDbContext _context;

        public GasRepository(CivicHubDbContext context)
        {
            _context = context;
        }
        public async Task<List<GasBoard>> GetAllAsync()
        {
            return await _context.GasBoards.ToListAsync();
        }
        public async Task<List<string>> GetProvidersAsync()
        {
            return await _context.GasBoards
                .Select(x => x.ProviderName)
                .Distinct()
                .ToListAsync();

        }
        public async Task<List<GasBoard>> GetDistrictByProviderAsync(string Provider)
        {
            return await _context.GasBoards
               .Where(x => x.ProviderName == Provider)
               .ToListAsync();

        }
        public async Task<List<GasBoard>> GetsubDistrictByDistrictAsync(string District)
        {
            return await _context.GasBoards
               .Where(x => x.ProviderName == District)
               .ToListAsync();

        }

    }
}
