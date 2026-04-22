using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using cv_11_vyuka.EFCore;

namespace cv_11_vyuka
{
    internal class Program
    {

        // tato funkce PredmetyStudenta vrací list, který obsahuje předměty, které má daný student zapsané
        static List<string> PredmetyStudenta(VyukaContext ctx, int studentId)
        {
            List<string> vysledek = new List<string>();                    // list řetězců, který bude obsahovat seznam předmětů
            List<Spojovaci> spojovaci = new List<Spojovaci>(ctx.Spojovaci);

            // procházím spojovací tabulku a pokud se bude ID_Studenta shodovat se studentId (parametr funkce), tak zkratku předmetu na daném řádku přidám do listu výsledek
            for (int i = 0; i < spojovaci.Count; i++)
            {
                if (spojovaci[i].ID_Studenta == studentId)
                {
                    vysledek.Add(spojovaci[i].ZkratkaPredmetu);
                }
            }
            // vrátím list s předměty, které má daný student zapsané
            return vysledek;
        }

        // tato funkce StudentiPredmetu vrací list, který obsahuje ID studentů, kteří mají zapsaný daný předmět
        static List<int> StudentiPredmetu(VyukaContext ctx, string zkratka)
        {
            List<int> vysledek = new List<int>();   // list intů, který bude obsahovat seznam ID studentů
            List<Spojovaci> spojeni = new List<Spojovaci>(ctx.Spojovaci);

            // procházím spojovací tabulku a pokud se bude ZkratkaPredmetu shodovat se zkratka (parametr funkce), tak ID studenta na daném řádku přidám do listu výsledek
            for (int i = 0; i < spojeni.Count; i++)
            {
                if (spojeni[i].ZkratkaPredmetu == zkratka)
                {
                    vysledek.Add(spojeni[i].ID_Studenta);
                }
            }
            // vrátím list s ID studentů, kteří mají daný předmět zapsaný
            return vysledek;
        }


