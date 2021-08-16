using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using ElectronicVotingSystem.DatabaseContext;
using ElectronicVotingSystem.Models;
using System.IO;
using System.Threading.Tasks;


namespace ElectronicVotingSystem.Controllers
{
    public class EVotingController : BaseApiController
    {

        [HttpPost]
        public HttpResponseMessage RegisterVoter(Users users)
        {
            try
            {
                if (users == null)
                {
                    return JsonResult(HttpStatusCode.BadRequest, null);
                }
               
                var context = new DBContext();
                string message = context.RegisterUser(users);
                if (message == null || !String.IsNullOrEmpty(message))
                {
                    return JsonResult(HttpStatusCode.BadRequest, message);
                }
                return JsonResult(HttpStatusCode.OK, "You have succesfully registered...!!!");
            }
            catch (Exception e)
            {
                return JsonResult(HttpStatusCode.BadRequest, e.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetParties()
        {
            try
            {
                var context = new DBContext();
                var response = context.GetPartyList();   
                return JsonResult(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return JsonResult(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage SignIn(string aadharNumber)
        {
            try
            {
                var context = new DBContext();
                var response = context.Login(aadharNumber);
                if(response != null)
                    return JsonResult(HttpStatusCode.OK, response);
                else
                    return JsonResult(HttpStatusCode.BadRequest, response);
            }
            catch (Exception e)
            {
                return JsonResult(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage Vote(Users users)
        {
            try
            {
                if (users == null)
                {
                    return JsonResult(HttpStatusCode.BadRequest, null);
                }

                var context = new DBContext();
                string message = context.CreateVote(users);
                if (message == null || !String.IsNullOrEmpty(message))
                {
                    return JsonResult(HttpStatusCode.BadRequest, message);
                }
                return JsonResult(HttpStatusCode.OK, "You have succesfully voted...!!!");
            }
            catch (Exception e)
            {
                return JsonResult(HttpStatusCode.BadRequest, e.Message);
            }

        }

    }
}
