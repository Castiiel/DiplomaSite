using ColumnAdministrator.Web.Infrastructure;

namespace ColumnAdministrator.Web.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "ColumnAdministrator.Web.Models.ApplicationDbContext";
        }

        protected override void Seed(ApplicationDbContext context)
        {
            InitializeHelper.SeedMembership(context);
            InitializeHelper.SeedItems(context);
        }
    }
}
