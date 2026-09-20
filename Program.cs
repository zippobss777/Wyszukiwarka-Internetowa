using System;
using System.Diagnostics;

ConsoleKeyInfo key;
do
{
    Console.Clear();

    Console.WriteLine("================");
    Console.WriteLine("  WYSZUKIWARKA  ");
    Console.WriteLine("================");
    Console.WriteLine("");

    Console.ForegroundColor = ConsoleColor.DarkYellow;
    Console.Write("Podaj URL strony: ");
    Console.ForegroundColor = ConsoleColor.Yellow;
    string input = Console.ReadLine();

    // sprawdzenie, czy coś zostało wpisane
    if (string.IsNullOrWhiteSpace(input))
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("NIC NIE WPISANO!");
        return;
    }

    string url;

    if (input.StartsWith("https://") || input.StartsWith("http://"))
    {
        url = input;
    }
    else
    {
        url = "https://google.com/search?q=" + Uri.EscapeDataString(input);
    }

    try
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });

        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.WriteLine($"Otwieranie: {url}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Błąd otwierania przeglądarki: {ex.Message}");
    }


    if(input == 67)
    {
        Console.WriteLine("Matka Cię nie kocha kurwo");
    }

    Console.ForegroundColor = ConsoleColor.Gray;
    Console.WriteLine("");
    Console.WriteLine("[ENTER] - restart programu do stanu początkowego");
    Console.WriteLine("[INNY KLAWISZ] - zakończenie działania programu");
    key = Console.ReadKey(true);

} while (key.Key == ConsoleKey.Enter);