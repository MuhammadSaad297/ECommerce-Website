using ECommerce_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ECommerce_Website.Controllers
{
    public class HomeController : Controller
    {
        Model1 db = new Model1();
        public ActionResult IndexCustomer()
        {
            return View();
        }

        public ActionResult IndexAdmin()
        {
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
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Admin admin)
        {
            //Please count record from database admin table
            //where table email and password is matched
            //with out posted email and password
            //if email and password is matched result is 1
            //if not result is 0
            Admin a = db.Admins.Where(x => x.Admin_Email == admin.Admin_Email && x.Admin_Password == admin.Admin_Password).FirstOrDefault();
            if (a != null)
            {
                Session["Admin"] = a;
                return RedirectToAction("IndexAdmin", "Home");
            }
            else
            {
                ViewBag.Message = "Invalid Email and Password";
                return View();
            }

        }
        public ActionResult Feedback()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Shop(int? id)
        {
            ShopModel s = new ShopModel();//s ky ander 2 lists hein

            s.cat = db.Categories.ToList();
            if (id == null)
                s.pro = db.Products.ToList();
            else
                s.pro = db.Products.Where(p => p.Category_FID == id).ToList();
            return View(s);

        }
        public ActionResult AddToCart(int id) //Product id
        {
            List<Product> list;
            if(Session["myCart"]==null)
            {list= new List<Product>(); }
            else
            {
                list = (List<Product>)Session["myCart"];//session sy nikal kr list rakhni hai
                    }

            list.Add(db.Products.Where(p => p.Product_ID == id).FirstOrDefault());//jo product psnd ki hai wo add kr do
            list[list.Count - 1].Pro_Quantity = 1; //direct 0 b likha ja skta hai
            Session["myCart"] = list; //session is grand global State(product ka table store kiya ja skta //kisi qism ki info rakh skty hein) that can be access anywhere//cart,bill,order booking
            return RedirectToAction("Cart");
        }
        public ActionResult MinusFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["myCart"];

            list[RowNo].Pro_Quantity--;
            Session["myCart"] = list;
            return RedirectToAction("Cart");
        }
        public ActionResult PlusToCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["myCart"];

            list[RowNo].Pro_Quantity++;
            Session["myCart"] = list;
            return RedirectToAction("Cart");
        }
        public ActionResult RemoveFromCart(int RowNo)
        {
            List<Product> list = (List<Product>)Session["myCart"];

            list.RemoveAt(RowNo);
            Session["myCart"] = list;
            return RedirectToAction("Cart");
        }
        public ActionResult PayNow(Order o)
        {
            o.Order_Date = System.DateTime.Now;
            o.Order_Status = "paid";
            o.Order_Type = "Sale";
            Session["Order"] = o;
            return Redirect("https://www.paypal.com");
        }
        public ActionResult OrderBooked()
        {
            Order o = (Order)Session["Order"];
            return View();
        }
        public ActionResult saad()
        {
            return View();
        }
    }
}