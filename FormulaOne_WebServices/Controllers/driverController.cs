using FormulaOne_Dll;
using FormulaOne_Dll.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/driver")]
    [ApiController]
    public class driverController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<driverController>
        [HttpGet]
        public IEnumerable<Driver> GetAllDrivers()
        {
            db.GetListDrivers();
            return db.Drivers.Values;
        }

        [HttpGet("simple")]
        public IEnumerable<DriverSimple> GetSimpleDriver()
        {
            db.GetListDrivers();
            List<DriverSimple> d = new List<DriverSimple>();
            db.Drivers.Values.ToList().ForEach(driver => d.Add(new DriverSimple(driver)));
            return d;
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
