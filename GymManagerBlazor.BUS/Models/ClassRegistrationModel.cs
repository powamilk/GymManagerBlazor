using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Models
{
    public class ClassRegistrationModel
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int ClassId { get; set; }

        public string MemberName { get; set; }

        public string ClassName { get; set; }
    }
}
