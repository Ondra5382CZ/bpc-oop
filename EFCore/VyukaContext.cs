// VyukaContext.cs
using Microsoft.EntityFrameworkCore;

namespace cv_11_vyuka.EFCore
{
    public class VyukaContext : DbContext
    {
        public List<Studenti>  Studenti  { get; set; } = new List<Studenti>();
        public List<Predmety>  Predmety  { get; set; } = new List<Predmety>();
        public List<Spojovaci> Spojovaci { get; set; } = new List<Spojovaci>();
        public List<Hodnoceni> Hodnoceni { get; set; } = new List<Hodnoceni>();

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Vyuka;Trusted_Connection=True;");

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Studenti>().ToTable("Studenti").HasKey(s => s.ID);                         // určuje název databázové tabulky, na kterou se bude entita Studenti mapovat a definujeme primární klíč - ID
            model.Entity<Studenti>().Property(s => s.ID).HasColumnName("ID");                       // mapuje ID na sloupec s názvem ID
            model.Entity<Studenti>().Property(s => s.DatumNarozeni).HasColumnName("DatumNarozeni"); // mapuje DatumNarozeni na sloupec s názvem DatumNarozeni

            model.Entity<Predmety>().ToTable("Predmety").HasKey(p => p.Zkratka);                    // určuje název databázové tabulky, na kterou se bude entita Studenti mapovat a definujeme primární klíč - Zkratka
            model.Entity<Predmety>().Property(p => p.Zkratka).HasColumnName("Zkratka");             // mapuje Zkratka na sloupec s názvem Zkratka
            model.Entity<Predmety>().Property(p => p.NazevPredmetu).HasColumnName("NazevPredmetu"); // mapuje NazevPredmetu na sloupec s názvem NazevPredmetu

            model.Entity<Spojovaci>().ToTable("Spojovaci").HasKey(s => new { s.ID_Studenta, s.ZkratkaPredmetu }); // nastavuje primární klíč složený ze sloupců ID_Studenta a ZkratkaPredmetu
            model.Entity<Spojovaci>().Property(s => s.ID_Studenta).HasColumnName("ID_Studenta");                  // mapuje ID_Studenta na sloupec s názvem ID_Studenta
            model.Entity<Spojovaci>().Property(s => s.ZkratkaPredmetu).HasColumnName("ZkratkaPredmetu");          // mapuje ZkratkaPredmetu na sloupec s názvem ZkratkaPredmetu 
            model.Entity<Spojovaci>().HasOne(s => s.Student).WithMany().HasForeignKey(s => s.ID_Studenta);        // nastavuje cizí klíč 
            model.Entity<Spojovaci>().HasOne(s => s.Predmet).WithMany().HasForeignKey(s => s.ZkratkaPredmetu);    // nastavuje cizí klíč
            /*
            Každý záznam v tabulce Spojovaci odkazuje na jednoho studenta a jeden předmět.
            Zároveň jeden student může být ve více záznamech (WithMany()), protože může mít více předmětů.
            A jeden předmět může být ve více záznamech, protože ho studuje více studentů. 
            */

            model.Entity<Hodnoceni>().ToTable("Hodnoceni").HasKey(h => new { h.ID_Studenta, h.ZkratkaPredmetu });    // nastavuje primární klíč složený ze sloupců ID_Studenta a ZkratkaPredmetu
            model.Entity<Hodnoceni>().Property(h => h.ID_Studenta).HasColumnName("ID_Studenta");                     // mapuje ID_Studenta na sloupec s názvem ID_Studenta
            model.Entity<Hodnoceni>().Property(h => h.ZkratkaPredmetu).HasColumnName("ZkratkaPredmetu");             // mapuje ZkratkaPredmetu na sloupec s názvem ZkratkaPredmetu
            model.Entity<Hodnoceni>().Property(h => h.DatumHodnoceni).HasColumnName("DatumHodnoceni");               // mapuje DatumHodnoceni na sloupec s názvem DatumHodnoceni
            model.Entity<Hodnoceni>().Property(h => h._Hodnoceni).HasColumnName("Hodnoceni");                        // mapuje _Hodnoceni na sloupec s názvem _Hodnoceni
            model.Entity<Hodnoceni>().HasOne(h => h.Student).WithMany().HasForeignKey(h => h.ID_Studenta);           // nastavuje cizí klíč 
            model.Entity<Hodnoceni>().HasOne(h => h.Predmet).WithMany().HasForeignKey(h => h.ZkratkaPredmetu);       // nastavuje cizí klíč 
        }
    }
}
