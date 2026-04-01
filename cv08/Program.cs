using System;

class Program
{
    static void Main(string[] args)
    {
        ArchivTeplot archiv = new ArchivTeplot();

        try
        {
            Console.WriteLine("--- Načítání dat ---");
            archiv.Load("vstup.txt");

            Console.WriteLine("\n--- Přehled všech teplot ---");
            archiv.TiskTeplot();

            Console.WriteLine();
            archiv.TiskPrumernychRocnichTeplot();
            Console.WriteLine();
            archiv.TiskPrumernychMesicnichTeplot();

            Console.WriteLine("\n--- Provádím kalibraci (-0,1) ---");
            archiv.Kalibrace(-0.1);

            archiv.Save("vystup_kalibrovany.txt");
            Console.WriteLine("Data byla uložena do 'vystup_kalibrovany.txt'.");

            var rok2020 = archiv.Vyhledej(2020);
            if (rok2020 != null)
                Console.WriteLine($"\nMax teplota v roce 2020: {rok2020.MaxTeplota}°C");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Chyba: {ex.Message}");
        }

        Console.WriteLine("\nHotovo. Stiskněte libovolnou klávesu...");
        Console.ReadKey();
    }
}
