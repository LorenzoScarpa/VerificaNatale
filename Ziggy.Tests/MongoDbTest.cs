using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ziggy.Classes;
using System.Collections.Generic;
using Ziggy.Tests.Mocks;

namespace Ziggy.Tests
{
    [TestClass]
    public class MongoDBTest
    {
        [TestMethod]
        public void EditOrderStatus_Should_Return_True()
        {
            Order order = new Order();
            MongoDbMock dbm = new MongoDbMock();
            order.Id = "123";
            order.Status = Status.ReadyToSend;
            Assert.IsTrue(dbm.EditOrderStatus(order.Id, order.Status));
        }

        [TestMethod]
        public void GetOrderById_Should_Return_Order()
        {
            Order order = new Order();
            MongoDbMock dbm = new MongoDbMock();
            order.Id = "321";
            Order result = dbm.GetOrderById(order.Id);
            Assert.IsInstanceOfType(result, typeof(Order));
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_Orders_List()
        {
            MongoDbMock dbm = new MongoDbMock();
            var results = dbm.GetAllOrders();
            Assert.IsInstanceOfType(results, typeof(List<Order>));
        }

        [TestMethod]
        public void GetUser_Should_Return_User()
        {
            MongoDbMock dbm = new MongoDbMock();
            User user = new User
            {
                Email = "test@gmail.com",
                Password = "password"
            };
            Assert.IsInstanceOfType(user, typeof(User));
        }

        [TestMethod]
        public void GetAllToys_Should_Return_Toys_List()
        {
            MongoDbMock dbm = new MongoDbMock();
            var results = dbm.GetAllToys();
            Assert.IsInstanceOfType(results, typeof(List<Toy>));
        }
    }
}