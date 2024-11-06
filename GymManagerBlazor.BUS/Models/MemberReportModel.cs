using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Models
{
    public class MemberReportModel
    {
        public string MemberName { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public int TotalClassesAttended { get; set; }
        public DateTime LastAttendedDate { get; set; }
    }
}
