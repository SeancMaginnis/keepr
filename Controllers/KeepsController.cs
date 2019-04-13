using System.Collections.Generic;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace keepr.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeepsController : ControllerBase
    {
        private readonly KeepsRepository _ks;

        public KeepsController(KeepsRepository ks)
        {
            _ks = ks;
        }
        
        //GET api/keeps
        [HttpGet]

        public ActionResult<IEnumerable<Keep>> Get()
        {
            return Ok(_ks.GetAll());
        }
        
        //GET api/keeps/:id
        [HttpGet("{id}")]
        public ActionResult<Keep> GetOne(string id)
        {
            return _ks.GetbyId(id);
        }

        [HttpPost]
        public ActionResult<Keep> Create([FromBody] Keep newKeep)
        {
            return _ks.CreateKeep(newKeep);
        }

        [HttpDelete("{id}")]
        public ActionResult<Keep> Delete(string id)
        {
            bool wasSuccessful = _ks.DeleteKeep(id);
            if (wasSuccessful)
            {
                return Ok();
            }

            return BadRequest();
        }
            
    }
}