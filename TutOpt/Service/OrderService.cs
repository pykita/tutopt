using System.Linq;
using Tutopt.Models.Orders;
using Tutopt.Models.Storage;
using Tutopt.Storage;

namespace Tutopt.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrdersStorage m_Storage;

        public OrderViewModel GetOrderViewModel()
        {
            return new OrderViewModel()
                {
                    OrderItems = m_Storage.Orders()
                        .Select(ConvertToOrderItem)
                        .ToArray()
                };
        }

        public OrderItem GetOrderItem(int id)
        {
            Orders item = m_Storage.Orders().FirstOrDefault(x => x.Id == id);
            return item == null
                       ? null
                       : ConvertToOrderItem(item);
        }

        public void SaveOrderItem(Models.Orders.OrderItem orderItem)
        {
            if (orderItem == null)
                return;

            var order = m_Storage.Orders()
                                 .FirstOrDefault(x => x.Id == orderItem.Id);
            if (order == null)
                m_Storage.AddOrder(ConvertToOrder(orderItem));
            else
            {
                order = ConvertToOrder(orderItem);
                m_Storage.UpdateOrders(order);
            }

            m_Storage.SaveChanges();

        }

        private Orders ConvertToOrder(OrderItem orderItem)
        {
            return new Orders
                {
                    Comment = orderItem.Comment,
                    CustomerName = orderItem.CustomerName,
                    DeliveryDate = orderItem.DeliveryDate,
                    DeliveryTypeId = orderItem.DeliveryTypeId,
                    Id = orderItem.Id,
                    Email = orderItem.Email,
                    OrderDate = orderItem.OrderDate,
                    OrderNumber1C = orderItem.OrderNumber1C,
                    OrderStatusId = orderItem.OrderStatusId,
                    PaymentTypeId = orderItem.PaymentTypeId
                };
        }

        private OrderItem ConvertToOrderItem(Orders order)
        {
            return new OrderItem()
                {
                    Comment = order.Comment,
                    CustomerName = order.CustomerName,
                    DeliveryDate = order.DeliveryDate,
                    DeliveryTypeId = order.DeliveryTypeId,
                    Email = order.Email,
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    OrderNumber1C = order.OrderNumber1C,
                    OrderStatusId = order.OrderStatusId,
                    PaymentTypeId = order.PaymentTypeId
                };
        }

        public void Dispose()
        {
            m_Storage.Dispose();
        }
    }
}