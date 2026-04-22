using System;
using System.Collections.Generic;
using cv_11_vyuka.EFCore;

namespace cv_11_vyuka
{
    public static class DataSeeder
    {
        public static void Seed(VyukaContext ctx)
        {
            var students = new[]
            {
                new Studenti{ ID=1, Jmeno="Šimon",  Prijmeni="Strela",     DatumNarozeni=DateTime.Parse("2000-02-02") },
                new Studenti{ ID=2, Jmeno="Filip",  Prijmeni="Zavinác",    DatumNarozeni=DateTime.Parse("1999-08-03") },
                new Studenti{ ID=3, Jmeno="Honza",  Prijmeni="Štrudl",     DatumNarozeni=DateTime.Parse("2000-06-05") },
                new Studenti{ ID=4, Jmeno="Michal", Prijmeni="Šiška",      DatumNarozeni=DateTime.Parse("2005-08-07") },
                new Studenti{ ID=5, Jmeno="Hagrid", Prijmeni="Dumbledore", DatumNarozeni=DateTime.Parse("1993-03-08") },
                new Studenti{ ID=6, Jmeno="Harry",  Prijmeni="Šiška",      DatumNarozeni=DateTime.Parse("2003-09-09") },
            };

            for (int i = 0; i < students.Length; i++)
            {
                var s = students[i];

                // Kontrola existence pomocí Any
                if (!ctx.Studenti.Any(st => st.ID == s.ID))
                {
                    ctx.Studenti.Add(s);
                }
            }
            /*
            for (int i = 0; i < students.Length; i++)
            {
                var s = students[i];
                bool exists = false;
                for (int j = 0; j < ctx.Studenti.Count; j++)
                {
                    if (ctx.Studenti[j].ID == s.ID)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists == false)
                {
                    ctx.Studenti.Add(s);
                }
            }
            */
            ctx.SaveChanges();


            var subjects = new[]
            {
                new Predmety{ Zkratka="ALD",  NazevPredmetu="Algoritmy a datové struktury" },
                new Predmety{ Zkratka="DEAD", NazevPredmetu="Neboli smrtelná komba" },
                new Predmety{ Zkratka="MOD",  NazevPredmetu="Modelování a simulace" },
                new Predmety{ Zkratka="RR1",  NazevPredmetu="Řízení a regulace 1" },
                new Predmety{ Zkratka="RR2",  NazevPredmetu="Řízení a regulace 2" },
                new Predmety{ Zkratka="SAS",  NazevPredmetu="Signály a systémy" },
            };

            for (int i = 0; i < subjects.Length; i++)
            {
                var p = subjects[i];

                // Kontrola existence pomocí Any
                if (!ctx.Predmety.Any(pr => pr.Zkratka == p.Zkratka))
                {
                    ctx.Predmety.Add(p);
                }
            }
            /*
            for (int i = 0; i < subjects.Length; i++)
            {
                var p = subjects[i];
                bool exists = false;
                for (int j = 0; j < ctx.Predmety.Count; j++)
                {
                    if (ctx.Predmety[j].Zkratka == p.Zkratka)
                    {
                        exists = true;
                        break;
                    }
                }

                if (exists == false)
                {
                    ctx.Predmety.Add(p);
                }
            }
            */
            ctx.SaveChanges();


            var zapis = new[]
            {
                new Spojovaci{ ID_Studenta=1, ZkratkaPredmetu="ALD" },
                new Spojovaci{ ID_Studenta=2, ZkratkaPredmetu="ALD" },
                new Spojovaci{ ID_Studenta=3, ZkratkaPredmetu="ALD" },
                new Spojovaci{ ID_Studenta=5, ZkratkaPredmetu="MOD" },
                new Spojovaci{ ID_Studenta=6, ZkratkaPredmetu="RR1" },
                new Spojovaci{ ID_Studenta=4, ZkratkaPredmetu="RR2" },
                new Spojovaci{ ID_Studenta=2, ZkratkaPredmetu="SAS" },
            };

            for (int i = 0; i < zapis.Length; i++)
            {
                var e = zapis[i];

                if (!ctx.Spojovaci.Any(spoj =>
                    spoj.ID_Studenta == e.ID_Studenta &&
                    spoj.ZkratkaPredmetu == e.ZkratkaPredmetu))
                {
                    ctx.Spojovaci.Add(e);
                }
            }
            /*
            for (int i = 0; i < zapis.Length; i++)
            {
                var e = zapis[i];
                bool exists = false;
                for (int j = 0; j < ctx.Spojovaci.Count; j++)
                {
                    if (ctx.Spojovaci[j].ID_Studenta == e.ID_Studenta && ctx.Spojovaci[j].ZkratkaPredmetu == e.ZkratkaPredmetu)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists == false)
                {
                    ctx.Spojovaci.Add(e);
                }
            }
            */
            ctx.SaveChanges();


            var grades = new[]
            {
                new Hodnoceni{ ID_Studenta=1, ZkratkaPredmetu="ALD", DatumHodnoceni=DateTime.Parse("2000-06-06"), _Hodnoceni=1 },
                new Hodnoceni{ ID_Studenta=2, ZkratkaPredmetu="ALD", DatumHodnoceni=DateTime.Parse("2000-06-06"), _Hodnoceni=8 },
                new Hodnoceni{ ID_Studenta=2, ZkratkaPredmetu="SAS", DatumHodnoceni=DateTime.Parse("2023-07-09"), _Hodnoceni=5 },
                new Hodnoceni{ ID_Studenta=3, ZkratkaPredmetu="ALD", DatumHodnoceni=DateTime.Parse("2000-06-06"), _Hodnoceni=3 },
                new Hodnoceni{ ID_Studenta=4, ZkratkaPredmetu="RR2", DatumHodnoceni=DateTime.Parse("2005-09-08"), _Hodnoceni=3 },
                new Hodnoceni{ ID_Studenta=5, ZkratkaPredmetu="MOD", DatumHodnoceni=DateTime.Parse("2003-03-03"), _Hodnoceni=5 },
                new Hodnoceni{ ID_Studenta=6, ZkratkaPredmetu="RR1", DatumHodnoceni=DateTime.Parse("2004-06-03"), _Hodnoceni=2 },
            };

            for (int i = 0; i < grades.Length; i++)
            {
                var h = grades[i];

                bool exists = ctx.Hodnoceni.Any(x =>
                    x.ID_Studenta == h.ID_Studenta &&
                    x.ZkratkaPredmetu == h.ZkratkaPredmetu &&
                    x.DatumHodnoceni == h.DatumHodnoceni);

                if (!exists)
                {
                    ctx.Hodnoceni.Add(h);
                }
            }
            /*
            for (int i = 0; i < grades.Length; i++)
            {
                var h = grades[i];
                bool exists = false;
                for (int j = 0; j < ctx.Hodnoceni.Count; j++)
                {
                    if (ctx.Hodnoceni[j].ID_Studenta == h.ID_Studenta &&
                        ctx.Hodnoceni[j].ZkratkaPredmetu == h.ZkratkaPredmetu &&
                        ctx.Hodnoceni[j].DatumHodnoceni == h.DatumHodnoceni)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists == false)
                {
                    ctx.Hodnoceni.Add(h);
                }
            }
            */
            ctx.SaveChanges();
        }
    }
}
