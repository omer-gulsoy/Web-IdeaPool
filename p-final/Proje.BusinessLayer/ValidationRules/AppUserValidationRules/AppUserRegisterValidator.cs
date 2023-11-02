using FluentValidation;
using Proje.DtoLayer.Dtos.AppUserDtos;

namespace Proje.BusinessLayer.ValidationRules.AppUserValidationRules
{
	public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDto>
	{
		public AppUserRegisterValidator()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alanı boş geçilemez");
			RuleFor(x => x.Surname).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
			RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta alanı boş geçilemez");
			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("Parola tekrar alanı boş geçilemez");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Parola alanı boş geçilemez");
			RuleFor(x => x.Name).MaximumLength(30).WithMessage("En fazla 30 karakter girişi yapın");
			RuleFor(x => x.Name).MinimumLength(2).WithMessage("En az 2 karakter girişi yapın");
			RuleFor(x => x.ConfirmPassword).Equal(y => y.Password).WithMessage("Parolalar eşleşmiyor");
			RuleFor(x => x.Email).EmailAddress().WithMessage("Girilen E-Posta adresi geçerli değil");
		}
	}
}
