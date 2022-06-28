using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.ViewModel;

namespace WebApplication1.Repositories
{
    public class MasterRepositories
    {

        OrderDATAEntities dbobj = new OrderDATAEntities();

        public List<OrderViewModel> GetAllorders()
        {
            List<Product> produ = dbobj.Products.ToList();
            List<Customer> custo = dbobj.Customers.ToList();
            List<Order> orde = dbobj.Orders.ToList();

            var order = from Ord in orde
                        join pro in produ on Ord.product_id equals pro.id into Table1
                        from pro in Table1.ToList()
                        join Cust in custo on Ord.Customer_id equals Cust.Id into Table2
                        from Cust in Table2.ToList()
                        select new OrderViewModel
                        {
                            id = Ord.id,
                            First_Name = Cust.First_Name + Cust.Last_name,
                            Customer_id  = Cust.Id,
                            product_id= pro.id,
                            Name = pro.Name,
                            Remarks = Ord.Remarks,
                        };
            return order.ToList();
        }


        public OrderViewModel GetAllorder(int? id)
        {

            OrderViewModel OrderView = (from Ord in dbobj.Orders
                                       join pro in dbobj.Products on Ord.product_id equals pro.id
                                       join Cust in dbobj.Customers on Ord.Customer_id equals Cust.Id
                                       where Ord.id == id
                                      select new OrderViewModel()
                                      {
                                          id = Ord.id,
                                          First_Name = Cust.First_Name + Cust.Last_name,
                                          Customer_id = Cust.Id,
                                          product_id = pro.id,
                                          Name = pro.Name,
                                          Remarks = Ord.Remarks,

                                      }).FirstOrDefault();
            return OrderView;
        }
        

    }
}