using Entity;
using Entity.Model.Security;

namespace Data.Interface
{
    internal interface IModuleData
    {
        Task<IEnumerable<DataSelectDto>> GetAllSelect();
    }
}
