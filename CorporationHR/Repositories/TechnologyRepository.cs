using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using CorporationHR.Context;
using CorporationHR.Models;

namespace CorporationHR.Repositories
{
    public class TechnologyRepository : RepositoryPackage<Technology>
    {
        public TechnologyRepository(ICorporationHrDatabaseContext databaseContext) : base(databaseContext) { }

        public bool Save(Technology technology, int clearenceId)
        {
            var clearence = DatabaseContext.Clearences.ToList().Single(x => x.ClearenceId.Equals(clearenceId));
            technology.ClearenceModel = clearence;
            DatabaseContext.Add(technology);
            DatabaseContext.SaveChanges();
            return true;
        }

        public override Technology Find(int id)
        {
            var listOfAllTechs = DatabaseContext.Technologies.ToList();
            return listOfAllTechs.Find(x => x.TechnologyId.Equals(id));
        }

        public Dictionary<int, string> GetClearencesColors()
        {
            var colors = new Dictionary<int, string>();
            var clereances = DatabaseContext.Clearences.ToList();
            clereances.ForEach(x => colors.Add(x.ClearenceId, x.ClearenceRgbColor));
            return colors;
        }
    }
}