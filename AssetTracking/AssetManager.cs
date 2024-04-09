using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class AssetManager
    {
        private List<Asset> assets = new List<Asset>();

        // Method to add sample data
        public void AddSampleData()
        {
            assets.Add(new Phone("Apple", "iPhone 12", new DateOnly(2021, 10, 13), 970, new Office("Sweden", "SEK")));
            assets.Add(new Phone("Samsung", "Galaxy S21", new DateOnly(2021, 10, 12), 860, new Office("Sweden", "SEK")));
            assets.Add(new Computer("Apple", "MacBook Pro", new DateOnly(2021, 10, 10), 1480, new Office("Spain", "EUR")));
            assets.Add(new Computer("Asus", "ZenBook", new DateOnly(2021, 7, 10), 1200, new Office("USA", "USD")));
        }
        // Method to add a new asset
        public void AddAsset()
        {
            string type = GetType();
            string brand = GetBrand();
            string model = GetModel();
            Office office = GetOffice();
            DateOnly purchaseDate = GetPurchaseDate();
            int price = GetPrice();

            Asset asset = CreateAsset(type, brand, model, purchaseDate, price, office);

            assets.Add(asset);
            DisplaySuccessMessage("Successfully added asset!");
        }

        // Method to get type input from the user
        private static string GetType()
        {
            Console.WriteLine("Select a Type: ");
            Console.WriteLine("(1) - Phone");
            Console.WriteLine("(2) - Computer");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return "Phone";
                case "2":
                    return "Computer";
                default:
                    DisplayErrorMessage("Invalid Selection");
                    return GetType();
            }
        }

        // Method to get asset brand input from the user
        private static string GetBrand()
        {
            try
            {
                Console.Write("Enter a Brand: ");
                string brand = Console.ReadLine();
                ArgumentException.ThrowIfNullOrWhiteSpace(brand);
                return brand;
            }
            catch (Exception e)
            {
                DisplayErrorMessage(e.Message);
                return GetBrand();
            }
        }

        // Method to get asset model input from the user
        private static string GetModel()
        {
            try
            {
                Console.Write("Enter a Model: ");
                string model = Console.ReadLine();
                ArgumentException.ThrowIfNullOrWhiteSpace(model);
                return model;
            }
            catch (Exception e)
            {
                DisplayErrorMessage(e.Message);
                return GetBrand();
            }
        }

        // Method to get asset office input from the user
        private static Office GetOffice()
        {
            Console.WriteLine("Select an Office: ");
            Console.WriteLine("(1) - Spain");
            Console.WriteLine("(2) - Sweden");
            Console.WriteLine("(3) - USA");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    return new Office("Spain", "EUR");
                case "2":
                    return new Office("Sweden", "SEK");
                case "3":
                    return new Office("USA", "USD");
                default:
                    DisplayErrorMessage("Invalid Selection");
                    return GetOffice();
            }
        }

        // Method to get asset purchase date input from the user
        private static DateOnly GetPurchaseDate()
        {
            try
            {
                string[] format = { "MM/dd/yyyy" };
                Console.Write("Enter a Purchase Date (MM/dd/yyyy): ");
                DateOnly purchaseDate = DateOnly.ParseExact(Console.ReadLine(), format, CultureInfo.InvariantCulture);
                return purchaseDate;
            }
            catch (Exception e)
            {
                DisplayErrorMessage(e.Message);
                return GetPurchaseDate();
            }
        }

        // Method to get asset price input from the user
        private static int GetPrice()
        {
            try
            {
                Console.Write("Enter a Price: ");
                int price = int.Parse(Console.ReadLine());
                return price;
            }
            catch (Exception e)
            {
                DisplayErrorMessage(e.Message);
                return GetPrice();
            }
        }

        // Method to create an asset based on input
        private static Asset CreateAsset(string type, string brand, string model, DateOnly purchaseDate, double price, Office office)
        {
            return type == "Phone" ?
                   new Phone(brand, model, purchaseDate, price, office) :
                   new Computer(brand, model, purchaseDate, price, office);
        }

        // Method to display success message
        private static void DisplaySuccessMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Method to display error message
        public static void DisplayErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Method to list assets
        public void ListAssets()
        {
            DisplayHeader();
            DisplaySortedAssets();
        }

        // Method to display header of asset list
        private static void DisplayHeader()
        {
            string[] headers = { "Type", "Brand", "Model", "Office", "Purchase Date", "Price in USD", "Currency", "Local price today" };

            foreach (string header in headers)
            {
                Console.Write(header.PadRight(14));
            }
            Console.WriteLine();

            foreach (string header in headers)
            {
                Console.Write(new string('-', header.Length).PadRight(14));
            }
            Console.WriteLine();
        }

        // Method to display sorted assets
        private void DisplaySortedAssets()
        {
            List<Asset> sortedList = SortAssets();
            foreach (Asset item in sortedList)
            {
                DisplayAsset(item);
            }
        }

        // Method to sort assets by office and then by purchase date
        private List<Asset> SortAssets()
        {
            return assets = [.. assets.OrderBy(asset => asset.Office.Country).ThenBy(asset => asset.PurchaseDate)];
        }

        // Method to display a single asset
        private static void DisplayAsset(Asset item)
        {
            double localPriceToday = GetLocalPriceToday(item);

            HighlightAssetBasedOnPurchaseDate(item);

            Console.WriteLine(
            item.GetType().Name.PadRight(14) +
            item.Brand.PadRight(14) +
            item.Model.PadRight(14) +
            item.Office.Country.PadRight(14) +
            item.PurchaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture).PadRight(14) +
            item.Price.ToString().PadRight(14) +
            item.Office.Currency.PadRight(14) +
            FormatPrice(localPriceToday));

            Console.ResetColor();
        }

        // Method to calculate local price today based on currency
        private static double GetLocalPriceToday(Asset item)
        {
            double usdToSek = 10.635816;
            double usdToEur = 0.92290012;

            if (item.Office.Currency == "EUR")
            {
                return item.Price * usdToEur;
            }
            else if (item.Office.Currency == "SEK")
            {
                return item.Price * usdToSek;
            }
            else
            {
                return item.Price;
            }
        }

        // Method to format the price
        private static string FormatPrice(double price)
        {
            return Math.Abs(price % 1) > 0 ? price.ToString("0.00") : price.ToString();
        }

        // Method to highlight an asset based on purchase date
        private static void HighlightAssetBasedOnPurchaseDate(Asset item)
        {
            DateOnly today = DateOnly.FromDateTime(DateTime.Now);
            if (today >= item.PurchaseDate.AddYears(3).AddMonths(-6) && today <= item.PurchaseDate.AddYears(3).AddMonths(-3))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            if (today >= item.PurchaseDate.AddYears(3).AddMonths(-3))
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }
        }
    }
}