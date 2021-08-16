using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicVotingSystem.Models
{
    public class Users
    {
        public string Name { get; set; }
        public string VoterID { get; set; }
        public string AadharID { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int CandidateID { get; set; }
    }
}