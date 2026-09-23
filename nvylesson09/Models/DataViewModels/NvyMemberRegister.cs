using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace namespace nvylesson09.Models.DataViewModels
{
    /// <summary>
    /// Data Annotation - Validation
    /// </summary>
    public class NvyMemberRegister
    {
        public int NvyMemberId { get; set; }

        [DisplayName("Tên đăng nhập")]
        [Required(ErrorMessage = "Tên đăng nhập không để trống")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Tên đăng nhập có độ dài trong khoảng 3 - 20 ký tự")]
        public string NvyUserName { get; set; }

        [DisplayName("Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        public string NvyPassword { get; set; }

        public string NvyEmail { get; set; }

        public string NvyPhoneNumber { get; set; }

        public string NvyFullName { get; set; }

        public DateTime NvyBirthday { get; set; }
    }
}
