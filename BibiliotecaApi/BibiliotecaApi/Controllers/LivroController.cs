using BibliotecaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BibiliotecaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        // GET api/<VeiculosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VeiculosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<VeiculosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<VeiculosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }

}
