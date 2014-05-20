using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class ClearencesRepository : RepositoryPackage<ClearenceModel>
    {
        public ClearencesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public bool CheckIfClearenceIsDuplicatingExistingEntites(ClearenceModel newClearence)
        {
            return (All.Any(x => x.ClearenceWeight.Equals(newClearence.ClearenceWeight)) ||
                    All.Any(x => x.ClearenceName.Equals(newClearence.ClearenceName)) ||
                    All.Any(x => x.ClearenceRgbColor.Equals(newClearence.ClearenceRgbColor)));
        }

        public bool CheckIfThisClearenceIsUsedAnywhere(int clearenceId)
        {
            var isUsedInSecurityTables = DatabaseContext.SecurityOfTables.ToList().Any(x => x.ClearenceModel.ClearenceId.Equals(clearenceId));
            var isUsedInUserProfiles = DatabaseContext.UserProfiles.ToList().Any(x => x.ClearenceModel.ClearenceId.Equals(clearenceId));
            return (isUsedInSecurityTables || isUsedInUserProfiles);
        }

        public override ClearenceModel Find(int id)
        {
            return DatabaseContext.Clearences.ToList().Find(x => x.ClearenceId.Equals(id));
        }
    }
}