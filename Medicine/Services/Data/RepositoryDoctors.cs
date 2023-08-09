using Medicine.API.Context;
using Medicine.API.Extentions;
using Medicine.API.Services.IData;
using Medicine.Models;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;

namespace Medicine.API.Services.Data
{
    public class RepositoryDoctors : IDoctors
    {
        private readonly AppDBContext _context;
        public RepositoryDoctors(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }
        public async Task<IEnumerable<Doctors>> GetListDoctors()
        {
            return await _context.Doctors.Include(x => x.District_data).Include(x => x.Cabinet_data).Include(x => x.Spec_data).ToListAsync();
        }
        public async Task<bool> Insert(Doctors doctor)
        {
            try
            {
                _context.Add(doctor); 
                return await _context.SaveChangesAsync()>=1;
            }
            catch 
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                var data = await GetListById(id);
                _context.Doctors.Remove(data) ;
                return await _context.SaveChangesAsync()>=1;
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<bool> Update(Doctors doctor)
        {
            try
            {
                _context.Doctors.Update(doctor);
                return await _context.SaveChangesAsync() >= 1;
            }
            catch 
            {
                return await Task.FromResult(false);
            }
        }
        public async Task<IEnumerable<Doctors>> GetListByName(string name)
        {
            try
            {
               return  await _context.Doctors.Where(x => x.Doc_fullname.Contains(name)).Include(x => x.District_data).Include(x => x.Cabinet_data).Include(x => x.Spec_data).ToListAsync();
            }
            catch
            {
                return Enumerable.Empty<Doctors>();
            }
        }
        public async Task<Doctors> GetListById(int id)
        {
            try
            {
                return await _context.Doctors.Include(x => x.District_data).Include(x => x.Cabinet_data).Include(x => x.Spec_data).FirstAsync(x => x.Doc_ID == id);
            }
            catch
            {
                return default!;
            }
        }
        public async Task<IEnumerable<Doctors>> GetListByPage(int page, int limit)
        {
            try
            {
                var data = await GetListDoctors();
                return Paginations.Pages(data, page, limit);
            }
            catch
            {
                return default!;
            }
        }
    }

   

}
