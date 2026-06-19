using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NhaSachOnline.Models
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }
        // Required nghĩa là trường dữ liệu này không thể trống 
        // dấu ? nghĩa là phép null
        [Required]
        [MaxLength(50)]
        public string? BookName { get; set; }
        [Required]
        [MaxLength(50)]
        public string? AuthorName { get; set; }
        [Required]
        public double Price { get; set; }
        // nvarchar(MAX)
        public string? Image { get; set; }
        [Required]
        public int GenreId { get; set; }
       // public GenericHostBuilderExtensions
       public Genre Genre { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<CartDetail> CartDetails { get; set; }
        public Stock Stock { get; set; }
        // Không ánh xạ trường dữ liệu GenreName trong bảng này 
        [NotMapped]
        public string  GenreName { get; set; }
        // Không ánh xạ trường dữ liệu Quantity trong bảng này 
        [NotMapped]
        public int Quantity { get; set; }
    }
}
