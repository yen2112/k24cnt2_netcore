using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nvylesson14.Models
{
    [Table("Blog")]
    public class Blog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã bài viết")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Tiêu đề bài viết không được để trống")]
        [StringLength(100, ErrorMessage = "Tiêu đề bài viết tối đa 100 ký tự")]
        [Display(Name = "Tiêu đề bài viết")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Trạng thái")]
        public byte Status { get; set; } = 1;

        [Display(Name = "Ngày đăng")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [StringLength(100, ErrorMessage = "Đường dẫn ảnh tối đa 100 ký tự")]
        [Display(Name = "Ảnh đại diện")]
        public string? Image { get; set; }

        [StringLength(350, ErrorMessage = "Tóm tắt/Nội dung tối đa 350 ký tự")]
        [Display(Name = "Tóm tắt bài viết")]
        public string? Description { get; set; }
    }
}
