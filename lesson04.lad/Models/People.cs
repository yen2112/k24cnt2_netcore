using System;
using System.ComponentModel.DataAnnotations;

namespace lesson04.lad.Models
{
    public class People
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ email")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Số điện thoại")]
        public string Phone { get; set; } = string.Empty;

        [Display(Name = "Địa chỉ nơi ở")]
        public string Address { get; set; } = string.Empty;

        [Display(Name = "Ảnh đại diện")]
        public string Avatar { get; set; } = string.Empty;

        [Display(Name = "Ngày sinh nhật")]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Giới thiệu bản thân")]
        public string Bio { get; set; } = string.Empty;

        [Display(Name = "Giới tính")]
        public byte Gender { get; set; }
    }
}
