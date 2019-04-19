using System;
using keepr.Models;
using Microsoft.AspNetCore.Mvc;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace keepr.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }


    public Vault CreateVault(Vault vault)
    {
      try
      {
        int Id = _db.ExecuteScalar<int>(@"
          INSERT INTO vaults (name, description, userId)
          VALUES (@Name, @Description, @UserId);
          SELECT LAST_INSERT_ID();
          ", vault);
        vault.Id = Id;
        return vault;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public IEnumerable<Vault> GetVaults(string UserId)
    {
      return _db.Query<Vault>("SELECT * FROM vaults WHERE userId = @UserId", new { UserId });
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}