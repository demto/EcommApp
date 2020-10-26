using Core.Entities.OrderAggregate;

namespace Core.Specification
{
    public class OrderByPaymentIntentWithItemsSpecification : BaseSpecification<Order> {

        public OrderByPaymentIntentWithItemsSpecification(string paymentIntentId)
            : base(o => o.PaymentIntentId == paymentIntentId)
        {
            
        }
    }
}