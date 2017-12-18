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
    public class Toys
    {
        private IMongoDatabase db;
        private ObjectId Id = ObjectId.GenerateNewId();

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<Toy> collection = db.GetCollection<Toy>("toys");
            collection.InsertOne(new Toy
            {
                Id = Id.ToString(),
                Name = "puzzle",
                Amount = 100,
                Cost = 19
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("toys");
            }
        }

        [TestMethod]
        public void GetAllToys_Should_Return_Toys_List()
        {
            var db = new ZiggiMongoDb();
            var list = db.GetAllToys();
            Assert.IsInstanceOfType(list, typeof(List<Toy>));
        }
    }
}
