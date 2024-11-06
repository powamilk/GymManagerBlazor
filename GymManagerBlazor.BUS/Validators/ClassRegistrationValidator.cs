using FluentValidation;
using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Validators
{
    public class ClassRegistrationValidator : AbstractValidator<ClassRegistrationViewModel>
    {
        public ClassRegistrationValidator()
        {
            RuleFor(x => x.MemberId)
                .GreaterThan(0).WithMessage("Thành viên không hợp lệ");

            RuleFor(x => x.ClassId)
                .GreaterThan(0).WithMessage("Lớp học không hợp lệ");
        }
    }
}
