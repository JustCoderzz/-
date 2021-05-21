using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAccountDAL
{
    public interface IAccountDAL
    {
        SystemUser Login(string username, string pwd);
    }
}
