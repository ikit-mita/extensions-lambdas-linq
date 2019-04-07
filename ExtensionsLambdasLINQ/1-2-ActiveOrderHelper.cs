
namespace ExtensionsLambdasLINQ.ActiveOrderHelper
{
    public interface Order
    {
        bool IsActive { get; }
        // other properties and methods
    }

    public class User
    {
        public Order Order { get; set; }
        // other properties and methods
    }

    // HELPER IMPLEMENTATION
    public class UserHelper
    {
        public static bool HasActiveOrder(User user)
        {
            return user.Order != null && user.Order.IsActive;
        }
    }

    public class Processor
    {
        public void Process(User user)
        {
            // some logic
            bool hasActiveOrder = UserHelper.HasActiveOrder(user);
            // other logic
        }
    }
}
