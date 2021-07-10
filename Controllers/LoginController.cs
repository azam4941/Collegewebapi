using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using collegewebapi.Models;
using collegewebapi.VM;
using collegewebapi.DAL;


namespace collegewebapi.Controllers
{
    [RoutePrefix("Api/login")]
    public class LoginController : ApiController
    {
        Collegewebapicontext DB = new Collegewebapicontext();
        [Route("InsertEmployee")]
        [HttpPost]
        public object InsertEmployee(Resgister Reg)
        {
            try
            {
                User EL = new User();
                if (EL.ID == 0)
                {
                    EL.Name = Reg.Name;
                    EL.City = Reg.City;
                    EL.Email = Reg.Email;
                    EL.Password = Reg.Password;
                    EL.UserType = Reg.UserType;
                    DB.Users.Add(EL);
                    DB.SaveChanges();
                    return new Response
                    { Status = "Success", Message = "Record SuccessFully Saved." };
                }
            }
            catch (Exception)
            {

                throw;
            }
            return new Response
            { Status = "Error", Message = "Invalid Data." };
        }
        [Route("Login")]
        [HttpPost]
        public Response employeeLogin(Login login)
        {
            var log = DB.Users.Where(x => x.Email.Equals(login.Email) &&
                      x.Password.Equals(login.Password)).FirstOrDefault();

            if (log == null)
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
            else
                return new Response { Status = "Success", Message = "Login Successfully" };
        }
    }
}
