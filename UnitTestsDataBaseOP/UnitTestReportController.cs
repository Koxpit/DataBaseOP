using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBaseOP;
using System;
using System.Data;

namespace UnitTestsDataBaseOP
{
    [TestClass]
    public class UnitTestReportController
    {
        [TestMethod]
        public void TestGetRealizationsResult()
        {
            DataBaseOP.Controllers.ReportController reportController = new DataBaseOP.Controllers.ReportController();
            decimal amountDue = 800, cost = 800;
            bool result1 = false, result2 = false;
            DateTime beginDate = new DateTime(2021, 02, 11);
            DateTime endDate = new DateTime(2022, 03, 12);
            DataTable reportResult = new DataTable();

            reportResult = reportController.GetRealizationsResult(beginDate, endDate);

            decimal amountDueResult = (decimal)reportResult.Rows[0][0];
            decimal costResult = (decimal)reportResult.Rows[0][1];

            if (amountDue == amountDueResult) 
                result1 = true;
            if (cost == costResult) 
                result2 = true;

            Assert.AreEqual(result1, result2);
        }
    }
}
