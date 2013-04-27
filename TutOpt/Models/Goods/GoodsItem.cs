namespace Tutopt.Models.Goods
{
    public class GoodsItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Article { get; set; }
        public string BriefDescription { get; set; }
        public string FullDiscription { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal MaxPrice { get; set; }
        public decimal MiddlePrice { get; set;}
        public decimal MinPrice { get; set; }
        public int Count { get; set; }
        public bool IsWarranty { get; set; }
        public short Warranty { get; set; }
        public int Status { get; set; }
    }
}