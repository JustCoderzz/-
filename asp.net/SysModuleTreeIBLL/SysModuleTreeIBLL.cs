using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysModuleTreeIBLL
{
    public interface SysModuleTreeIBLL
    {
        List<SystemModule> GetList(string pid);
    }
}
