using System.Data.Entity.Migrations;
using WebMatrix.WebData;

namespace CorporationHR.Context
{
    public class DatabaseInitializator : DbMigrationsConfiguration<CorporationHrDbContext>
    {
        public DatabaseInitializator()
        {
            this.AutomaticMigrationsEnabled = true;
            SeedMembership();
            AddUsers();
        }

        protected override void Seed(CorporationHrDbContext context)
        {
            SeedMembership();
            base.Seed(context);
        }

        private void SeedMembership()
        {
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName", autoCreateTables: true);
            
        }

        private void AddUsers()
        {
            if (!WebSecurity.UserExists("admin")) { WebSecurity.CreateUserAndAccount("admin", "test", null); }
        }
    }
}