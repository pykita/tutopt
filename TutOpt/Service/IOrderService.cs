using System;
using Tutopt.Models.Orders;

namespace Tutopt.Service
{
    public interface IOrderService : IDisposable
    {
        OrderViewModel GetOrderViewModel();
        OrderItem GetOrderItem(int id);
        void SaveOrderItem(OrderItem orderItem);
    }
}