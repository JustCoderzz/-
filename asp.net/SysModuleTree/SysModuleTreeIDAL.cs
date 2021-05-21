using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysModuleTreeIDAL
{
    public interface SysModuleTreeIDAL

    {
        IQueryable<SystemModule> GetList(权限管理上下文 db);
    }
}
