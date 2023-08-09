using Medicine.API.Context;
using Medicine.API.Extentions;
using Medicine.API.Services.IData;
using Medicine.Models;
using Microsoft.EntityFrameworkCore;

namespace Medicine.API.Services.Data
{
    public class RepositoryPatients : IPatients
    {
        private readonly AppDBContext _context;
        public RepositoryPatients(AppDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patients>> GetAllPattients()
        {
            using var context = _context;
            return await context.Patients.Include(x => x.District_data).ToListAsync();
        }
        public async Task<Patients> GetListById(int id)
        {
            try
            {
                return await _context.Patients.Include(x => x.District_data).FirstAsync(x => x.Pat_ID == id);
            }
            catch
            {
                return default!;
            }
        }
        public async Task<IEnumerable<Patients>> GetListByName(string name)
        {
            try
            {
                return await _context.Patients.Where(x => x.Pat_Name.Contains(name)).Include(x => x.District_data).ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Patients>();
            }
        }
        public async Task<IEnumerable<Patients>> GetListByPage(int page, int limit)
        {
            try
            {
                var data = await GetAllPattients();
                return Paginations.Pages(data, page, limit);
            }
            catch
            {
                return default!;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var data = await GetListById(id);
                _context.Patients.Remove(data);
                return await _context.SaveChangesAsync() >= 1;
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> Insert(Patients item)
        {
            try
            {
               _context.Add(item);
              return await _context.SaveChangesAsync() >= 1;
            }
            catch
            {
              return await Task.FromResult(false);
            }
        }

        public async Task<bool> Update(Patients item)
        {
            try
            {
                _context.Patients.Update(item);
                return await _context.SaveChangesAsync() >= 1;
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}
