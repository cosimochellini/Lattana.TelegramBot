using System;
using Telegram.Bot.Types;

namespace Lattana.Bot.Generatore
{
    public static class GeneratoreProfeta
    {
        private static string CreaProfezia(int casuale)
        {
            var offesa = new string[25];
            offesa[0] = "Lattana... non chiamarla come famiglia o casa, se non hai intenzione di comportarti come figlio e come servo";
            offesa[1] = "Chi lascia Lattana vecchia per Lattana nuova sa cosa lascia ma non sa cosa trova";
            offesa[2] = "Il giovane cammina più veloce dell'anziano, ma Lattana conoscie Lattana";
            offesa[3] = "Lattana di sera, bel tempo si spera";
            offesa[4] = "Ciò che l'occhio ha visto, Lattana non dimentica";
            offesa[5] = "Lattana senza panuozzo è come un uccello senz'ali";
            offesa[6] = "Corri, disse il destino.    Non riflettere, disse l'istinto.     Rischia, disse la passione.    Panuozzo, disse Lattana";
            offesa[7] = "Le donne vanno e vengono, Lattana rimanre";
            offesa[8] = "Sia lode a Lattana, e sempre sia lodata";
            offesa[9] = "Tanto va lattana al lardo che ci lascia il rocchino";
            offesa[10] = "Quando vai a Lattana, piangi due volta, quando arrivi e quando parti";
            offesa[11] = "Poherinoooooooo?";
            offesa[12] = "A buonnattana non manca u' panuozzo";
            offesa[13] = "A buonnattana pochi rocchini";
            offesa[14] = "Ne Lattana, ogni scherzo (a rocchino), ogni scherzo vale";
            offesa[15] = "A Lattana non si comanda";
            offesa[16] = "Chi vuol esser lieto sia, de Lattana c'è certezza";
            offesa[17] = "A natale con i tuoi, a pasqua a Lattana";
            offesa[18] = "Lattana non sa sciupare sa solo migliorare";
            offesa[19] = "Di donne ce n'è tante al mondo ma di ttana ce n'è una sola lei li prende tutti belli e brutti";
            offesa[20] = "San giovanni non si chiama arturo";
            offesa[21] = "Il panuozzo batte dove il dente duole";
            offesa[22] = "Lattana è ovunque e in ogniccosa";
            offesa[23] = " snt'arturo non si chiama giovanni";
            offesa[24] = "dura lex cecche lex";


            return offesa[casuale];
        }

        public static void ComandoProfeta(Message messaggio, int contatoreProfezia, int sceltaNonCasuale = 0)
        {
            int numero;
            if (sceltaNonCasuale == 0)
            {
                var casuale = new Random();
                numero = casuale.Next(0, contatoreProfezia);
            }
            else
            {
                numero = sceltaNonCasuale;
            }

            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, CreaProfezia(numero - 1));

        }
    }
}
