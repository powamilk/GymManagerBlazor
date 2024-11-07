using System.ComponentModel.DataAnnotations;

namespace GymManagerBlazor.PL.Models
{
    public class MemberViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Họ tên là bắt buộc")]
        [MaxLength(100, ErrorMessage = "Họ tên tối đa 100 ký tự")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email là bắt buộc")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Số điện thoại là bắt buộc")]
        [MaxLength(15, ErrorMessage = "Số điện thoại tối đa 15 ký tự")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Số điện thoại chỉ chứa số")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Loại thẻ thành viên là bắt buộc")]
        public string MembershipType { get; set; }

        [Required(ErrorMessage = "Ngày tham gia là bắt buộc")]
        public DateTime JoinDate { get; set; }
    }
}
