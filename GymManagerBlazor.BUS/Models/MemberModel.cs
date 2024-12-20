﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Models
{
    public class MemberModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string MembershipType { get; set; }

        public DateTime? JoinDate { get; set; }
    }
}
