using Ziggy.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ziggy.Tests.Mocks
{
    class MongoDbMock
    {

        public User GetUser(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("User's Email or Password has not  value");
            return new User();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            return new List<Toy>();
        }

        public Order GetOrderById(string id)
        {
            return new Order();
        }

        public bool EditOrderStatus(string id, Status status)
        {
            return true;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return new List<Order>();
        }
    }
}