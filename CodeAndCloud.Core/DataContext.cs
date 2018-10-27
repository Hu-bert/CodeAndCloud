using CodeAndCloud.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeAndCloud.Core
{
    public class DataContext: DbContext
    {
        public virtual DbSet<ContactModel> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:codeandclouddb.database.windows.net,1433;Initial Catalog=CodeAndCloudDB;Persist Security Info=False;User ID=codeandcloud;Password=Cloude1!2;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
