using FormulaOne_Dll;
using FormulaOne_Dll.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FormulaOne_WebServices.Controllers
{
    [Route("api/score")]
    [ApiController]
    public class scoreController : ControllerBase
    {
        DbTools db = new DbTools();
        // GET: api/<scoreController>
        [HttpGet]
        public IEnumerable<ScoreSimple> GetSimpleDriver()
        {
            db.GetListScores();
            db.GetListTeam();
            List<ScoreSimple> s = new List<ScoreSimple>();
            db.Scores.Values.ToList().ForEach(score => s.Add(new ScoreSimple(score, db.GetRaceById(db.GetRacePointsById(score.Pos)), db.GetDriverById(score.ExtDriver), db.Teams[score.ExtTeam], db.GetRacePointsById(score.Pos))));
            return s;
        }        

        [HttpGet("all")]
        public IEnumerable<Score> Get()
        {
            db.GetListScores();
            return db.Scores.Values;
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
