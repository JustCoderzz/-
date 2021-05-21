using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Common.App.Common;
using Models;
using StudentMange.Models;

namespace StudentMange.Controllers
{
    public class SignInOrUpController : Controller
    {
        IAccountBLL.IAccountBLL account = new AccountBLL.AccountBLL();
        private User.UserDBContent db= new User.UserDBContent();
        
        // GET: SignInOrUp
        public ActionResult Login()
        {
            
            ViewBag.msg ="";
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//有效的校验码，防止被恶意攻击
        public JsonResult Login(string Username,string Password)
        {

            SystemUser user = account.Login(Username,Password);
            if (user == null)
            {
                return Json(JsonHandler.CreateMessage(0, "用户名或密码错误"), JsonRequestBehavior.AllowGet);
            }

            AccountModel act = new AccountModel();
            act.Id = user.SystemUserId;
            act.TrueName = user.TrueName;
            Session["Account"] = act;

            return Json(JsonHandler.CreateMessage(1, ""), JsonRequestBehavior.AllowGet);






        }
        [HttpPost]
        [ValidateAntiForgeryToken]//有效的校验码，防止被恶意攻击
        public ActionResult SignIn([Bind(Include = "Myname,Passsword")] User user)
        {

            if (ModelState.IsValid)//判断模型状态是否有效
            {
                db.users.Add(user);//将实体传入数据库
                db.SaveChanges();//保存修改
                return RedirectToAction("Login");//重定向去INDEX视图


            }
            return View();


        }

        public  ActionResult SignIn()
        {
            return View();
        }
        
    }
}
/* User u = db.users.Find(user.Myname);
                if (u == null)
                {
                    ViewBag.msg = "null";

                } else if (user.Passsword !=u.Passsword)
                {
                    ViewBag.msg = "no";
                }
                else
                {
                    
                    Session["Username"] = user.Myname;
                    HttpCookie cookie = new HttpCookie("user");
                    cookie.Expires = DateTime.Now.AddDays(7);
                    cookie["Username"] = user.Myname;
                    cookie["Password"] = user.Passsword.ToString();
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Student");
                }
               */