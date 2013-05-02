using System;
using System.Linq;
using Tutopt.Models.Storage;

namespace Tutopt.Storage
{
    public interface IOrdersStorage : IDisposable
    {
        IQueryable<Orders> Orders();
        void AddOrder(Orders order);
        void UpdateOrders(Orders order);
        void SaveChanges();
    }
}                                                            