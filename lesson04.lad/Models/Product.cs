using System;
using System.ComponentModel.DataAnnotations;

namespace lesson04.lad.Models
{
    public class Product
    {
        [Display(Name = "Mã sản phẩm")]
        public int Id { get; set; }

        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Giá niêm yết")]
        [Required(ErrorMessage = "Giá niêm yết không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá sản phẩm phải lớn hơn hoặc bằng 0")]
        public decimal Price { get; set; }

        [Display(Name = "Giá khuyến mãi")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá khuyến mãi phải lớn hơn hoặc bằng 0")]
        public decimal SalePrice { get; set; }

        [Display(Name = "Trạng thái")]
        public bool Status { get; set; } = true;

        [Display(Name = "Ngày tạo")]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Hình ảnh")]
        public string Image { get; set; } = string.Empty;

        [Display(Name = "Danh mục")]
        [Required(ErrorMessage = "Vui lòng chọn danh mục")]
        public int CategoryId { get; set; }

        [Display(Name = "Mô tả sản phẩm")]
        public string Description { get; set; } = string.Empty;
    }
}
