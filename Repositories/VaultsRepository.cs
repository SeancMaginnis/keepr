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

    public Vault GetById(int Id)
    {
      return _db.QueryFirstOrDefault<Vault>("SELECT * FROM vaults WHERE id = @Id", new { Id });
    }

    public Vault CreateVault(Vault vault)
    {
      try
      {
        int Id = _db.ExecuteScalar<int>(@"
          INSERT INTO keeps (name, description, userId)
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

    public IEnumerable<Vault> GetAllVaults()
    {
      return _db.Query<Vault>("SELECT * FROM vaults");
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM vaults WHERE id = @id", new { id });
      return success > 0;
    }
  }
}