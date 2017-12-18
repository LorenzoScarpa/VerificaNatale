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
            if (user != null)
                throw new ArgumentException("User has value");
            return new User();
        }

        public IEnumerable<Toy> GetAllToys()
        {
            return new List<Toy>();
        }

        public Order GetOrderById(string id)
        {
            Id_Testing(id);
            return new Order();
        }

        public bool EditOrderStatus(string id, Status status)
        {
            Id_Testing(id);
            return true;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return new List<Order>();
        }

        public static void Id_Testing(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
                throw new ArgumentException("ID has value");

        }
    }
}