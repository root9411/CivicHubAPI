using Microsoft.EntityFrameworkCore;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Domain.Domain.Entities;
using System;

namespace CivicHubKiosk.Repositories
{
    public class WaterRepository : IWaterReppository
    {
        private readonly CivicHubDbContext _context;

        public WaterRepository(CivicHubDbContext context)
        {
            _context = context;
        }
        public async Task<List<WaterBoard>> GetAllAsync()
        {
            return await _context.WaterBoards.ToListAsync();
        }
        public async Task<List<string>> GetBoardsAsync()
        {
            return await _context.WaterBoards
                .Select(x => x.BoardName)
                .Distinct()
                .ToListAsync();

        }
        public async Task<List<WaterBoard>> GetserviceByboardsAsync(string boards)
        {
            return await _context.WaterBoards
               .Where(x => x.BoardName == boards)
               .ToListAsync();

        }

    }
}