        static void Main(string[] args)
        {
            var ctx = new VyukaContext(); // připojení k databází
            ctx.Database.EnsureCreated(); // pokud neexistuje, tak ji vytvoří
            DataSeeder.Seed(ctx);         // naplní data



            // --- VÝPIS POČTU STUDENTŮ JEDNOTLIVÝCH PŘEDMĚTŮ ---
            Console.Write("--- VÝPIS POČTU STUDENTŮ JEDNOTLIVÝCH PŘEDMĚTŮ ---\n\n");

            Console.WriteLine("{0,-30} {1,5}", "Předmět", "Počet"); // zarovnání doleva, "Předmět" zabere 30 znaků
            Console.WriteLine(new string('-', 40));                 // vypíše vodorovnou čáru

            List<Predmety>  vsechnyPredmety = new List<Predmety>(ctx.Predmety);
            List<Spojovaci> vsechnySpojeni  = new List<Spojovaci>(ctx.Spojovaci);
            List<Studenti>  vsichniStudenti = new List<Studenti>(ctx.Studenti);
            List<Hodnoceni> hodnoceni       = new List<Hodnoceni>(ctx.Hodnoceni);

            // výpis počtu studentů u daného předmětu
            List<(string nazev, int pocet)> report = new List<(string, int)>(); // pomocný výsledný list

            // vnější cyklus do proměnné zkratka uloží novou zkratku z tabulky Predmety při každé iteraci
            // vnitřní cyklus porovnává aktuálně vybranou zkratku se zkratkami v tabulce Spojovaci a pokaždé co najde stejnou zkratku, tak zvýší počet o +1
            for (int i = 0; i < vsechnyPredmety.Count; i++)
            {
                string zkratka = vsechnyPredmety[i].Zkratka;
                int pocet = 0;

                for (int j = 0; j < vsechnySpojeni.Count; j++)
                {
                    if (vsechnySpojeni[j].ZkratkaPredmetu == zkratka)
                    {
                        pocet++;
                    }
                }

                // do pomocného výsledného listu uložím aktuální zkratku předmětu a počet zapsaných studentů v tomto předmětu
                report.Add((vsechnyPredmety[i].NazevPredmetu, pocet));
            }

            // Ruční řazení podle počtu sestupně pomocí bubble sort
            for (int i = 0; i < report.Count - 1; i++)
            {
                for (int j = i + 1; j < report.Count; j++)
                {
                    if (report[j].pocet > report[i].pocet)
                    {
                        var temp = report[i];
                        report[i] = report[j];
                        report[j] = temp;
                    }
                }
            }

            // výpis počtu studentů u daného předmětu
            for (int i = 0; i < report.Count; i++)
            {
                Console.WriteLine("{0,-30} {1,5}", report[i].nazev, report[i].pocet);
            }



            // --- VŠICHNI STUDENTI A JEJICH PŘEDMĚTY ---
            Console.WriteLine("\n--- VŠICHNI STUDENTI A JEJICH PŘEDMĚTY ---");

            // vnější cyklus vezme vždy ID jednoho studenta a zavolá funkci PredmetyStudenta, která vrátí list předmětů, které má daný student zapsané
            // vnitřní cyklus slouží k výpisu
            for (int i = 0; i < vsichniStudenti.Count; i++)
            {
                int ID = vsichniStudenti[i].ID;
                List<string> predmety = PredmetyStudenta(ctx, ID);

                Console.WriteLine("\n" + vsichniStudenti[i].Jmeno + " " + vsichniStudenti[i].Prijmeni + " má zapsané předměty:");

                for (int j = 0; j < predmety.Count; j++)
                {
                    Console.WriteLine("  - " + predmety[j]);
                }
            }



            // --- VŠECHNY PŘEDMĚTY A JEJICH STUDENTI ---
            Console.WriteLine("\n--- VŠECHNY PŘEDMĚTY A JEJICH STUDENTI ---");

            // vnější cyklus vezme vždy jednu zkratku a zavolá funkci StudentiPredmetu, která vrátí ID studentů, kteří mají daný předmět zapsaný
            // další dva vnořené cykly mají na starost to, že porovnávají všechny ID studentů, kteří mají předmět zapsaný s ID všech studentů
            // pokud se bude ID ze vsichniStudenti shodovat se studentId, vypíše se jméno studenta a příjmení na daném indexu
            for (int i = 0; i < vsechnyPredmety.Count; i++)
            {
                string zkratka = vsechnyPredmety[i].Zkratka;
                List<int> studentiId = StudentiPredmetu(ctx, zkratka);

                Console.WriteLine("\n" + zkratka + " má zapsané studenty:");

                for (int j = 0; j < studentiId.Count; j++)
                {
                    for (int k = 0; k < vsichniStudenti.Count; k++)
                    {
                        if (vsichniStudenti[k].ID == studentiId[j])
                        {
                            Console.WriteLine("  - " + vsichniStudenti[k].Jmeno + " " + vsichniStudenti[k].Prijmeni);
                            break;
                        }
                    }
                }
            }



            // --- PRŮMĚRNÉ ZNÁMKY U PŘEDMĚTŮ ---
            Console.WriteLine("\n--- PRŮMĚRNÉ ZNÁMKY PODLE PŘEDMĚTŮ ---");

            // vnější cyklus při každé iteraci do proměnné zkratka vezme aktuální zkratku a nastaví soucet a počet = 0
            // vnitřní cyklus má za úkol vypočítat průměrnou známku v každém předmětu
            // pokud je počet hodnocení v předmětu větší než 0, tak vypočítá průměr a ten vypíše na obrazovku

            for (int i = 0; i < vsechnyPredmety.Count; i++)
            {
                string zkratka = vsechnyPredmety[i].Zkratka;
                int soucet = 0;
                int pocet = 0;

                for (int j = 0; j < hodnoceni.Count; j++)
                {
                    if (hodnoceni[j].ZkratkaPredmetu == zkratka)
                    {
                        soucet += hodnoceni[j]._Hodnoceni;
                        pocet++;
                    }
                }

                if (pocet > 0)
                {
                    float prumer = soucet / pocet;
                    Console.WriteLine("{0,-30} {1:F2}", vsechnyPredmety[i].NazevPredmetu, prumer); // F2 - zobraz na 2 desetinná místas
                }
            }
        }
    }
}
