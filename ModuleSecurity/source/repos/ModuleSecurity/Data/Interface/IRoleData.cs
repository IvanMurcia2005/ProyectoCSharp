using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interface
{
    public interface IRoleData
    {
        Task<IEnumerable<DataSelectDto>> GetDataSelects();
    }
}
