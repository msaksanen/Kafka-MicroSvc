namespace InventoryProducer.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public List<string>? Products { get; set; }
        public decimal TotalAmount { get; set; }
    }
}
