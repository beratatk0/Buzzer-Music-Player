using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mikroislemciler
{
    public class Note
    {
        public int Freq { get; set; }       // frekansı
        public int Duration {  get; set; }    //Çalma süresi
        public int Time { get; set; }       // Zaman damgası 
        public int Position { get; set; }  // Pozisyon 
        public int Order { get; set; } // Sıra 
    }
}
