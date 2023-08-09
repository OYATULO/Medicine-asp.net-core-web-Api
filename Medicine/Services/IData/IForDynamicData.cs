namespace Medicine.API.Services.IData
{
    public interface IForDynamicData
    {
       Task<IEnumerable<T>> GetAllData<T>(T Data) where T : class;
    }
}
