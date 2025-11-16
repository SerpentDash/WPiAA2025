using System;

namespace Adapter
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var nightClub = new NightClub();

			var adult = new Adult("Jan", 33);
			// Krzyś, 17 lat - normally not allowed
			var krzys = new FakeAdult("Krzyś", 17);

			nightClub.letsParty(adult);   // normal adult
			nightClub.letsParty(krzys);   // fake adult (adapter)

            //var teenager = new Teenager("Młody", 16);
            //nightClub.letsParty(teenager);   // teenager
		}
	}
}
