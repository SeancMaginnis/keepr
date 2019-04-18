using System;
using keepr.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;

namespace keepr.Repositories
{
  public class KeepsRepository
  {

    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }
    public IEnumerable<Keep> GetAll()
    {
      return _db.Query<Keep>("SELECT * FROM keeps");
    }


    public Keep CreateKeep(Keep keep)
    {
      try
      {
        int id = _db.ExecuteScalar<int>(@"
          INSERT INTO keeps (name, description, img, userId)
          VALUES (@Name, @Description, @Img, @UserId);
          SELECT LAST_INSERT_ID();
          ", keep);
        keep.Id = id;
        return keep;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        return null;
      }
    }

    public bool Delete(int id)
    {
      int success = _db.Execute("DELETE FROM keeps WHERE id = @id", new { id });
      return success > 0;
    }
  }
}