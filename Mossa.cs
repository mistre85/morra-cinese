using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morra_cinese
{
    public class Mossa
    {
        string[] listaMosse = new string[] { "sasso", "carta", "forbice" };

        string valore;

        private Giocatore giocatore;


        public Mossa(string mossaCorrente, Giocatore giocatore)
        {
            this.Valore = mossaCorrente;
            this.giocatore = giocatore; ;
        }

        public Mossa(Giocatore giocatore)
        {
            if (giocatore.Cpu){
                int mossaCasuale = new Random().Next(0, this.listaMosse.Length);
                this.Valore = this.listaMosse[mossaCasuale];
            }
            else
            {
                Console.Write("sasso, carta, forbice? ");
                this.Valore = Console.ReadLine();
            }

            this.giocatore = giocatore;
        }


        public Giocatore getGiocatore()
        {
            return this.giocatore;
        }


        public string Valore
        {
            get
            {
                return this.valore;
            }
            set
            {
                this.Valida = this.listaMosse.Contains(value);
                this.valore = value;
            }
        }

        bool Valida { get; set; }
    }
}
