using System.ComponentModel.DataAnnotations;

namespace LuckyDrawPromotion.Models
{
    public class AdminViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền email")]
        [StringLength(320, MinimumLength = 10, ErrorMessage = "Độ dài email sai quy định")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email đã nhập không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu phải từ 6 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Mật khẩu phải có ít nhất một ký tự in hoa, in thường và số")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng điền họ tên")]
        [StringLength(int.MaxValue, MinimumLength = 5, ErrorMessage = "Họ tên không hợp lệ")]
        public string Fullname { get; set; }

        public string ErrorMessage { get; set; }

        public AdminViewModel()
        {
            ErrorMessage = string.Empty;
        }
    }
}
