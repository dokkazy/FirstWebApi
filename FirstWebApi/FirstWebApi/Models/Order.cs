using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Models
{
    public enum Status
    {
        New = 0, Payment = 1, Complete = 2, Cancel = -1
    }
    public class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ShippingDate { get; set; }
        public Status Status { get; set;}
        public string FullName { get; set;}
        public string Address { get; set;}
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set;}

        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
