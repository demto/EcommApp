using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Core.Specification;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IBasketRepository _basketRepo;
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow, IBasketRepository basketRepo)
        {
            _uow = uow;
            _basketRepo = basketRepo;
        }

        public async Task<Order> CreateOrderAsync(string buyerEmail, int deliveryMethodId, string basketId, Address shippingAddress)
        {
            var basket = await _basketRepo.GetBasketAsync(basketId);
            var items = new List<OrderItem>();

            foreach (var item in basket.Items)
            {
                var productItem = await _uow.Repository<Product>().GetByIdAsync(item.Id);
                var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);

                var orderItem = new OrderItem(itemOrdered, productItem.Price, item.Quantity);
                items.Add(orderItem);
            }

            var deliveryMethod = await _uow.Repository<DeliveryMethod>().GetByIdAsync(deliveryMethodId);

            var subTotal = items.Sum(i => i.Price * i.Quantity);

            var order = new Order(items, buyerEmail, shippingAddress, deliveryMethod, subTotal);

            _uow.Repository<Order>().Add(order);
            var result = await _uow.Complete();

            if (result <= 0)
            {
                return null;
            }

            await _basketRepo.DeleteBasketAsync(basketId);

            return order;
        }

        public async Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _uow.Repository<DeliveryMethod>().ListAllAsync();
        }

        public async Task<Order> GetIrderByIdAsync(int id, string buyerEmail)
        {
            var spec = new OrdersWithItemsAndORderingSpecification(id, buyerEmail);
            return await _uow.Repository<Order>().GetEntityWithSpec(spec);
        }

        public async Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            var spec = new OrdersWithItemsAndORderingSpecification(buyerEmail);
            return await _uow.Repository<Order>().ListAll(spec);
        }
    }
}