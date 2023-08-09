using Medicine.API.Context;
using Medicine.API.Services.IData;
using Microsoft.EntityFrameworkCore;

namespace Medicine.API.Services.Data
{
    public class RepositoryForDynamicData : IForDynamicData
    {
        private readonly AppDBContext _context;
        public RepositoryForDynamicData(AppDBContext appDBContext)=>_context = appDBContext;
        public async Task<IEnumerable<T>> GetAllData<T>(T Data) where T : class
        {
            using var context = _context;
            return await context.Set<T>().ToListAsync();

        }
    }
}
