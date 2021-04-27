using System;
using System.Data;
using System.Text;

namespace DataBaseOP.Controllers
{
    public class ReportController : BaseController
    {
        public DataTable GetRealizationsResult(DateTime beginDate, DateTime endDate)
        {
            return Context.GetRealizationsResult(beginDate, endDate);
        }
    }
}
