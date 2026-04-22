using System;
using System.Collections.Generic;

namespace cv_11_vyuka.EFCore
{
    public class Studenti
    {
        // getters and setters 
        public int ID { get; set; }
        public string Jmeno { get; set; } = null!;
        public string Prijmeni { get; set; } = null!;
        public DateTime DatumNarozeni { get; set; }
    }
}