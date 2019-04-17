using System.Collections.Generic;
using keepr.Models;
using keepr.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace keepr.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class VaultsController : ControllerBase
  {
    private readonly VaultsRepository _vr;

    public VaultsController(VaultsRepository vr)
    {
      _vr = vr;
    }

    [HttpGet]

    public ActionResult<IEnumerable<Vault>> Get()
    {
      IEnumerable<Vault> Vaults = _vr.GetAllVaults();
      if (Vaults == null)
      {
        return BadRequest();
      }
      return Ok(Vaults);
    }

    //GET api/keeps/:id
    [HttpGet("{id}")]
    public ActionResult<Vault> Get(int id)
    {
      Vault foundVault = _vr.GetById(id);
      if (foundVault == null)
      {
        BadRequest();
      }
      return Ok(foundVault);
    }

    [HttpPost]
    public ActionResult<Vault> Create([FromBody] Vault vault)
    {
      Vault newVault = _vr.CreateVault(vault);
      if (newVault == null)
      {
        return BadRequest();
      }
      return Ok(newVault);
    }

    [HttpDelete("{id}")]

    public ActionResult<Vault> Delete(int id)
    {
      bool wasSuccessful = _vr.Delete(id);
      if (wasSuccessful)
      {
        return Ok();
      }

      return BadRequest();
    }
  }
}