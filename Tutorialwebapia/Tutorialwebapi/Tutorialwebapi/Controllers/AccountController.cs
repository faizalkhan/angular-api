using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tutorialwebapi.Models;

namespace Tutorialwebapi.Controllers
{
    public class AccountController : ApiController
    {

        public IHttpActionResult login(LoginModel loginModel )
        {

           Dbmodels db = new Dbmodels();

           Employeemaster employeemaster = db.Employeemasters.Any(x => x.EmailId == loginModel.EmailId && x.Password == loginModel.Password);

           return Ok(Employeemaster);

            return StatusCode(HttpStatusCode.NoContent);
        }





    }
}
