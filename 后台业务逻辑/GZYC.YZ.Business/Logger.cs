using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZYC.YZ.IBusiness;
using GZYC.YZ.IDataAccess;
using GZYC.YZ.Models.Common;
using GZYC.YZ.Models.EFModel;
using log4net;
using log4net.Config;

namespace GZYC.YZ.Business
{
    public class Logger:ILogger
    {
     
        private readonly log4net.ILog _logError;
        private readonly log4net.ILog _logInfo;
        private readonly ILoggerDB _dal;
        public Logger(ILoggerDB dal)
        {
            var config = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Configs//log4net.config");
            XmlConfigurator.ConfigureAndWatch(new FileInfo(config));
            _logError = LogManager.GetLogger("errorAppender");
            _logInfo = LogManager.GetLogger("infoAppender");
            _dal = dal;

        }
        public void Info(string format, params object[] args)
        {
            _logInfo.InfoFormat(format, args);
        }

        public void Wirte(LogInfo message)
        {
            var data = new tb_Log
            {
                Ltype = message.Ltype,
                DeleteMark = message.DeleteMark,
                Lcontent = message.Lcontent,
                Ldate = message.Ldate,
                Lip = message.Lip,
                Ltitle = message.Ltitle,
                Luser = message.Luser
            };
            _dal.Insert(data);
        }

        public void Error(string format, params object[] args)
        {
            _logError.ErrorFormat(format, args);
        }
    }
}
