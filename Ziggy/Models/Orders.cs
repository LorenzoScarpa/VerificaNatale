using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ziggy.Classes;
using ZiggyMongoDB = Ziggy.Classes.MongoDb;

namespace Ziggy.Models
{
    public class Orders
    {
        public List<Order> EntityList { get; set; }
        public decimal OrderPrice(string id)
        {
            decimal orderPrice = 0;
            ZiggyMongoDB db = new ZiggyMongoDB();
            List<Toy> toyList = db.GetAllToys().ToList();
            Order order = db.GetOrderById(id);
            foreach (var t1 in order.Toys)
                foreach (Toy t2 in toyList)
                    if (t1.Name == t2.Name)
                        orderPrice += t2.Cost;
            return orderPrice;
        }
    }
}