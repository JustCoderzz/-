using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountBLL
{
    public class AccountBLL : IAccountBLL.IAccountBLL
    {
        IAccountDAL.IAccountDAL db = new AccountDAL.AccountDAL();
        public SystemUser Login(string username, string pwd)
        {
            return db.Login(username, pwd);
        }
    }
}
