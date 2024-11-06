using FluentValidation;
using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Validators
{
    public class TrainerValidator : AbstractValidator<TrainerViewModel>
    {
        public TrainerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Tên không được để trống")
                .MaximumLength(100).WithMessage("Tên tối đa 100 ký tự");

            RuleFor(x => x.Specialty)
                .NotEmpty().WithMessage("Chuyên môn không được để trống")
                .MaximumLength(50).WithMessage("Chuyên môn tối đa 50 ký tự");

            RuleFor(x => x.ExperienceYears)
                .GreaterThanOrEqualTo(0).WithMessage("Số năm kinh nghiệm không được là số âm");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");
        }
    }
}
