using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CourseWebsite.Areas.Admin.Models.Attributes
{
    // 自己設定一個Attribute做為每頁是否有登入的驗證，可在controller中使用(BaseController用來驗證)
    //IActionFilter => control cookie，實作介面叫出內容
    public class LoginControl : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //if (!HttpContext.Current.User.Identity.IsAuthenticated)
            //    filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
            if (UserStatic.UserID==0)
                filterContext.HttpContext.Response.Redirect("/Admin/Login/Index");
        }
    }
}