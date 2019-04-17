using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;
using System.Collections;

namespace keepr.Repositories
{

  public class VaultKeepsRepository
  {
    private readonly IDbConnection _db;

    public VaultKeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Keep> GetVaultKeeps(int vaultId, string userId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
             INNER JOIN keeps k on k.id = vk.keepId
             WHERE(vaultId = @VaultId and vk.userId = @UserId)", new { vaultId, userId });
    }

    public VaultKeep AddToVault(VaultKeep vaultKeep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultkeeps (keepId, vaultId, userId)
                VALUES (@KeepId, @VaultId, @UserId);
                SELECT LAST_INSERT_ID();", vaultKeep);
        vaultKeep.Id = id;
        return vaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE id = @id", new { id });
      return success > 0;
    }
  }
}