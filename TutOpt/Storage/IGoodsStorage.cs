using System;
using System.Linq;
using Tutopt.Models.Storage;

namespace Tutopt.Storage
{
    public interface IGoodsStorage : IDisposable
    {
        IQueryable<Goods> Goodses();
        void SaveChanges();
        void AddGoods(Goods goods);
        void UpdateGoods(Goods goods);
    }
}
