using System.ComponentModel.DataAnnotations;

namespace LuckyDrawPromotion.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Vui lòng điền họ và tên")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Vui lòng điền số điện thoại")]
        [StringLength(20, MinimumLength = 10, ErrorMessage = "Số điện thoại không hợp lệ")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Vui lòng điền ngày sinh")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Vui lòng điền mật khẩu")]
        [StringLength(int.MaxValue, MinimumLength = 6, ErrorMessage = "Mật khẩu phải có ít nhất 6 kí tự")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Mật khẩu phải có ít nhất một ký tự in hoa, in thường và số")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn chức vụ")]
        public string Position { get; set; }
        
        [Required(ErrorMessage = "Vui lòng chọn loại hình kinh doanh")]
        public string TypeBusiness { get; set; }

        public string Address { get; set; }

        //public string ErrorMessage { get; set; }

        public RegisterViewModel()
        {
            Address = string.Empty;
            //ErrorMessage = string.Empty;
        }
    }
}