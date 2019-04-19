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

    public IEnumerable<Keep> GetVaultKeeps(int VaultId, string UserId)
    {
      return _db.Query<Keep>(@"SELECT * FROM vaultkeeps vk
             INNER JOIN keeps k on k.id = vk.keepId
             WHERE(vaultId = @VaultId and vk.userId = @UserId)", new { VaultId, UserId });
    }

    public VaultKeep AddToVault(VaultKeep vaultKeep)
    {
      try
      {
        int Id = _db.ExecuteScalar<int>(@"
                INSERT INTO vaultkeeps ( vaultId, keepId, userId)
                VALUES ( @VaultId,@KeepId, @UserId);
                SELECT LAST_INSERT_ID();", vaultKeep);
        vaultKeep.Id = Id;
        return vaultKeep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int VaultId, int KeepId, string UserId)
    {
      int success = _db.Execute("DELETE FROM vaultkeeps WHERE vaultId = @VaultId AND keepId = @KeepId AND userId = @UserId", new { VaultId, KeepId, UserId });
      return success > 0;
    }
  }
}