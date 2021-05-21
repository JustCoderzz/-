using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysModuleTreeBLL
{
    public class SysModuleTreeBLL : SysModuleTreeIBLL.SysModuleTreeIBLL
    {   private 权限管理上下文 db = new 权限管理上下文();
        SysModuleTreeIDAL.SysModuleTreeIDAL Rep = new SysModuleTreeDAL.SysModuleTreeDAL();
        public List<SystemModule> GetList(string pid)
        {
           
        

            IQueryable<SystemModule> queryData = Rep.GetList(db);
            var list = queryData.ToList();
            var result = from l in list
                         where l.ParentId == pid
                         select l;


            return result.ToList();
        
        }
    }
}
