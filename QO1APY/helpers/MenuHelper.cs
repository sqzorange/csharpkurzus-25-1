namespace QO1APY.Helpers;
public class MenuHelper
{
    public static void ShowMenu(string[] options, int selectedIndex)
    {
        Console.Clear();
        Console.WriteLine("=== Kvízjáték ===\n");

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"> {options[i]}");
                Console.ResetColor();
            }
            else
            {
                Console.WriteLine($"  {options[i]}");
            }
        }
    }
}