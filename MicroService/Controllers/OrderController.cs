using MicroService.DAO;
using MicroService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MicroService.Controllers
{
    public class OrderController : ApiController
    {
        [Route("api/Order"), HttpGet]
        public List<Order> GetOrders()
        {
            return OrderDao.GetOrders();
        }

        [Route("api/Order{id}"), HttpGet]
        public Order GetOrder([FromUri]int id)
        {
            return OrderDao.GetOrder(id);
        }
    }
}