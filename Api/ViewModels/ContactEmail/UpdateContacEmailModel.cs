using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.ViewModels.ContactEmail
{
    public class UpdateContacEmailModel
    {
        public string ToEmail { get; set; }
        public string DateTime { get; set; }
        public string Room { get; set; }
    }
}
