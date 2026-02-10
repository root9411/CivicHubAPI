using SharedLibrary.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Application.Application.Interface
{
    public interface IWaterReppository
    {
        Task<List<WaterBoard>> GetAllAsync();
        Task<List<string>> GetBoardsAsync();
        Task<List<WaterBoard>> GetserviceByboardsAsync(string boards);
    }
}
