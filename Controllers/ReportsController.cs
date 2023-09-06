using ECommerce_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce_Website.Controllers
{
    public class ReportsController : Controller
    {
        Model1 db = new Model1();
        // GET: Reports
        public ActionResult PurchaseReport()
        {
            var o= db.OrderDetails.ToList();
            return View();
        }
        public ActionResult SaleReport()
        {
            
            return View();
        }
        public ActionResult ProfitandLossReport()
        {
            
            return View();
        }
        public ActionResult StockReport()
        {

            return View();
        }
    }
}