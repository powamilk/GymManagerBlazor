using GymManagerBlazor.BUS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Models
{
    public class ClassDetailsModel
    {
        public ClassViewModel ClassInfo { get; set; }
        public TrainerViewModel TrainerInfo { get; set; }
        public List<MemberViewModel> Members { get; set; } = new List<MemberViewModel>();
    }
}
