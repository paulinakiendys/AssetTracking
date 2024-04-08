using AssetTracking;

AssetManager assetManager = new AssetManager();
assetManager.AddSampleData();

bool exit = false;

while (!exit)
{
    ShowMainMenu();

    string userInput = Console.ReadLine().ToUpper();

    switch (userInput)
    {
        case "A":
            assetManager.AddAsset();
            break;
        case "L":
            assetManager.ListAssets();
            break;
        case "Q":
            Console.WriteLine("Thank you for using this application");
            exit = true;
            break;
        default:
            AssetManager.DisplayErrorMessage("Invalid Selection");
            break;
    }
}

static void ShowMainMenu()
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine("To add a new asset - enter: 'A'");
    Console.WriteLine("To list assets - enter: 'L'");
    Console.WriteLine("To quit - enter: 'Q'");
    Console.ResetColor();
}
