using DapperApp.Library1.Models;
using DapperApp.Library1.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace RestApp.Controllers
{
    [Route("api/dapper-app")]
    [ApiController]
    public class DapperAppController : ControllerBase
    {
        //Transient
        //Scoped
        //Singleton

        protected IPersonQueries PersonQueries { get; }

        public DapperAppController(IPersonQueries personQueries)
        {
            PersonQueries = personQueries;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok(new
            {
                Name = "test",
                Complex = new
                {
                    Address = "address"
                }
            });
        }

        [HttpGet("list")]
        public IList<Person> List()
        {
            return PersonQueries.GetPersons();
        }

        [HttpPost("create")]
        public Person Create(Person person)
        {
            PersonQueries.CreatePerson(person);
            return (person);
        }

        [HttpGet("{id=}")]
        public Person Get(int id)
        {
            return PersonQueries.Get(id);
        }

        [HttpDelete("{id=}")]
        public void Delete(int id)
        {
            PersonQueries.Delete(id);
        }

        [HttpPut("{id=}")]
        public Person Update(int id, Person person)
        {
            //update code here
            return null;
        }
    }
}
