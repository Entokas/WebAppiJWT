using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;


namespace WebAppiJWT.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        // GET: Accounts
        public HttpResponseMessage ValidLogin(string userName, string userPassword)
        {
            if (userName == "admin"  && userPassword == "admin")
            {
                return Request.CreateResponse(HttpStatusCode.OK, value: TokenManager.GenerateToken(userName));

            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadGateway, message: "User name and  password is invalid");
            }
        }
        [HttpGet]
        [CustomerAuthenticationFilter]
        public HttpResponseMessage GetEmployee()
        {
            return Request.CreateResponse(HttpStatusCode.OK, value: "Succesfully Valid");
        }

    }
}