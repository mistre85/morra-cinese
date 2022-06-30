using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace morra_cinese
{
    public class MorraCinese
    {
        Giocatore utente;
        Giocatore cpu;

        Giocata[] giocate;

        int numeroPartite;

        public MorraCinese()
        {
            utente = new Giocatore(false);
            cpu = new Giocatore(true);
        }

        public void Gioca()
        {
            Console.WriteLine("************************");
            Console.WriteLine("Gioco della morra cinese");
            Console.WriteLine("************************");

            Console.WriteLine();

            Console.Write("Quanti match vuoi fare?: ");
            this.numeroPartite = int.Parse(Console.ReadLine());

            giocate = new Giocata[this.numeroPartite];

            for(int p = 0; p < this.numeroPartite; p++)
            {
                Console.WriteLine();
                Console.WriteLine("Partita {0} di {1}", p + 1, numeroPartite);

                Mossa mossaUtente = utente.faiMossa();
                Mossa mossaCpu = cpu.faiMossa();

                Giocata giocata = new Giocata(mossaUtente, mossaCpu, p + 1);

                Giocatore vincitore = giocata.getVincitore();
                
                giocata.AssegnaPunto(vincitore);

                giocate[p] = giocata;

            }

        }

        public void StampaResoconto()
        {
            Console.WriteLine();
            Console.WriteLine("*** Resoconto giocate ***");
            Console.WriteLine("Partita\tTu\tCPU\tUpoint\tCpuPoint");

            for (int i = 0; i< giocate.Length; i++)
            {
                giocate[i].Stampa();
            }
        }
    }
}
