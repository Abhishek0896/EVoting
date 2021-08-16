using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicVotingSystem.Models
{
    public class PartyList
    {
        public int id { get; set; }
        public string PartyName { get; set; }
        public string CandidateName { get; set; }
        public int TotalVotes { get; set; }
        public string Url { get; set; }
    }
}