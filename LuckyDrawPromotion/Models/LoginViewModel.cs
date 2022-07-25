using System.ComponentModel.DataAnnotations;

namespace LuckyDrawPromotion.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền số điện thoại")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Mật khẩu phải có ít nhất một ký tự in hoa, in thường và số")]
        public string Password { get; set; }
        public string ErrorMessage { get; set; }

        public LoginViewModel()
        {
            ErrorMessage = string.Empty;
        }
    }
}
