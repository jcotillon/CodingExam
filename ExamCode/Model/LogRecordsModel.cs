using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCode
{
    class LogRecordsModel
    {
        public string Account { get; set; }

        public List<LogsModel> Logs { get; set; }
    }
}
