using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GZYC.YZ.IDataAccess;
using GZYC.YZ.Models.EFModel;

namespace GZYC.YZ.DataAccess
{
    public class LoggerDB: BaseRepository<tb_Log>,ILoggerDB
    {

    }
}
