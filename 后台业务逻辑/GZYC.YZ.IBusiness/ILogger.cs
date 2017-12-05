using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZYC.YZ.Models.Common;

namespace GZYC.YZ.IBusiness
{
    public interface ILogger
    {
        void Info(string format, params object[] args);
        void Wirte(LogInfo message);
        void Error(string format, params object[] args);
    }
}
