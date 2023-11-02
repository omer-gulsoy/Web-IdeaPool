using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DtoLayer.Dtos.AppUserDtos
{
	public class AppUserRegisterDto
	{
		//[Required(ErrorMessage = "Ad alanı zorunludur")]
		//[Display(Name = "İsim")]
		//[MaxLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string SicilNo { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
        public bool Status { get; set; }
    }
}
