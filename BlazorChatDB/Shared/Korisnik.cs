using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorChatDB.Shared
{  
	public class Korisnik
	{
		public int ID { get; set; }
		public string Uname { get; set; }
		public string Sifra { get; set; }
		public DateTime UclanioSe { get; set; }
	}
}
