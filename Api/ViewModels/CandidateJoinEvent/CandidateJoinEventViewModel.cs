﻿using Api.ViewModels.Candidate;
using Api.ViewModels.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Api.ViewModels.CandidateJoinEvent
{
    public class CandidateJoinEventViewModel
    {
        public EventViewModel Event { get; set; }
        public Guid CandidateJoinEventId { get; set; }
        public Guid CandidateId { get; set; }
        public Guid EventId { get; set; }

        public int JoinEventCount { get; set; }

        public CandidateViewModel Candidate { get; set; }
    }
}
