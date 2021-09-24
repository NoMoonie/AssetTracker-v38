using System;

namespace AssetTracker
{
	class Program
	{
		/*

			add asset
			what asset to add
			add asset to list
			
			check the list if asset is less the 3 months away from 3 years *Red*
			check the list if asset is less the 6 months away from 3 years *Yellow*
			
			present the list off assets

			amount in USD * Rate
			
		*/
		static void Main(string[] args)
		{
			InputLib MainInput = new InputLib();
			AssetList MainList = new AssetList();
			bool IsLoop = true;
			MainInput.ShowCommands();
			while(IsLoop){
				Console.ResetColor();
				string Input = MainInput.GetUserInput();
				if(Input == "q"){break;}
				if(Input == null){
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("Command not found");
					Console.WriteLine("Type \'help\' to get list of commands");
					continue;
				}
				if(Input == "addphone"){
					string[] TempArr = MainInput.GetAssetFromUser();
					if(TempArr != null){
						//convert to int
						bool[] IsTemp = new bool[4];
						IsTemp[0] = int.TryParse(TempArr[3], out int Year);
						IsTemp[1] = int.TryParse(TempArr[4], out int Month);
						IsTemp[2] = int.TryParse(TempArr[5], out int Day);
						IsTemp[3] = double.TryParse(TempArr[6], out double PriceUSD);
						foreach(bool i in IsTemp){
							if(!i){
								continue;
							}
						}
						double Rate = GetRate(TempArr[2]);
						double PriceInLocal = GetExchangeRate(PriceUSD, Rate);
						//convert price to local price
						try{
							Phone NewPhone = new Phone(){
								Brand = TempArr[0],
								Model = TempArr[1],
								OfficeLocation = TempArr[2],
								PurchaseDate = new DateTime(Year, Month, Day),
								PriceInUSD = PriceUSD,
								LocalPrice = PriceInLocal,
							};
							MainList.AddAsset(NewPhone);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Asset Added");
						}catch(Exception){
							if(ShowErr(Month, Day)){continue;}
						}
					}
					
				}
				if(Input == "addlaptop"){
					string[] TempArr = MainInput.GetAssetFromUser();
					if(TempArr != null){
						//convert to int
						bool[] IsTemp = new bool[4];
						IsTemp[0] = int.TryParse(TempArr[3], out int Year);
						IsTemp[1] = int.TryParse(TempArr[4], out int Month);
						IsTemp[2] = int.TryParse(TempArr[5], out int Day);
						IsTemp[3] = double.TryParse(TempArr[6], out double PriceUSD);
						foreach(bool i in IsTemp){
							if(!i){
								continue;
							}
						}
						double Rate = GetRate(TempArr[2]);
						double PriceInLocal = GetExchangeRate(PriceUSD, Rate);
						//convert price to local price
						try{
							Laptop NewPhone = new Laptop(){
								Brand = TempArr[0],
								Model = TempArr[1],
								OfficeLocation = TempArr[2],
								PurchaseDate = new DateTime(Year, Month, Day),
								PriceInUSD = PriceUSD,
								LocalPrice = PriceInLocal,
							};
							MainList.AddAsset(NewPhone);
							Console.ForegroundColor = ConsoleColor.Green;
							Console.WriteLine("Asset Added");
						}catch(Exception){
							if(ShowErr(Month, Day)){continue;}
						}
					}
				}

				if(Input == "list"){
					MainList.ShowList();
				}
				if(Input == "help"){
					MainInput.ShowCommands();
				}
			}
		}

		static bool ShowErr(double Month, double Day){
			Console.ForegroundColor = ConsoleColor.Red;
			if(Month < 0 || Day < 0){Console.WriteLine("Can't be negitive");return true;}
			if(Month > 12){Console.WriteLine("There is only 12 months in a year");return true;}
			if(Day > 31){Console.WriteLine("There is max 30-31 days in a month");return true;}
			Console.WriteLine("Error");
			return false;
		}

		static double GetRate(string currency){

			if(currency.ToLower().Trim() == "sweden"){
				return 8.6562;
			}
			if(currency.ToLower().Trim() == "spain"){
				return 0.85376;
			}
			return 1;
		}

		static double GetExchangeRate(double Amount, double Rate){
			return Amount * Rate;
		}

	}
}
