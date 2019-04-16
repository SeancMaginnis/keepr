using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using keepr.Models;

namespace keepr.Repositories
{

    public class VaultKeepsRepository
    {
        IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }
        public VaultKeep GetByVId(int id)
        {
            return _db.QueryFirstOrDefault<VaultKeep>("SELECT * FROM vaults WHERE id = @id", new {id});
        }

        public IEnumerable<Vault> GetVaultKeeps(int id)
        {
            return _db.Query<Vault>("SELECT * FROM vaults WHERE id = @id", new {id});
        }

        public VaultKeep CreateVaultKeep(VaultKeep vaultKeep)
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
            int success = _db.Execute("DELETE FROM vaultkeeps WHERE id = @id", new {id});
            return success > 0;
        }
    }
}