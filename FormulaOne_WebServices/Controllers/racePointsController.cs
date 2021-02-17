using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/racepoints")]
    [ApiController]
    public class racePointsController : ControllerBase
    {
        // GET: api/<racePointsController>
        [HttpGet]
        public IEnumerable<RacePoints> Get()
        {
            DbTools db = new DbTools();
            return db.GetListRacePoints();
        }

        // GET api/<racePointsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<racePointsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<racePointsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<racePointsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
