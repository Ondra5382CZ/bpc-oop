using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;

public class ArchivTeplot
{
    private SortedDictionary<int, RocniTeplota> _archiv = new SortedDictionary<int, RocniTeplota>();

    public void Load(string cesta)
    {
        _archiv.Clear();
        foreach (string radek in File.ReadLines(cesta))
        {
            if (string.IsNullOrWhiteSpace(radek)) continue;

            var casti = radek.Split(':');
            int rok = int.Parse(casti[0].Trim());

            var teploty = casti[1].Split(';')
                .Select(s => double.Parse(s.Trim(), CultureInfo.GetCultureInfo("cs-CZ")))
                .ToList();

            _archiv.Add(rok, new RocniTeplota(rok, teploty));
        }
    }

    public void Save(string cesta)
    {
        using (StreamWriter sw = new StreamWriter(cesta))
        {
            foreach (var polozka in _archiv.Values)
            {
                string teplotyStr = string.Join("; ", polozka.MesicniTeploty.Select(t => t.ToString("0.0", CultureInfo.GetCultureInfo("cs-CZ"))));
                sw.WriteLine($"{polozka.Rok}: {teplotyStr}");
            }
        }
    }

    public void Kalibrace(double konstanta)
    {
        foreach (var polozka in _archiv.Values)
        {
            for (int i = 0; i < polozka.MesicniTeploty.Count; i++)
            {
                polozka.MesicniTeploty[i] += konstanta;
            }
        }
    }

    public RocniTeplota Vyhledej(int rok)
    {
        _archiv.TryGetValue(rok, out var nalezena);
        return nalezena;
    }

    public void TiskTeplot()
    {
        foreach (var r in _archiv.Values)
        {
            string t = string.Join("\t", r.MesicniTeploty.Select(x => x.ToString("0.0")));
            Console.WriteLine($"{r.Rok}: {t}");
        }
    }

    public void TiskPrumernychRocnichTeplot()
    {
        Console.WriteLine("Průměrné roční teploty:");
        foreach (var r in _archiv.Values)
        {
            Console.WriteLine($"{r.Rok}: {r.PrumRocniTeplota,5:0.0}°C");
        }
    }

    public void TiskPrumernychMesicnichTeplot()
    {
        Console.WriteLine("Průměrné měsíční teploty za celé období:");
        for (int m = 0; m < 12; m++)
        {
            double prumer = _archiv.Values.Average(r => r.MesicniTeploty[m]);
            Console.WriteLine($"{m + 1}. měsíc: {prumer,5:0.0}°C");
        }
    }
}
