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
			optionsBuilder.UseMySQL(@"Server=localhost;User=chatKor;password='nekasifra';Persist Security Info=False;Database=ChatDB;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Korisnik>().HasKey(k => k.ID);
		}
	}
}
