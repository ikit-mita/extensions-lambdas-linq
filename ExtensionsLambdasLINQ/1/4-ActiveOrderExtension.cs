
namespace ExtensionsLambdasLINQ.ActiveOrderExtension
{
    public interface Order
    {
        bool IsActive { get; }
        // other properties and methods
    }

    public class User
    {
        private string _key = $"{System.DateTime.Now.Millisecond}";
        public Order Order { get; set; }
        // other properties and methods
    }

    // HELPER IMPLEMENTATION
    public static class UserExtensions
    {
        public static bool HasActiveOrder(this User user)
        {
            // var key = user._key; // Error CS0122  'User._key' is inaccessible due to its protection level
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
