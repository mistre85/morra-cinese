using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morra_cinese
{
    public class Giocatore
    {
        public int Punteggio { get; set; }

        public bool Cpu { get; internal set; }

        public Giocatore(bool cpu)
        {
            this.Cpu = cpu;
        }

        public Mossa faiMossa()
        {
            Mossa mossa = new Mossa(this);

            if (Cpu)
            {
                Console.WriteLine("CPU sceglie {0} ", mossa.Valore);
            }
       

            return mossa;
        }
    }
}
