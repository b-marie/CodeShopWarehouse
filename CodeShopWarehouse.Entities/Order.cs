using System;
using System.Collections.Generic;
using System.Text;

namespace CodeShopWarehouse.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string OrderType { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? ProcessedAt { get; set; }
        public DateTimeOffset? ClosedAt { get; set; }
    }
}
