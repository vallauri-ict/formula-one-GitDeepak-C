using FormulaOne_Dll;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices
{
    [Route("api/country")]
    [ApiController]
    public class countryController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<countryController>
        [HttpGet]
        public IEnumerable<Country> Get()
        {
            db.GetListCountry();
            return db.Countries.Values;
        }

        // GET api/<countryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<countryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<countryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<countryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
