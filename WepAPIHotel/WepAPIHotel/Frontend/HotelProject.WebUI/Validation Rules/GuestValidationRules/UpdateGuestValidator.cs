using FluentValidation;
using HotelProject.WebUI.Dtos.GuestDto;

namespace HotelProject.WebUI.Validation_Rules.GuestValidationRules
{
    public class UpdateGuestValidator : AbstractValidator<UpdateGuestDto>
    {
        public UpdateGuestValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilmez");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyisim alanı boş geçilmez");
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir alanı boş geçilmez");

            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik veri girişi yapınız");
            RuleFor(x => x.SurName).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik veri girişi yapınız");
            RuleFor(x => x.City).MinimumLength(3).WithMessage("Lütfen en az 3 karakterlik veri girişi yapınız");

            RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakterlik veri girişi yapınız");
            RuleFor(x => x.SurName).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakterlik veri girişi yapınız");
            RuleFor(x => x.City).MaximumLength(20).WithMessage("Lütfen en az fazla 20 karakterlik veri girişi yapınız");

        }
    }
}
