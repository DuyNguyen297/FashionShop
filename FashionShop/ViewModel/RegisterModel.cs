using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FashionShop.ViewModel
{
    public class RegisterModel
	{
        [Key]
        [MaxLength(100)]
        public string Name { get; set; }
		[DisplayName("Email")]
		public string Email { get; set; }
		[DisplayName("Số điện thoại")]
		public string Phone { get; set; }
		[DisplayName("Hình đại diện")]
		public string Avatar { get; set; }
		[DisplayName("Địa chỉ")]
		public string Address { get; set; }
		[Display(Name = "Mật khẩu mới")]
		[Required(ErrorMessage = "Vui lòng nhập mật khẩu mới")]
		[MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
		public string Password { get; set; }

		[MinLength(5, ErrorMessage = "Bạn cần đặt mật khẩu tối thiểu 5 ký tự")]
		[Display(Name = "Nhập lại mật khẩu")]
		[Compare("Password", ErrorMessage = "Nhập lại mật khẩu không đúng")]
		public string ConfirmPassword { get; set; }
	}
}
