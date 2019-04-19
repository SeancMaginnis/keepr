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
    [HttpGet("public")]

    public ActionResult<IEnumerable<Keep>> GetPublic()
    {
      IEnumerable<Keep> allKeeps = _kr.GetPublic();
      if (allKeeps == null)
      {
        return BadRequest();
      }
      return Ok(allKeeps);
    }

    [HttpGet("userId")]

    public ActionResult<IEnumerable<Keep>> GetUserId()
    {
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> userKeeps = _kr.GetUserId(UserId);
      if (userKeeps == null)
      {
        return BadRequest();
      }
      return Ok(userKeeps);

    }


    [HttpPost]
    public ActionResult<Keep> Create([FromBody] Keep keep)
    {
      keep.UserId = HttpContext.User.Identity.Name;
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