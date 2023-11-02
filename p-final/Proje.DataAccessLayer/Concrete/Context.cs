using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Proje.EntityLayer.Concrate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proje.DataAccessLayer.Concrete
{
	public class Context : IdentityDbContext<AppUser,AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=ELITEBOOK\\MSSQLSERVER01;initial catalog=ProjeDB3;integrated Security=true;TrustServerCertificate=True;");
		}
		public DbSet<Category> Categories { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<Idea> Ideas { get; set; }
	}
}
