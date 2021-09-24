using System;


namespace AssetTracker
{
	public class Asset
	{
		public string Brand { get; set; }
		public string Model { get; set; }
		public string OfficeLocation { get; set; }
		public DateTime PurchaseDate { get; set; }
		public double PriceInUSD { get; set; }
		public double LocalPrice { get; set; }
		public string Currency { get; set; }
	}

}