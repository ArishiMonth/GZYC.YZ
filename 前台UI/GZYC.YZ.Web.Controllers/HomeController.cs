using System.Web.Mvc;
using GZYC.YZ.IBusiness;
using GZYC.YZ.Models.Common;

namespace GZYC.YZ.Web.Controllers
{
    public class HomeController : Controller
    {
        private ILogger _logger;

        public HomeController(ILogger log)
        {
            _logger = log;
        }
        public ActionResult Index()
        {
            _logger.Info("IOC注入成功");
            _logger.Wirte(new LogInfo {Luser = "admin",Lip = "127.0.0.1",Lcontent = "日志记录1"});
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}