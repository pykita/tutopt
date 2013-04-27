using System;
using System.Linq;
using Tutopt.Models.Goods;
using Tutopt.Models.Storage;
using Tutopt.Storage;

namespace Tutopt.Service
{
    public interface  IGoodsService : IDisposable
    {
        GoodsViewModel GetGoodsViewModel();
        GoodsItem GetGoodsItem(int id);
        void SaveGoods(GoodsItem item);
    }
    public class GoodsService : IGoodsService
    {
        private readonly IGoodsStorage m_Storage;

        public GoodsService(IGoodsStorage storage)
        {
            if (storage == null)
                throw new ArgumentNullException();
            
            m_Storage = storage;
        }

        public void Dispose()
        {
            m_Storage.Dispose();
        }

        public GoodsViewModel GetGoodsViewModel()
        {
            return new GoodsViewModel
                {
                    GoodsItems = m_Storage.Goodses()
                    .Select(ConvertGoodsItem)
                    .ToArray()
                };
        }

        public GoodsItem GetGoodsItem(int id)
        {
            var item = m_Storage.Goodses().FirstOrDefault(x => x.Id == id);
            return item == null
                       ? null
                       : ConvertGoodsItem(item);
        }

        private GoodsItem ConvertGoodsItem(Goods goods)
        {
            return new GoodsItem
            {
                Id = goods.Id,
                Article = goods.Article,
                BriefDescription = goods.ShortInformation,
                Count = goods.Count,
                FullDiscription = goods.FullInformation,
                IsWarranty = goods.IsWarranty,
                MaxPrice = goods.MaxPrice,
                MiddlePrice = goods.MiddlePrice,
                MinPrice = goods.MinPrie,
                Model = "model",
                Name = goods.Name,
                PurchasePrice = goods.PurchasePrice,
                Status = goods.Status,
                Warranty = goods.Warranty
            };
        }

        private Goods ConvertToGoods(GoodsItem goods)
        {
            return new Goods
            {
                Article = goods.Article,
                ShortInformation = goods.BriefDescription,
                Count = goods.Count,
                FullInformation = goods.FullDiscription,
                IsWarranty = goods.IsWarranty,
                MaxPrice = goods.MaxPrice,
                MiddlePrice = goods.MiddlePrice,
                MinPrie = goods.MinPrice,
                Name = goods.Name,
                PurchasePrice = goods.PurchasePrice,
                Status = goods.Status,
                Warranty = goods.Warranty
            };
        }

        public void SaveGoods(GoodsItem item)
        {
            var goods = m_Storage.Goodses()
                                 .FirstOrDefault(x => x.Id == item.Id);
            if (goods == null)
                m_Storage.AddGoods(ConvertToGoods(item));
            else
            {
                goods = ConvertToGoods(item);
                m_Storage.UpdateGoods(goods);
            }
            m_Storage.SaveChanges();
        }
    }
}