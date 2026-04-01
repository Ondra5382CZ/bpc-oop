using System;
using System.Collections.Generic;
using System.Linq;

public class RocniTeplota
{
    public int Rok { get; set; }
    public List<double> MesicniTeploty { get; set; }

    public RocniTeplota(int rok, List<double> teploty)
    {
        Rok = rok;
        MesicniTeploty = teploty ?? new List<double>();
    }

    public double MaxTeplota => MesicniTeploty.Max();
    public double MinTeplota => MesicniTeploty.Min();
    public double PrumRocniTeplota => MesicniTeploty.Average();
}
