using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using GZYC.YZ.Models.Common;

namespace GZYC.YZ.Web.Common
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        /// <summary>
        /// 是否对异常进行自定义处理
        /// </summary>
        public bool IsHandleException { get; set; }

        public override void OnException(ExceptionContext filterContext)
        {
           
            if (!IsHandleException)
            {
                base.OnException(filterContext);
                return;
            }

            if (filterContext.ExceptionHandled)
            {
                return;
            }

            if (new HttpException(null, filterContext.Exception).GetHttpCode() != 500)
            {
                return;
            }

            if (!ExceptionType.IsInstanceOfType(filterContext.Exception))
            {
                return;
            }

            
            //var logInfo = new LogInfo
            //{
            //    Luser = UserContext.Current.User.Name,
            //    Ldate = DateTime.Now,
            //    Lip = IP.GetUserIp(),
            //    Ltype = (int)OperatingType.Exception,
            //    Lcontent = "Id:" + wrappedEx.ExceptionId + wrappedEx.InnerException.StackTrace
            //};

            //if (log != null)
            //{
            //    log.Wirte(logInfo);
            //    //日志文本
            //    log.Error(wrappedEx.ExceptionId + "/n" + wrappedEx.Message + wrappedEx.InnerException.StackTrace + "/n");
            //}

            //if (filterContext.HttpContext.Request.IsAjaxRequest())
            //{
            //    filterContext.Result = new JsonResult
            //    {
            //        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
            //        Data = new
            //        {
            //            error = true,
            //            errorId = wrappedEx.ExceptionId,
            //            message = wrappedEx.Message
            //        }
            //    };
            //}
            //else
            //{
            //    if (UserContext.Current == null)
            //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", Action = "Login" }));
            //    else
            //        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "Index" }));
            //}

            //filterContext.Controller.ViewData.Model = wrappedEx;
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}
