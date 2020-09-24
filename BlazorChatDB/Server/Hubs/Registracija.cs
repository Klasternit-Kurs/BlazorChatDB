using BlazorChatDB.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatDB.Server.Hubs
{
	public class Registracija : Hub
	{
		private readonly ILogger<Registracija> _log;

		public Registracija(ILogger<Registracija> log)
		{
			_log = log;
		}

		           
		public void RegistrujSe(Korisnik k)
		{
			_log.LogInformation("U metodi sam :)");
			Baza db = new Baza();
			if (db.Korisniks.Where(kor => kor.Uname == k.Uname).Any())
			{
				_log.LogError("Vec postoji korisnik");
				Clients.Caller.SendAsync("rezreg", false, "Vec postoji!");
			} else
			{
				db.Korisniks.Add(k);
				db.SaveChanges();
				_log.LogInformation("Sve ok :)");
				Clients.Caller.SendAsync("rezreg", true, null);
			}
		}
	}
}
