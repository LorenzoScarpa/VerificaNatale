using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using MongoDB.Bson;
using Ziggy.Classes;
using System.Collections.Generic;
using ZiggiMongoDb = Ziggy.Classes.MongoDb;

namespace Ziggy.IntegrationTests
{
    [TestClass]
    public class Orders
    {
        private IMongoDatabase db;
        private ObjectId Id = ObjectId.GenerateNewId();

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Order> collection = db.GetCollection<Order>("orders");
            collection.InsertOne(new Order
            {
                Id = Id.ToString(),
                RequestDate = DateTime.Now,
                Kid = "test-kid",
                Status = Status.inProgress,
                Toys = new List<Toy>()
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("orders");
            }
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_Orders_List()
        {
            var db = new ZiggiMongoDb();
            var list = db.GetAllOrders();
            Assert.IsInstanceOfType(list, typeof(List<Order>));
        }

        [TestMethod]
        public void GetOrderById_Should_Return_Order()
        {
            var db = new ZiggiMongoDb();
            var order = db.GetOrderById(Id.ToString());
            Assert.IsInstanceOfType(order, typeof(Order));
        }

        [TestMethod]
        public void EditOrderStatus_Should_Return_True()
        {
            var db = new ZiggiMongoDb();
            var order = db.GetOrderById(Id.ToString());
            order.Status = Status.Done;
            Assert.IsTrue(db.EditOrderStatus(Id.ToString(), order.Status));
        }
    }
}
