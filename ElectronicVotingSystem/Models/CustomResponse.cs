using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicVotingSystem.Models
{
    public class CustomResponse
    {
        public StatusInfo statusInfo { get; set; }

        public object Data { get; set; }
    }

    public class StatusInfo
    {
        public string Message { get; set; }

        public string statusCode { get; set; }
    }
}