using QO1APY.Helpers;
using QO1APY.Services;

string[] menuOptions = { "Játék indítása", "Leaderboard megtekintése", "Kilépés" };
int selectedIndex = 0;
bool running = true;

while (running)
{
    MenuHelper.ShowMenu(menuOptions, selectedIndex);

    ConsoleKey key = Console.ReadKey(true).Key;

    switch (key)
    {
        case ConsoleKey.UpArrow:
            selectedIndex = (selectedIndex - 1 + menuOptions.Length) % menuOptions.Length;
            break;
        case ConsoleKey.DownArrow:
            selectedIndex = (selectedIndex + 1) % menuOptions.Length;
            break;
        case ConsoleKey.Enter:
            switch (selectedIndex)
            {
                case 0:
                    GameService.StartGame();
                    break;
                case 1:
                    GameService.ShowLeaderboard();
                    break;
                case 2:
                    Console.WriteLine("\nKilépés... Viszlát!");
                    Thread.Sleep(1000);
                    running = false;
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nNyomjon Entert a visszatéréshez a menübe...");
                Console.ReadLine();
            }
            break;
    }
}