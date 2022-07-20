using MVC_CourseWebsite.Areas.Admin.Models.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_CourseWebsite.Areas.Admin.Controllers
{
    //使用設定好的Attribute，並讓每一頁需要登入的頁面繼承BaseController，只有驗證通過才能進入每一頁
    [LoginControl]
    public class BaseController : Controller
    {

    }
}