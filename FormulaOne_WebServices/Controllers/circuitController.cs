using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/circuit")]
    [ApiController]
    public class circuitController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<circuitController>
        [HttpGet]
        public IEnumerable<Circuit> Get()
        {
            db.GetListCircuits();
            return db.Circuits.Values;
        }

        // GET api/<circuitController>/5
        [HttpGet("{id}")]
        public Circuit Get(int id)
        {
            db.GetListCircuits();
            if (!db.Circuits.ContainsKey(id))
                return new Circuit();

            return db.Circuits[id];
        }

        // POST api/<circuitController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<circuitController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<circuitController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
