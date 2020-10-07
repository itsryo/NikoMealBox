using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Odbc;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Newtonsoft.Json;
using NikoMealBox.DataAccess.Repository;
using NikoMealBox.Models;
using NikoMealBox.Models.DataTable;

namespace NikoMealBox.Controllers.WebAPI
{
    // 所需model在
    //Models.OrderApi.Models
    [RoutePrefix("api/[Controller]/[action]")]
    public class OrdersController : ApiController
    {
        private OrderRepository _repo = new OrderRepository();
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Orders
        public IQueryable<Orders> GetOrders()
        {
            return db.Orders;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(Orders))]
        public IHttpActionResult GetOrders(int id)
        {
            Orders orders = db.Orders.Find(id);
            if (orders == null)
            {
                return NotFound();
            }

            return Ok(orders);
        }

        // PUT: api/Orders/PutOrdersStatus
        [ResponseType(typeof(Orders))]
        [HttpPut]
        public IHttpActionResult PutOrdersStatus([FromBody]string jsonData)
        {
            var data = JsonConvert.DeserializeObject<OrderApiModels.PutOrdersStatusModel>(jsonData);
            Orders order = _repo.Get(x => x.Id == data.id);
            if (order == null)
            {
                return NotFound();
            }
            order.OrderStatusRefId = data.statusid;
            order.FinishDate = DateTime.Now;
            _repo.Update(order);

            return Ok(order);
        }

        // POST: api/Orders
        [ResponseType(typeof(Orders))]
        public IHttpActionResult PostOrders(Orders orders)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Orders.Add(orders);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = orders.Id }, orders);
        }

        // DELETE: api/Orders/DeleteOrders/5
        [ResponseType(typeof(Orders))]
        [HttpDelete]
        public IHttpActionResult DeleteOrders(int id)
        {
            Orders order = _repo.Get(x => x.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            _repo.Delete(order);
            return Ok(order);
        }
    }
}