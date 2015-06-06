using System.Data.Entity;
using Calabonga.Account.Data;
using ColumnAdministrator.Web.Models;

namespace ColumnAdministrator.Web.Infrastructure
{
    public class ApplicationDbContext : DataContext, IContext
    {

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public IDbSet<Appliance> Appliances { get; set; }
    }
}