using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tutopt.Models.Orders
{
    public class OrderItem
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public long? OrderNumber1C { get; set; }
        public int UserId { get; set; }
        public string Email{ get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public byte DeliveryTypeId { get; set; }
        public byte OrderStatusId { get; set; }
        public short PaymentTypeId { get; set; }
        public short TransporterId { get; set; }
        public string Comment { get; set; }
    }
}