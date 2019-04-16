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

           [HttpGet("{id}")]
           public ActionResult<VaultKeep> GetByVId(int id)
           {
               VaultKeep foundVk = _vkr.GetByVId(id);
               if (foundVk == null)
               {
                   return BadRequest();
               }

               return Ok(foundVk);
           }

           [HttpGet("{id}/vaultkeeps")]
           public ActionResult<IEnumerable<VaultKeep>> GetKeeps(int id)
           {
               return Ok(_vkr.GetVaultKeeps(id));
           }

           [HttpPost]
           public ActionResult<VaultKeep> Create([FromBody] VaultKeep vaultKeep)
           {
               VaultKeep newVaultKeep = _vkr.CreateVaultKeep(vaultKeep);
               if (newVaultKeep == null)
               {
                   return BadRequest();
               }

               return Ok(newVaultKeep);
           }

           [HttpDelete]
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
