using BlazorChatDB.Shared;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorChatDB.Server.Hubs
{
	public class Chat : Hub
	{
		private readonly ILogger<Chat> _logger;

		public Chat(ILogger<Chat> logger)
		{
			_logger = logger;
		}

		public void PorukaServer(Poruka p)
		{
			Clients.All.SendAsync("PorukaKlijent", p);
		}

		public void LogInServ(Korisnik k)
		{
			_logger.LogInformation("Pocinjem sa login metodom");
			Baza db = new Baza();

			Korisnik ulogovanKorisnik = db.Korisniks.Where(kor => kor.Uname == k.Uname
													&& kor.Sifra == k.Sifra).FirstOrDefault();
			if (ulogovanKorisnik != null)
			{
				_logger.LogInformation("Uspesno ulogovan");
				Clients.Caller.SendAsync("KorOdServera", true, ulogovanKorisnik);
			} else
			{
				_logger.LogWarning("Los log in");
				Clients.Caller.SendAsync("KorOdServera", false, ulogovanKorisnik);
			}
		}
	}
}
