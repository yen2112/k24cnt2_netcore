using System.ComponentModel.DataAnnotations;

namespace NguyenVanYen2410900091_exam.Models
{
    public class nvyStudent
    {
        [Display(Name = "Mã SV")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ và tên")]
        [Display(Name = "Họ và tên")]
        public string HvtName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng nhập giới tính")]
        [Display(Name = "Giới tính")]
        public string HvtGender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Vui lòng chọn ngày sinh")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày sinh")]
        public DateTime HvtBirthDay { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string? HvtEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        public string? HvtPhone { get; set; }

        [Display(Name = "Trạng thái")]
        public bool HvtActive { get; set; }
    }
}