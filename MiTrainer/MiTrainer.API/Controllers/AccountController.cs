using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MiTrainer.Data.Account;
using System.Web.Helpers;
using System.Web.Http.Results;

namespace MiTrainer.API.Controllers
{
    public class AccountController : ApiController
    {
        [HttpGet]
        [Route("api/Account/all")]
        public JsonResult<List<Person>> Get()
        {
            List<Person> persons = Person.GetPersons();

            return Json(persons);
        }

        [HttpGet]
        [Route("api/Account/{id}")]
        public JsonResult<Person> GetPersonById(long id)
        {
            Person p = Person.GetPerson(id);

            return Json<Person>(p);
        }

        // random change
        public IHttpActionResult Post([FromBody] Person person)
        {
            try
            {
                bool personCreated = Person.CreatePerson(person);

                return Ok();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return BadRequest("Something went wrong boaaa");
            }

        }


    }
}
