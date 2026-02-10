using Microsoft.EntityFrameworkCore;
//using Newtonsoft.Json;
using System.Text.Json;
using SharedLibrary.Application.Application.Dtos;
using SharedLibrary.Application.Application.Interface;
using SharedLibrary.Application.Dtos;



namespace CivicHubKiosk.Repositories
{
    public class PageRepository : IPageRepository 
    {
        private readonly CivicHubDbContext _context;

        public PageRepository(CivicHubDbContext context)
        {
            _context = context;
        }

        public async Task<PageDto> GetPageContantAsync(string pageKey)
        {
            var data = await
                (from p in _context.InvPages
                 join ps in _context.PageSections on p.PageId equals ps.PageId
                 join sc in _context.SectionComponents on ps.SectionId equals sc.SectionId
                 join c in _context.Components on sc.ComponentId equals c.ComponentId
                 join cc in _context.ComponentContent
                     .Where(x => x.IsActive)
                     on sc.SectionComponentId equals cc.SectionComponentId into ccg
                 from cc in ccg.DefaultIfEmpty()
                 where p.PageKey == pageKey && ps.IsActive
                 orderby sc.SortOrder
                 select new
                 {
                     ComponentType = c.ComponentType ?? "",
                     SortOrder = sc.SortOrder,
                     Config = sc.Config ?? "", 
                     ContentKey = cc != null ? cc.ContentKey : null,
                     ContentValue = cc != null ? cc.ContentValue : null
                 })
                .ToListAsync();   

            
            var page = new PageDto
            {
                PageKey = pageKey,
                Components = data
                    .GroupBy(x => new { x.SortOrder, x.ComponentType,x.Config })
                    .Select(g => new ComponentDto
                    {
                        Type = g.Key.ComponentType,
                        Order = g.Key.SortOrder,

                        Config = string.IsNullOrWhiteSpace(g.Key.Config)
                        ? null
                        : JsonSerializer.Deserialize<Dictionary<string, object>>(g.Key.Config),

                        Text = g
                            .Where(x => x.ContentKey != null)
                            .ToDictionary(
                                x => x.ContentKey!,
                                x => x.ContentValue!
                            )
                    })
                    .OrderBy(x => x.Order)
                    .ToList()
            };

            return page;
        }



        public async Task<List<LanguageListDto>> GetLanguagesAsync()
        {
            return await _context.InvLanguageList
                .Where(l => l.IsActive)
                .Select(l => new LanguageListDto
                {
                    Id = l.Id,
                    LanguageText = l.LanguageText,
                    LanguageCode = l.LanguageCode,
                    LangFlag = l.LangFlag,
                    config = l.config,
                    IsActive = l.IsActive
                })
                .ToListAsync();
        }





    }
}
