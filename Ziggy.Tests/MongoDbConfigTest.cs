using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ziggy.Classes;

namespace Ziggy.Tests
{
    [TestClass]
    public class MongoDBConfigTest
    {
        public MongoDBConfigTest()
        {
        }

        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void DBName_Should_Have_Value()
        {
            Assert.AreEqual("DBName", MongoDBConfig.DBName);
        }

        [TestMethod]
        public void Username_Should_Have_Value()
        {
            Assert.AreEqual("Username", MongoDBConfig.Username);
        }

        [TestMethod]
        public void Password_Should_Have_Value()
        {
            Assert.AreEqual("Password", MongoDBConfig.Password);
        }

        [TestMethod]
        public void Host_Should_Have_Value()
        {
            Assert.AreEqual("Host", MongoDBConfig.Host);
        }

        [TestMethod]
        public void Port_Should_Have_Value()
        {
            Assert.AreEqual(13000, MongoDBConfig.Port);
        }
    }
}