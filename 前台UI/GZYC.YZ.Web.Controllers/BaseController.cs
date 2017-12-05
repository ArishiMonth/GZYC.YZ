using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using GZYC.YZ.Models.Common;
using GZYC.YZ.Web.Common;

namespace GZYC.YZ.Web.Controllers
{
    [CustomHandleError(IsHandleException = true)]
    public abstract class BaseController : Controller
    {
       

        /// <summary>
        /// 获取当前用户客户端ip
        /// </summary>
        /// <returns></returns>
        private string GetCurrentUserIp()
        {
            string userIP;
            userIP = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_VIA"] == null ? System.Web.HttpContext.Current.Request.UserHostAddress : System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            return userIP;
        }
    }
}
