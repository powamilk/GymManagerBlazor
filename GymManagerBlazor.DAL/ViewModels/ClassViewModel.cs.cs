using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.ViewModels
{
    public class ClassViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TrainerId { get; set; }
        public string Schedule { get; set; }
        public int MaxMembers { get; set; }
        public int? CurrentMembers { get; set; }
    }
}
