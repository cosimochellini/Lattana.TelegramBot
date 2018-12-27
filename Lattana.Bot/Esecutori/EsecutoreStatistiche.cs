using System;
using System.Collections.Generic;
using System.Linq;
using Lattana.Bot.Istance;
using Lattana.Bot.Models;
using Telegram.Bot.Types;

namespace Lattana.Bot.Esecutori
{
    public static class EsecutoreStatistiche
    {
        public static void ComandoStatistiche(Message messaggio, string[] comando)
        {
            if (comando.Length < 2)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "indicare che tipo di statistica, esempio : statistica audio, immagini, testo");
                return;
            }

            switch (comando[1])
            {
                case "audio":
                case "audi":
                case "vocali":
                    StatisticheAudio(messaggio);
                    break;

                case "foto":
                case "immagini":
                case "photo":
                    StatisticheFoto(messaggio);
                    break;

                case "messaggi":
                case "testo":
                case "testi":
                    StatisticheMessaggi(messaggio);
                    break;
            }
        }

        private static void StatisticheAudio(Message messaggio)
        {
            var arrangedAudio = StatManager.Items.OrderByDescending(x => x.ContAudio).ToList();
            var statisticaTxt = arrangedAudio.Aggregate("Ordine utenti per numero audio inviati \r \n  \r \n", (current, utente) => current + $"- {utente.Nome} {utente.Cognome} | n° audio: {utente.ContAudio} \r \n");
            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, statisticaTxt);
        }

        private static void StatisticheMessaggi(Message messaggio)
        {
            var arrangedAudio = StatManager.Items.OrderByDescending(x => x.ContText).ToList();
            var statisticaTxt = arrangedAudio.Aggregate("Ordine utenti per numero messaggi inviati \r \n  \r \n", (current, utente) => current + $"-  {utente.Nome} {utente.Cognome} : {utente.ContText} \r \n");
            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, statisticaTxt);
        }

        private static void StatisticheFoto(Message messaggio)
        {
            var arrangedAudio = StatManager.Items.OrderByDescending(x => x.ContImg).ToList();
            var statisticaTxt = arrangedAudio.Aggregate("Ordine utenti per numero foto inviate \r \n  \r \n", (current, utente) => current + $"- {utente.Nome} {utente.Cognome} | n° foto: {utente.ContImg} \r \n");
            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, statisticaTxt);
        }

        internal static void ComandoAnalizza(string[] comando, Message messaggio)
        {

            if (comando.Length == 1)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, devi inserire il nome di qualcuno da analizzare");
                return;
            }

            if (comando.Length > 3)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, hai inserito troppi termini nel comando");
                return;
            }

            if (comando.Length == 2)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, hai non hai inseriro abbastanza termini nel comando");
            }

            if (comando.Length == 3)
            {
                switch (comando[1])
                {
                    case "nome":
                        AnalizzaPerNome(messaggio, comando);
                        return;

                    case "username":
                        AnalizzaPerUsername(messaggio, comando);
                        return;
                    default:
                        Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la sintassi corretta è analizza nome/username [nome/username]");
                        return;

                }

            }
        }

        private static void SendReportUser(UserStat utente, Message messaggio)
        {
            var messaggiTotali = utente.ContAudio + utente.ContText + utente.ContImg + utente.ContSticker;
            var percentualeMessaggi = (float)utente.ContText / messaggiTotali;
            var percentualeAudio = (float)utente.ContAudio / messaggiTotali;
            var percentualeImmagini = (float)utente.ContImg / messaggiTotali;
            var percentualeSticker = (float)utente.ContSticker / messaggiTotali;
            Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, "Analisi utente \r \n \r \n" +
                                                                    $" Nome : {utente.Nome} \r \n" +
                                                                    $" Cognome : {utente.Cognome} \r \n" +
                                                                    $" Id : {utente.Id} \r \n" +
                                                                    $" Messaggi inviati : {utente.ContText}  ({percentualeMessaggi * 100}%) \r \n" +
                                                                    $" Foto inviate : {utente.ContImg}  ({percentualeImmagini * 100}%) \r \n" +
                                                                    $" Audio inviati: {utente.ContAudio } ({ percentualeAudio * 100}%) \r \n" +
                                                                    $" Stickers inviati: {utente.ContSticker} ({ percentualeSticker * 100}%) \r \n");


        }

        private static void AnalizzaPerNome(Message messaggio, IReadOnlyList<string> comando)
        {
            try
            {
                var utente = StatManager.Items.Single(x => x.Nome.Equals(comando[2]));
                SendReportUser(utente, messaggio);

            }
            catch (Exception)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id,
                    $"Mi dispiace {messaggio.From.FirstName}, la ricerca di {comando[1]} ha risultato 0 o più di un risultato, {StatManager.Items.Count(x => x.Nome.Equals(comando[2]))} risultati trovati");
            }

        }

        private static void AnalizzaPerUsername(Message messaggio, IReadOnlyList<string> comando)
        {
            try
            {
                var utente = StatManager.Items.Single(x => x.Nome.Equals(comando[1]));
                SendReportUser(utente, messaggio);
            }
            catch (Exception)
            {
                Istance.Bot.Istance.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la ricerca di {comando[1]} ha risultato 0 o più di un risultato");
            }
        }
    }
}
