using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Models
{
    public class ClassModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TrainerId { get; set; }

        public string Schedule { get; set; }

        public int MaxMembers { get; set; }

        public int CurrentMembers { get; set; }

        public string Description { get; set; }
        public string TrainerName { get; set; }

        public List<MemberModel> RegisteredMembers { get; set; }

    }
}
