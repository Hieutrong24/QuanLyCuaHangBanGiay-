using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_QL_BanGiay
{
    public class LogDTO
    {
        public int LogID { get; set; }
        public string Username { get; set; }
        public string Action { get; set; }
        public string Detail { get; set; }
        public DateTime Time { get; set; }
        public string IpAddress { get; set; }
    }
}
