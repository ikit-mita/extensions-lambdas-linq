
namespace ExtensionsLambdasLINQ.ActiveOrderMethod
{
    public interface Order
    {
        bool IsActive { get; }
        // other properties and methods
    }

    public class User
    {
        public Order Order { get; set; }
        // METHOD IMPLEMENTATION
        public bool HasActiveOrder()
        {
            return Order != null && Order.IsActive;
        }
        // other properties and methods
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
