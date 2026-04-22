namespace cv_11_vyuka.EFCore
{
    public class Spojovaci
    {
        // getters and setters 
        public string ZkratkaPredmetu { get; set; } = null!;
        public int ID_Studenta { get; set; }

        // musím vytvořit kvůli nastavení cizích klíču ve VyukaContext.cs
        public Studenti Student { get; set; } = null!;
        public Predmety Predmet { get; set; } = null!;
    }
}










