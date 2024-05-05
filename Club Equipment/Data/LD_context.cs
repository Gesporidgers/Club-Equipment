using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Club_Equipment;

    public class LD_context : DbContext
    {
        public LD_context (DbContextOptions<LD_context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Club_Equipment.LDevice> LDevice { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseSqlite("Data Source = LD.db");
	}
}
