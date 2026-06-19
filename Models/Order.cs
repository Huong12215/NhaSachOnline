using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace NhaSachOnline.Models
{
    [Table("Order")]
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public  DateTime CreateDate { get; set; } = DateTime.Now;
        //public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public int OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required]
        [EmailAddress]
        [MaxLength(50)]
        // EmailAddress nghĩa là trường dữ liệu này phải có định dạng email hợp lệ
        public string? Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string? MobileNumber { get; set; }

        [Required]
        [MaxLength(250)]
        public string? Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string? PaymentMethod { get; set; }
        public bool IsPaid { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
