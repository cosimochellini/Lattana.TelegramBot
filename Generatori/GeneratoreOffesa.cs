namespace TelegramBotDemo.Generatori
{
    public static class GeneratoreOffesa
    {
        public static string CreaOffesa(string nomeDaOffendere,int casuale)
        {
            var offesa = new string[20];
            offesa[0] = nomeDaOffendere + " sei talmente stupido che assomigli a federico";
            offesa[1] = nomeDaOffendere + " sei talmente ebreo che non so come ettore non ti abbia ancora bruciato vivo";
            offesa[2] = nomeDaOffendere + " sei come la minchia: sempre tra le palle";
            offesa[3] = nomeDaOffendere + " sei cosi scemo che guardi pure peppa pig"; 
            offesa[4] = nomeDaOffendere + " abbraccia la tazza del cesso e cantagli: non son degno di te"; 
            offesa[5] = $"Dio sparse l'intelligenza attraverso la pioggia...peccato che quel giorno {nomeDaOffendere} aveva l'ombrello!!";
            offesa[6] = nomeDaOffendere + " ha un cervello così piccolo che quando due pensieri si incontrano devono fare manovra";
            offesa[7] = nomeDaOffendere +  $" {nomeDaOffendere},  {nomeDaOffendere}, {nomeDaOffendere} .... che nome dimmerda fattelo dire";
            offesa[8] = " Sapete perchè pestano spesso " + nomeDaOffendere + " (e rocchino), perchè porta fortuna";
            offesa[9] = nomeDaOffendere + " sei come il sole, inguardabile";
            offesa[10] = nomeDaOffendere + " sei come ruocchino, il denutrito dei denutriti";
            offesa[11] = nomeDaOffendere + " sei come ruocchino, ebreo";
            offesa[12] = nomeDaOffendere + " sei come ruocchino, ruocchino";
            offesa[13] = nomeDaOffendere + " sei come ruocchino, tocchino";
            offesa[14] = nomeDaOffendere + " sei come ruocchino, stupido";
            offesa[15] = nomeDaOffendere + " sei come ruocchino, deun";
            offesa[16] = nomeDaOffendere + " sei come ruocchino, denutrito";
            offesa[17] = nomeDaOffendere + " sei come ruocchino, boh ruocchino in generale";
            return offesa[casuale];
        }

    }
}
