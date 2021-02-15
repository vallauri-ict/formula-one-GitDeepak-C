using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class driverController : ControllerBase
    {
        // GET: api/<driverController>
        [HttpGet]
        public IEnumerable<Driver> Get()
        {
            DbTools db = new DbTools();
            return db.GetListDriver();
        }

        // GET api/<driverController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<driverController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<driverController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<driverController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
