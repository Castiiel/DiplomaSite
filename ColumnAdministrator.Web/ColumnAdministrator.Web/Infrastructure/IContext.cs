using System.Data.Entity;
using Calabonga.Account.Data;
using ColumnAdministrator.Web.Models;

namespace ColumnAdministrator.Web.Infrastructure
{
	public interface IContext : IDbContext
	{
	    IDbSet<Appliance> Appliances { get; set; }
	}
}
