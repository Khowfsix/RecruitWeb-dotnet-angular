using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class RoomModel
    {
        public Guid RoomId { get; set; }
        public string RoomName { get; set; } = null!;
        public bool? IsDeleted { get; set; } = null!;
    }
}
