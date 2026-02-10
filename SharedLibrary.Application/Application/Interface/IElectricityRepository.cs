using System;
using System.Collections.Generic;
using System.Text;

using SharedLibrary.Domain.Domain.Entities;

namespace SharedLibrary.Application.Application.Interface
{
    public interface IElectricityRepository
    {
        Task<List<ElectricityBoard>> GetAllAsync();
        Task<List<string>> GetStatesAsync();
        Task<List<ElectricityBoard>> GetBoardsByStateAsync(string state);
    }
}