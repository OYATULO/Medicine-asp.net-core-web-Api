using Medicine.Models;

namespace Medicine.API.Services.IData
{
    public interface IPatients
    {
        Task<IEnumerable<Patients>> GetAllPattients();
        Task<bool> Insert(Patients item);
        Task<bool> Update(Patients item);
        Task<bool> Delete(int id);
        Task<IEnumerable<Patients>> GetListByName(string name);
        Task<Patients> GetListById(int id);
        Task<IEnumerable<Patients>> GetListByPage(int page, int limit);
    }
}
