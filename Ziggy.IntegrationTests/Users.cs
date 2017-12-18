using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using System;
using Ziggy.Classes;
using ZiggyMongoDb = Ziggy.Classes.MongoDb;


namespace Ziggy.IntegrationTests
{
    [TestClass]
    public class Users
    {
        private IMongoDatabase db;
        private string email = "integration@test.com";
        private string password = "integration";
        private string screenName = "integration_user";

        [TestInitialize]
        public void Initialize()
        {
            MongoClientSettings settings = new MongoClientSettings();
            MongoClient client = new MongoClient(MongoDBConfig.ConnectionString);
            db = client.GetDatabase(MongoDBConfig.DBName);
            IMongoCollection<User> collection = db.GetCollection<User>("users");
            collection.InsertOne(new User
            {
                Email = email,
                Password = password,
                ScreenName = screenName
            });
        }

        [TestCleanup]
        public void Cleanup()
        {
            if (db != null)
            {
                db.DropCollection("users");
            }
        }

        [TestMethod]
        public void GetUser_Should_Return_User()
        {
            User user = new User();
            user.Email = email;
            user.Password = password;

            var db = new ZiggyMongoDb();
            var userResult = db.GetUser(user);
            Assert.IsInstanceOfType(userResult, typeof(User));
        }

        [TestMethod]
        public void GetUser_Should_Return_Exeption_When_Email_Or_Password_Are_Null()
        {
            var db = new ZiggyMongoDb();
            User user = new User();
            try
            {
                var result = db.GetUser(user);
                Assert.Fail("GetUser non ha lanciato l'eccezione");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.GetType());
                Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
            }
        }
    }
}