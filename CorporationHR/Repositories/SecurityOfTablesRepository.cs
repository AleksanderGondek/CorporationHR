using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class SecurityOfTablesRepository : RepositoryPackage<SecurityOfTable>
    {
        public SecurityOfTablesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public override SecurityOfTable Find(int id)
        {
            return DatabaseContext.SecurityOfTables.ToList().Find(x => x.TableId.Equals(id));
        }

        public override void Update(SecurityOfTable entity)
        {
            base.Update(entity);

            if (entity.SelectedClearenceId > 0)
            {
                var table = DatabaseContext.SecurityOfTables.Single(x => x.TableId.Equals(entity.TableId));
                table.ClearenceModel = DatabaseContext.Clearences.Single(x => x.ClearenceId.Equals(entity.SelectedClearenceId));
                DatabaseContext.Attach(table);
                DatabaseContext.SaveChanges();
            }
        }

        public override bool Save(SecurityOfTable entity)
        {
            var vanillaSave = base.Save(entity);

            var clearance = false;
            if (entity.SelectedClearenceId > 0)
            {
                var table = DatabaseContext.SecurityOfTables.Single(x => x.TableId.Equals(entity.TableId));
                table.ClearenceModel = DatabaseContext.Clearences.Single(x => x.ClearenceId.Equals(entity.SelectedClearenceId));
                DatabaseContext.Attach(table);
                DatabaseContext.SaveChanges();
                clearance = true;
            }

            return vanillaSave && clearance;
        }
    }
}