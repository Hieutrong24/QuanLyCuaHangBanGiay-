using DAL_QL_BanGiay;
using DTO_QL_BanGiay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS_QL_BanGiay
{
    public class LogBUS
    {
        private LogDAL logDAL = new LogDAL();

        public void WriteLog(string username, string action, string detail)
        {
            logDAL.SaveLog(username, action, detail);
        }
        public LogDTO LayLogMoiNhat()
        {
            return logDAL.GetLastLog();
        }
    }
}
