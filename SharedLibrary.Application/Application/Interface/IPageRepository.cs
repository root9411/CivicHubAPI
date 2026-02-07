using SharedLibrary.Application.Application.Dtos;
using SharedLibrary.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.Application.Application.Interface
{
    public interface IPageRepository
    {

        Task<PageDto> GetPageContantAsync(string pageKey);


    }
}
