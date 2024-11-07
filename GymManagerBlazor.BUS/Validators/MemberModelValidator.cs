using FluentValidation;
using GymManagerBlazor.BUS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Validators
{
    public class MemberModelValidator : AbstractValidator<MemberModel>
    {
        public MemberModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Họ tên không được để trống")
                .MaximumLength(100).WithMessage("Họ tên tối đa 100 ký tự");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email không được để trống")
                .EmailAddress().WithMessage("Email không hợp lệ");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Số điện thoại không được để trống")
                .Matches(@"^\d+$").WithMessage("Số điện thoại chỉ chứa số")
                .MaximumLength(15).WithMessage("Số điện thoại tối đa 15 ký tự");

            RuleFor(x => x.MembershipType)
                .NotEmpty().WithMessage("Loại thẻ thành viên không được để trống")
                .Must(type => type == "Basic" || type == "Premium")
                .WithMessage("Loại thẻ phải là 'Basic' hoặc 'Premium'");

            RuleFor(x => x.JoinDate)
                .NotEmpty().WithMessage("Ngày tham gia không được để trống");
        }
    }
}
