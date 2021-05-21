using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysModuleTreeDAL
{
    public class SysModuleTreeDAL : SysModuleTreeIDAL.SysModuleTreeIDAL
    {
        public IQueryable<SystemModule> GetList(权限管理上下文 db)
        {
            IQueryable<SystemModule> list = db.SystemModules.AsQueryable();
            return list;
        }
    }
}
