using Medicine.Models;
using NPOI.SS.Formula.Functions;

namespace Medicine.API.Services.IData
{
    public interface IDoctors
    {
        Task<IEnumerable<Doctors>> GetListDoctors();
        Task<bool> Insert(Doctors doctor);
        Task<bool> Update(Doctors doctor);
        Task<bool> Delete(int id);
        Task<IEnumerable<Doctors>> GetListByName(string name);
        Task<Doctors> GetListById(int id);
        Task<IEnumerable<Doctors>> GetListByPage(int page,int limit);
    }
}
