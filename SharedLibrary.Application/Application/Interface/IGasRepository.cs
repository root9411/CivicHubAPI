using SharedLibrary.Domain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Application.Application.Interface
{
    public interface IGasRepository
    {

        Task<List<GasBoard>> GetAllAsync();
        Task<List<string>> GetProvidersAsync();
        Task<List<GasBoard>> GetDistrictByProviderAsync(string provider);
        Task<List<GasBoard>> GetsubDistrictByDistrictAsync(string District);

    }
}
