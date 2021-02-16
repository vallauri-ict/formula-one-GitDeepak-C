using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/race")]
    [ApiController]
    public class raceController : ControllerBase
    {
        // GET: api/<raceController>
        [HttpGet]
        public IEnumerable<Race> Get()
        {
            DbTools db = new DbTools();
            return db.GetListRaces();
        }

        // GET api/<raceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<raceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<raceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<raceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
