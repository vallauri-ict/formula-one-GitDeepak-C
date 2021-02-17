using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class scoreController : ControllerBase
    {
        // GET: api/<scoreController>
        [HttpGet]
        public IEnumerable<Score> Get()
        {
            DbTools db = new DbTools();
            return db.GetListScores();
        }

        // GET api/<scoreController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<scoreController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<scoreController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<scoreController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
