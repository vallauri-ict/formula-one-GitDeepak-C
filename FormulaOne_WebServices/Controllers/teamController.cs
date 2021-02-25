using FormulaOne_Dll;
using FormulaOne_Dll.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices
{
    [Route("api/team")]
    [ApiController]
    public class teamController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<teamController>
        [HttpGet]
        public IEnumerable<Team> Get()
        {
            db.GetListTeam();
            return db.Teams.Values;
        }

        [HttpGet("simple")]
        public IEnumerable<TeamSimple> GetSimpleTeam()
        {
            db.GetListTeam();
            List<TeamSimple> t = new List<TeamSimple>();
            db.Teams.Values.ToList().ForEach(team => t.Add(new TeamSimple(team)));
            return t;
        }

        // GET api/<teamController>/5
        [HttpGet("{id}")]
        public Team Get(int id)
        {
            db.GetListTeam();
            if (!db.Teams.ContainsKey(id))
                return new Team();

            return db.Teams[id];
        }

        // GET api/<teamController>/5
        [HttpGet("{teamname}")]
        public Team GetByTeamName(int id)
        {
            db.GetListTeam();
            if (!db.Teams.ContainsKey(id))
                return new Team();

            return db.Teams[id];
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
