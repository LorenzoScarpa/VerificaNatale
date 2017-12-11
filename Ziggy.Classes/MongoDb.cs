using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace Ziggy.Classes
{
    public class MongoDb
    {
        public User GetUser(User user)
        {
            IMongoCollection<User> userCollection = database.GetCollection<User>("user");
            return userCollection.Find(_ => _.Email == user.Email && _.PasswordClearText == user.PasswordClearText).FirstOrDefault();
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