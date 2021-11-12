using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using _91app.Models;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authorization;

namespace _91app.Controllers
{
    [Authorize]
    public class OrderListController : Controller
    {
        private readonly Models.DB91app _dbContext;
        public OrderListController(Models.DB91app dbContext)
        {
            this._dbContext = dbContext;
        }

        //==========OrderList頁面=============
        public IActionResult Index()
        {
            return View();
        }

        //==========查看Product詳細資料=============
        [Route("/OrderList/ProductDetails/{orderItem}")]
        public IActionResult ProductDetails(string orderItem)
        {
            var product = _dbContext.Products.FirstOrDefault(x => x.ProductName == orderItem);

            return View(product);
        }

        //=========OrderList初始化=========
        [HttpPost]
        public object GetList()
        {
            return _dbContext.Orders.Where(x => x.UserName == User.Identity.Name)
                .Join(_dbContext.Products, x => x.OrderItem, y => y.ProductName, (x, y) => new ViewModelOrderList
                {
                    OrderId = x.OrderId,
                    OrderItem = x.OrderItem,
                    Price = y.Price,
                    Cost = y.Cost,
                    Status = x.Status,
                    Confirmed = x.Confirmed
                }).OrderBy(x=>x.OrderItem).ToList();
        }

        //========按下Confirm按鈕=========
        [HttpPost]
        public bool Confirm(List<ViewModelOrderList> ConfirmedList)
        {
            foreach (var order in ConfirmedList)
            {
                if (order.Confirmed == true)
                {
                    var o = _dbContext.Orders.FirstOrDefault(x => x.OrderId == order.OrderId);
                    o.Confirmed = true;
                    o.Status = "To be shipped";
                    try
                    {
                        _dbContext.SaveChanges();
                    }
                    catch (SqlException ex)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
