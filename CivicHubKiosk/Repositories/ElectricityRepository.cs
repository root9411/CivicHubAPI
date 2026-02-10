using Microsoft.EntityFrameworkCore;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Domain.Domain.Entities;
using System;

namespace CivicHubKiosk.Repositories
{
    public class ElectricityRepository : IElectricityRepository
    {
        private readonly CivicHubDbContext _context;

        public ElectricityRepository(CivicHubDbContext context)
        {
            _context = context;
        }

        public async Task<List<ElectricityBoard>> GetAllAsync()
        {
            return await _context.ElectricityBoards.ToListAsync();
        }

        public async Task<List<string>> GetStatesAsync()
        {
            return await _context.ElectricityBoards
                .Select(x => x.State)
                .Distinct()
                .ToListAsync();
        }

        public async Task<List<ElectricityBoard>> GetBoardsByStateAsync(string state)
        {
            return await _context.ElectricityBoards
                .Where(x => x.State == state)
                .ToListAsync();
        }
    }
}