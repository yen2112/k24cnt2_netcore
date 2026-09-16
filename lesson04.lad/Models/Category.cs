using System.ComponentModel.DataAnnotations;

namespace lesson04.lad.Models
{
    public class Category
    {
        [Display(Name = "Mã danh mục")]
        public int Id { get; set; }

        [Display(Name = "Tên danh mục")]
        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        public string Name { get; set; } = string.Empty;
    }
}
