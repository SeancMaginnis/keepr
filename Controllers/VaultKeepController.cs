using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace keepr.Controllers
{

  [Route("api/[controller]")]
  [ApiController]
  public class VaultKeepsController : ControllerBase
  {
    private readonly VaultKeepsRepository _vkr;

    public VaultKeepsController(VaultKeepsRepository vkr)
    {
      _vkr = vkr;
    }


    [HttpGet("{vaultId}/keeps")]
    public ActionResult<IEnumerable<Keep>> Get(int vaultId)
    {
      string userId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> VaultKeeps = _vkr.GetVaultKeeps(vaultId, userId);
      if (VaultKeeps == null)
      {
        return BadRequest();
      }
      return Ok(VaultKeeps);
    }

    [HttpPost("{vaultid}")]
    public ActionResult<Vault> AddKeep([FromBody] VaultKeep vaultKeep)
    {
      VaultKeep newVaultKeep = _vkr.AddToVault(vaultKeep);
      if (newVaultKeep == null)
      {
        return BadRequest();
      }

      return Ok(newVaultKeep);
    }

    [HttpDelete("{id}")]
    public ActionResult<string> Delete(int id)
    {
      bool success = _vkr.Delete(id);
      if (!success)
      {
        return BadRequest();
      }

      return Ok();
    }
  }
}
