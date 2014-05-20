using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Helpers;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class ClearencesRepository : RepositoryPackage<ClearenceModel>
    {
        public ClearencesRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        //We have to do this because of multiple contexts working on that DbSet
        public override void Update(ClearenceModel entity)
        {
            ClereancesHelper.Instance.RemoveContext();
            ClearenceModel existing = All.Find(x => x.ClearenceId.Equals(entity.ClearenceId));
            ((IObjectContextAdapter)DatabaseContext).ObjectContext.Detach(existing);

            base.Update(entity);
        }

        public bool CheckIfClearenceIsDuplicatingExistingEntites(ClearenceModel newClearence)
        {
            return (All.Any(x => x.ClearenceWeight.Equals(newClearence.ClearenceWeight)) ||
                    All.Any(x => x.ClearenceName.Equals(newClearence.ClearenceName)) ||
                    All.Any(x => x.ClearenceRgbColor.Equals(newClearence.ClearenceRgbColor)));
        }

        public bool CheckIfClearenceIsDuplicatingExistingEntitesEditMode(ClearenceModel newClearence)
        {
            var clearences = All.Except(All.Where(x => x.ClearenceId.Equals(newClearence.ClearenceId))).ToList();
            return (clearences.Any(x => x.ClearenceWeight.Equals(newClearence.ClearenceWeight)) ||
                    clearences.Any(x => x.ClearenceName.Equals(newClearence.ClearenceName)) ||
                    clearences.Any(x => x.ClearenceRgbColor.Equals(newClearence.ClearenceRgbColor)));
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

        public IEnumerable<ClearenceModel> GetAllSortedByWeight()
        {
            var allClearences = All.ToList();
            allClearences.Sort((a, b) => a.ClearenceWeight.CompareTo(b.ClearenceWeight));
            return allClearences;
        }
    }
}