using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    internal interface IUserRoleData
    {
        Task<IEnumerable<DataSelectDto>> GetDataSelects();
    }
}
