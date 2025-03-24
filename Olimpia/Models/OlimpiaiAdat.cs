using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olimpia.Models
{
    public class OlimpiaiAdat
    {
        public int Ev { get; set; }
        public string Sportag {  get; set; } = String.Empty;
        public string? Nemzet {  get; set; }
        public string Versenyzo {  get; set; }
        public string Nem {  get; set; }

        public OlimpiaiAdat() //üres konstruktor kell az adatbázis miatt
        {
        }

        public OlimpiaiAdat(string sor)
        {
            var tomb = sor.Split(";");
            Ev = Convert.ToInt32(tomb[0]);
            Sportag = tomb[1];
            Nemzet = tomb[2];
            Versenyzo = tomb[3];
            Nem = tomb[4];
        }

        public override string? ToString()
        {
            return $"{Ev} - {Versenyzo}, {Sportag}";
        }
    }
}
