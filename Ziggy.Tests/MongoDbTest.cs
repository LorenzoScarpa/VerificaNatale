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
            try
            {
                dbm.EditOrderStatus(order.Id, order.Status);
                Assert.Fail("EditOrderStatus non ha lanciato l'eccezione");
            }
            catch (ArgumentException ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(Order));
            }
        }

        [TestMethod]
        public void GetOrderById_Should_Return_Order()
        {
            Order order = new Order();
            MongoDbMock dbm = new MongoDbMock();
            order.Id = "321";
            try
            {
                dbm.GetOrderById(order.Id);
                Assert.Fail("GetOrderById non ha lanciato l'eccezione");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(ArgumentException));
            }
        }

        [TestMethod]
        public void GetAllOrders_Should_Return_Orders_List()
        {
            MongoDbMock dbm = new MongoDbMock();
            var results = dbm.GetAllOrders();
            Assert.IsInstanceOfType(results, typeof(List<Order>));
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