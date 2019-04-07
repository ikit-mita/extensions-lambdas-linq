
namespace ExtensionsLambdasLINQ.ActiveOrderInline
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

    public class Processor
    {
        public void Process(User user)
        {
            // some logic
            // INLINE IMPLEMENTATION
            bool hasActiveOrder = user.Order != null && user.Order.IsActive;
            // other logic
        }
    }
}
