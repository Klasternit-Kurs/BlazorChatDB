using BlazorChatDB.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatDB.Server
{
	public class Baza : DbContext
	{
		public DbSet<Korisnik> Korisniks { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySQL(@"Server=127.0.0.1;User=test;password='sifra';Persist Security Info=False;Initial Catalog=ProbnaBaza;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Korisnik>().HasKey(k => k.ID);
		}
	}
}
