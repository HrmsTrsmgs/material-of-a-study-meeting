using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQのサンプル
{
    public class Context : DbContext
    {
        public DbSet<Person> People { get; set; }

        public DbSet<ProgramLanuage> ProgramLanuages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(LocalDB)\MSSQLLocalDB;Integrated Security=true;AttachDbFileName=C:\Temp\Database1.mdf");
        }
    }
}
