using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices
{
    [Route("api/team")]
    [ApiController]
    public class teamController : ControllerBase
    {
        // GET: api/<teamController>
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            DbTools db = new DbTools();
            return db.GetListTeam();
        }

        // GET api/<teamController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<teamController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<teamController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<teamController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
