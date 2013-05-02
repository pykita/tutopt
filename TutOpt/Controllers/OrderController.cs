using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tutopt.Service;

namespace Tutopt.Controllers
{
    public class OrderController : Controller
    {
        public readonly IOrderService m_OrderService;

        public OrderController()
        {
            m_OrderService = new OrderService();
        }

        public ActionResult Index()
        {
            return View(m_OrderService.GetOrderViewModel());
        }
    }
}