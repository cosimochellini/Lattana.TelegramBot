namespace TelegramBotDemo.Generatori
{
    public class GeneratorePano
    {
        public string CreaPano(int casuale)
        {
            var offesa = new string[11];
            offesa[0] = "Macché pano, Giulio è già pieno!";
            offesa[1] = "Va bene, ma non nascondete le postate, altrimenti lattana rimane senza!";
            offesa[2] = "Va bene, ma non nascondete le postate, altrimenti Giulio lo dice a sua mamma!";
            offesa[3] = "Va bene, ma non nascondete le postate, altrimenti Giulio impazzisce!";
            offesa[4] = "Per me mezzo pano depotenziato. Giano se passi dal kebo prendimi una porzione di patatine a parte. ";
            offesa[5] = "Lattana senza panuozzo è come un uccello senz'ali";
            offesa[6] = "Corri, disse il destino.    Non riflettere, disse l'istinto. \n \r    Rischia, disse la passione. \n \r   Panuozzo, disse Lattana";
            offesa[7] = "Per lattana una marghe.";
            offesa[8] = "Per me una margherita";
            offesa[9] = "A buonnattana non manca u' panuozzo";
            offesa[10] = "Il panuozzo batte dove il dente duole";
           
            return offesa[casuale];
        }
    }
}
