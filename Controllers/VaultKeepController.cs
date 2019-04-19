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
      string UserId = HttpContext.User.Identity.Name;
      IEnumerable<Keep> VaultKeeps = _vkr.GetVaultKeeps(vaultId, UserId);
      if (VaultKeeps == null)
      {
        return BadRequest();
      }
      return Ok(VaultKeeps);
    }

    [HttpPost("{vaultId}")]
    public ActionResult<Vault> AddKeep([FromBody] VaultKeep vaultKeep)
    {
      string UserId = HttpContext.User.Identity.Name;
      VaultKeep newVaultKeep = _vkr.AddToVault(vaultKeep);
      if (newVaultKeep == null)
      {
        return BadRequest();
      }

      return Ok(newVaultKeep);
    }

    [HttpDelete("{vaultId}/deletekeep/{keepId}")]
    public ActionResult<string> Delete(int VaultId, int KeepId)
    {
      string UserId = HttpContext.User.Identity.Name;
      bool success = _vkr.Delete(VaultId, KeepId, UserId);
      if (!success)
      {
        return BadRequest();
      }

      return Ok();
    }
  }
}
