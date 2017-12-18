using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Diagnostics;
using System;

namespace Ziggy.Classes
{
    public class MongoDb
    {
        public User GetUser(User user)
        {
            user.EmailAndPasswordHasNotValueEx();
            IMongoCollection<User> usersCollection = database.GetCollection<User>("users");
            return usersCollection.Find(_ => _.Email == user.Email && _.Password == user.Password).FirstOrDefault();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            IMongoCollection<Toy> toysCollection = database.GetCollection<Toy>("toys");
            List<Toy> toysList = toysCollection.Find(new BsonDocument()).ToList();
            return toysList;
        }

        public Order GetOrderById(string id)
        {
            IMongoCollection<Order> ordersCollections = database.GetCollection<Order>("orders");
            Order order = ordersCollections.Find(_ => _.Id == id).FirstOrDefault();
            return order;
        }

        public bool EditOrderStatus(string id, Status status)
        {
            IMongoCollection<Order> ordersCollections = database.GetCollection<Order>("orders");
            var filter = Builders<Order>.Filter.Eq("_id", ObjectId.Parse(id));
            var update = Builders<Order>.Update.Set("Status", status);
            try
            {
                ordersCollections.UpdateOne(filter, update);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Order> GetAllOrders()
        {
            IMongoCollection<Order> ordersCollection = database.GetCollection<Order>("orders");
            List<Order> ordersList = ordersCollection.Find(new BsonDocument()).SortBy(e => e.RequestDate).ToList();
            var toysList = GetAllToys();
            return ordersList;
        }



        private IMongoDatabase database
        {
            get
            {
                return MongoConnection.Instance.Database;
            }
        }
    }
}