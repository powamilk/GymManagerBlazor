using FluentValidation;
using GymManagerBlazor.BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Validators
{
    public class ClassRegistrationModelValidator : AbstractValidator<ClassRegistrationModel>
    {
        public ClassRegistrationModelValidator()
        {
            RuleFor(x => x.MemberId)
                .GreaterThan(0).WithMessage("Thành viên không hợp lệ");

            RuleFor(x => x.ClassId)
                .GreaterThan(0).WithMessage("Lớp học không hợp lệ");
        }
    }
}
