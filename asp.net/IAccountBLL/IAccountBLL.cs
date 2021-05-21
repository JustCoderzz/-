using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAccountBLL
{
    public  interface IAccountBLL
    {
        SystemUser Login(string username, string pwd);
    }
}
