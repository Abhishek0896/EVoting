using ElectronicVotingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElectronicVotingSystem.Controllers
{
    public class BaseApiController : ApiController
    {
        

        public HttpResponseMessage JsonResult(HttpStatusCode code, object model)
        {
            var response = new CustomResponse
            {
                 Data = model, 
                statusInfo = new StatusInfo 
                {
                    Message = GetMessage(code),
                    statusCode = GetStatusCode(code),
                }
            };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        public HttpResponseMessage JsonUnauthorizedError()
        {
            var response = new CustomResponse
            {
                Data = null ,
                statusInfo = new StatusInfo 
                {
                    Message = GetMessage(HttpStatusCode.Unauthorized),
                    statusCode = GetStatusCode(HttpStatusCode.Unauthorized)
                }
            };
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }


        private string GetStatusCode(HttpStatusCode code)
        {
            switch (code) 
            {
                case HttpStatusCode.OK:
                    return "000";
                case HttpStatusCode.BadRequest:
                    return "400";
                case HttpStatusCode.Unauthorized:
                    return "401";
                case HttpStatusCode.InternalServerError:
                    return "500";
                default:
                    return "404";
            };
        }

        private string GetMessage(HttpStatusCode code)
        {
            switch (code)
            {
                case HttpStatusCode.OK:
                    return "Success";
                case HttpStatusCode.Unauthorized:
                    return "Invalid Token";
                case HttpStatusCode.InternalServerError:
                    return "Failure";
                default:
                    return "Failure";
            };
        }
    }
}
