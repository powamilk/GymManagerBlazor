using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerBlazor.BUS.Exceptions
{
    public class ValidationException : Exception
    {
        public Dictionary<string, string> ValidationErrors { get; private set; }

        public ValidationException(Dictionary<string, string> validationErrors)
            : base("Lỗi xác thực đã xảy ra.")
        {
            ValidationErrors = validationErrors;
        }
    }
}
