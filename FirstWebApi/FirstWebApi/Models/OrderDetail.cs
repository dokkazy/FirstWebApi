namespace FirstWebApi.Models
{
    public class OrderDetail
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public double PrePrice { get; set; }
        public byte Discount { get; set; }

        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
