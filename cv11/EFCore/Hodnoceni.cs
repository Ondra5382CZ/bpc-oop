using System;

namespace cv_11_vyuka.EFCore
{
    public class Hodnoceni
    {
        // getters and setters 
        public int ID_Studenta { get; set; } 
        public string ZkratkaPredmetu { get; set; } = null!;
        public DateTime DatumHodnoceni { get; set; }
        public int _Hodnoceni { get; set; }

        // musím vytvořit kvůli nastavení cizích klíču ve VyukaContext.cs
        public Studenti Student { get; set; } = null!;
        public Predmety Predmet { get; set; } = null!;
    }
}






