using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountDAL
{
    public class AccountDAL : IAccountDAL.IAccountDAL, IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public SystemUser Login(string username, string pwd)
        {
            using(权限管理上下文 sp=new 权限管理上下文())
            {
                SystemUser user = sp.SystemUserss.SingleOrDefault(a => a.UserName == username && a.Password == pwd);
                return user;
            }
           
        }
    }
}
