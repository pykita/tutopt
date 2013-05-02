using System.Linq;
using Tutopt.Models.Storage;

namespace Tutopt.Storage
{
    public class OrdersStorage : IOrdersStorage
    {
        private readonly EntityStorage m_StorageEntities;

        public IQueryable<Orders> Orders()
        {
            return m_StorageEntities.Orders;
        }

        public void AddOrder(Orders order)
        {
            m_StorageEntities.Orders.AddObject(order);
        }

        public void UpdateOrders(Orders order)
        {

        }

        public void SaveChanges()
        {
            m_StorageEntities.SaveChanges();
        }

        public void Dispose()
        {
            m_StorageEntities.Dispose();
        }
    }
}