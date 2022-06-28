using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class OrderController : Controller
    {
        OrderDATAEntities dbobj = new OrderDATAEntities();
        MasterRepositories MastRepo = new MasterRepositories();

        // GET: Order
        public ActionResult Order()
        {
            var orderList = MastRepo.GetAllorders();
            return View(orderList);
        }

        // GET: Order/Details/5
        public ActionResult order_Details(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderList = MastRepo.GetAllorder(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // GET: Order/Create
        public ActionResult order_Create()
        {
            var customersList = dbobj.Customers.ToList();
            var productsList = dbobj.Products.ToList();
            ViewData["Customer"] = new SelectList(customersList, "Id", "First_Name");
            ViewData["Product"] = new SelectList(productsList, "id", "Name");
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Order_Create(OrderViewModel _OrderViewModel)
        {
            Order obj = new Order();
            try
            {
                if (ModelState.IsValid)
                {
                    obj.Customer_id = _OrderViewModel.Customer_id;
                    obj.product_id = _OrderViewModel.product_id;
                    obj.Remarks = _OrderViewModel.Remarks;
                    dbobj.Orders.Add(obj);
                    dbobj.SaveChanges();
                    return RedirectToAction("Order");
                }
                return View(_OrderViewModel);
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult order_Edit(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var customersList = dbobj.Customers.ToList();
            var productsList = dbobj.Products.ToList();
            ViewData["Customer"] = new SelectList(customersList, "Id", "First_Name");
            ViewData["Product"] = new SelectList(productsList, "id", "Name");
            var orderlist = MastRepo.GetAllorder(id);
            if (orderlist == null)
            {
                return HttpNotFound();
            }
            return View(orderlist);
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult order_Edit(OrderViewModel _OrderViewModel)
        {
            Order obj = new Order();
            try
            {
                obj.id = _OrderViewModel.id;
                obj.Customer_id = _OrderViewModel.Customer_id;
                obj.product_id = _OrderViewModel.product_id;
                obj.Remarks = _OrderViewModel.Remarks;
                if (ModelState.IsValid)
                {
                    dbobj.Entry(obj).State = EntityState.Modified;
                    dbobj.SaveChanges();
                    return RedirectToAction("Order");
                }
                return View(_OrderViewModel);
            }
            catch
            {
                return View();
            }

        }

        // GET: Order/Delete/5
        public ActionResult order_Delete(int id)
        {
            if (id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var orderlist = MastRepo.GetAllorder(id);
            if (orderlist == null)
            {
                return HttpNotFound();
            }
            return View(orderlist);
        }

        // POST: Order/Delete/5
        [HttpPost, ActionName("order_Delete")]
        public ActionResult order_Delete(int id, FormCollection collection)
        {
            try
            {
                Order ord = dbobj.Orders.Find(id);
                dbobj.Orders.Remove(ord);
                dbobj.SaveChanges();
                return RedirectToAction("Order");
            }
            catch
            {
                return View();
            }
        }
    }
}
