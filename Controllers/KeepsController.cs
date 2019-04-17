using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsRepository _kr;

    public KeepsController(KeepsRepository kr)
    {
      _kr = kr;
    }

    //GET api/keeps
    [HttpGet]

    public ActionResult<IEnumerable<Keep>> Get()
    {
      IEnumerable<Keep> allKeeps = _kr.GetAll();
      if (allKeeps == null)
      {
        return BadRequest();
      }
      return Ok(allKeeps);
    }

    //GET api/keeps/:id
    [HttpGet("{id}")]
    public ActionResult<Keep> GetOne(int id)
    {
      Keep foundKeep = _kr.GetbyId(id);
      if (foundKeep == null)
      {
        return BadRequest();
      }
      return Ok(foundKeep);
    }

    [HttpPost]
    [Authorize]
    public ActionResult<Keep> Create([FromBody] Keep keep)
    {

      Keep newKeep = _kr.CreateKeep(keep);
      if (newKeep == null) { return BadRequest("Whoops Something didn't work"); }
      return Ok(newKeep);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool wasSuccessful = _kr.Delete(id);
      if (wasSuccessful)
      {
        return Ok();
      }

      return BadRequest();
    }

  }
}