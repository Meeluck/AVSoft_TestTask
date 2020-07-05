using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using AVSoft_TestTask.Models;

namespace AVSoft_TestTask.Context
{
	public class AVSoftContext :DbContext
	{
		public DbSet<Counter> Counters { get; set; }

		public AVSoftContext(DbContextOptions<AVSoftContext> options)
			: base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Counter>().HasData(
				new Counter[]
				{
					new Counter{Id = 1, Key = 1, Value = 1},
					new Counter{Id = 2, Key = 1, Value = 2},
					new Counter{Id = 3, Key = 1, Value = 3},
					new Counter{Id = 4, Key = 2, Value = 1},
					new Counter{Id = 5, Key = 2, Value = 1},
					new Counter{Id = 6, Key = 2, Value = 3},
					new Counter{Id = 7, Key = 2, Value = 1}
				});
		}
	}
}
