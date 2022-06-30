//morra cinese

//2 parteciapanti
// cpu e utente

//l'utente e i computer devono scegliere tra sasso carta e forbice
//una volta che l'utente scelgie bisogna decidicedere il vincitore/punteggio
//          sasso   carta   forbice
// sasso     p        vc       vs
// carta     -        p        vf
// forbice   -        -         p
//
//

//al meglio di N partite che stabilisce l'utente
//tenere il punteggio intermedio
//stampare alla fine il vincitore

//aggiungere alla fine di tutte le partie una stampa di tutte le mosse fatte dai giocatori.

//
// Giocatore / Partecipante --> punteggio | vincitore | mossa
// Mossa / Mano ??
// Partita --> punteggio | vincitore | resoconto finale
// Esito(?) = sè vincente una mossa ?? --> regola
// RegoleGioco ??
// MorraCinese / Gioco --> resconto finale
//



using morra_cinese;

bool adOggetti = true;
//new MorraCinese().Gioca();

if (adOggetti)
{
    MorraCinese gioco = new MorraCinese();

    gioco.Gioca();
    gioco.StampaResoconto();
}
else
{
  
    string[] simboliMorra = { "sasso", "carta", "forbice" };
    int punteggioUtente = 0;
    int punteggioCpu = 0;
    int numeroPartite;

    string[] mosseUtente;
    string[] mosseCpu;

    string resocontoFinale = "";

    Console.WriteLine("************************");
    Console.WriteLine("Gioco della morra cinese");
    Console.WriteLine("************************");

    Console.WriteLine();

    Console.Write("Quanti match vuoi fare?: ");
    numeroPartite = int.Parse(Console.ReadLine());

    mosseUtente = new string[numeroPartite];
    mosseCpu = new string[numeroPartite];

    for (int partita = 0; partita < numeroPartite; partita++)
    {

        resocontoFinale += partita + "\t";

        Console.WriteLine("Partita {0} di {1}", partita + 1, numeroPartite);
        Console.Write("tu scegli?: ", partita);

        string mossaUtente = Console.ReadLine();
        mosseUtente[partita] = mossaUtente;

        int mossaCPU = new Random().Next(0, simboliMorra.Length);
        string sceltaCPU = simboliMorra[mossaCPU];
        mosseCpu[partita] = sceltaCPU;

        resocontoFinale += mossaUtente + "\t" + sceltaCPU;

        //la logica è semplificata dal fatto che si guarda solo alla scelta dell'utente
        //essendo 2 giocatori se uno vince l'altro perde (solo 2 casi) quindi possiamo semplificare le logiche
        bool pareggio = sceltaCPU == mossaUtente;
        bool vinceForbice = mossaUtente == "forbice" && sceltaCPU == "carta";
        bool vinceCarta = mossaUtente == "carta" && sceltaCPU == "sasso";
        bool vinceSasso = mossaUtente == "sasso" && sceltaCPU == "forbice";

        Console.WriteLine("CPU sceglie {0} ", sceltaCPU);

        if (pareggio)
        {
            Console.WriteLine("Parità, nessun punteggio assegnato!");

        }
        else
        {

            if (vinceForbice || vinceCarta || vinceSasso)
            {
                Console.WriteLine("+1 punto per te");
                punteggioUtente++;
            }
            else
            {
                Console.WriteLine("+1 punto per cpu");
                punteggioCpu++;
            }
        }

        Console.WriteLine();
        resocontoFinale += "\n";
    }

    if (punteggioUtente == punteggioCpu)
    {
        Console.WriteLine("Nessun vincitore!");
    }
    else
    {
        if (punteggioUtente > punteggioCpu)
        {
            Console.WriteLine("Hai vinto! {0} a {1}", punteggioUtente, punteggioCpu);
        }
        else
        {
            Console.WriteLine("Hai Perso! {0} a {1}", punteggioUtente, punteggioCpu);
        }
    }

    Console.WriteLine("Resoconto partite (array):");
    Console.WriteLine();
    Console.WriteLine("Partita\tTu\tCPU");


    for (int i = 0; i < numeroPartite; i++)
    {
        Console.WriteLine("{0}\t{1}\t{2}", i, mosseUtente[i], mosseCpu[i]);
    }

    Console.WriteLine("Resoconto partite (String):");
    Console.WriteLine();
    Console.WriteLine("Partita\tTu\tCPU\n" + resocontoFinale);
}
