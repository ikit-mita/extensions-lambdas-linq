
namespace ExtensionsLambdasLINQ.ActiveOrderExtension
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
    public static class UserExtensions
    {
        public static bool HasActiveOrder(this User user)
        {
            return user.Order != null && user.Order.IsActive;
        }
    }

    public class Processor
    {
        public void Process(User user)
        {
            // some logic
            bool hasActiveOrder = user.HasActiveOrder();
            // other logic
        }
    }
}
