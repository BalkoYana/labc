using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        FlatRepository _repo = new FlatRepository(new AppDbcontext());
        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<List<Flat>> Get()
        {
            return await _repo.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flat>> Get(int id)
        {
            var flat = await _repo.GetById(id);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
        }

        // POST api/<ValuesController>
        [HttpPost]
        public async Task<Flat> Post([FromBody] Flat value)
        {
            return await _repo.Create(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Flat>> Put(int id, [FromBody] Flat value)
        {
            var flat = await _repo.Update(id, value);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Flat>> Delete(int id)
        {
            var flat = await _repo.Delete(id);
            if (flat == null)
            {
                return NotFound();
            }
            return Ok(flat);
        }
    }
}
