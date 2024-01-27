using Data.ViewModels.Event;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinedEvent
    {

        public Guid CandidateId { get; set; }

        public Guid CandidateJoinEventId { get; set; }

        public Guid EventId { get; set; }

        public EventViewModel Event { get; set; }

    }
}
