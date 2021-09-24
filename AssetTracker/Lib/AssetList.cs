using System;
using System.Collections.Generic;
using System.Linq;

namespace AssetTracker
{
	public class AssetList
	{
		private List<Asset> Assets;
		public AssetList()
		{
			Assets = new List<Asset>();    
		}

		public void AddAsset(Asset Asset){
			Assets.Add(Asset);
		}
		public void ShowList(){
			string[] Temp = new string[]{
				"Brand", "Model","Office","Date","Price in USD","Local price"
			};
			foreach(string i in Temp){
				Console.Write("| "+i.PadRight(15));
			}
			Console.WriteLine("\n|----------------|----------------|----------------|----------------|----------------|----------------");
			var NewList = SortList();
			foreach(Asset i in NewList){
				int Check = CheckDate(i.PurchaseDate);
				if(Check == 1){
					Console.ForegroundColor = ConsoleColor.Red;
				}
				else if(Check == -1){
					Console.ForegroundColor = ConsoleColor.Yellow;
				}else{
					Console.ResetColor();
				}
				Console.WriteLine($"| {i.Brand.PadRight(15)}| {i.Model.PadRight(15)}| {i.OfficeLocation.PadRight(15)}| {i.PurchaseDate.ToString("yyyy-MM-dd").PadRight(15)}| {i.PriceInUSD.ToString("0.00").PadRight(15)}| {i.LocalPrice.ToString("0.00").PadRight(15)}");
				Console.ResetColor();
			}
			Console.WriteLine("|----------------|----------------|----------------|----------------|----------------|----------------");
			Console.WriteLine("");
		}

		private List<Asset> SortList(){
			List<Asset> SortedList = Assets.OrderByDescending(Asset => Asset.OfficeLocation).ThenByDescending(Asset => Asset.PriceInUSD).ToList();
			return SortedList;
		}

		private int CheckDate(DateTime date){
			//get current date 
			DateTime CurrentDate = DateTime.Today;
			int m1 = (CurrentDate.Month - date.Month);
			int m2 = (CurrentDate.Year - date.Year) * 12;
			int months = m1 + m2;
			if(33 <= months){
				return 1;
			}
			else if(30 <= months){
				return -1;
			}
			else{
				return 0;
			}
		}
	}

}