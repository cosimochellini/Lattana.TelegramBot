using System;
using System.Collections.Generic;
using System.Linq;
using Telegram.Bot.Examples.Echo.Manager;
using Telegram.Bot.Examples.Echo.Models;
using Telegram.Bot.Types;

namespace Telegram.Bot.Examples.Echo.Esecutori
{
    public static class EsecutoreStatistiche
    {
        public static void ComandoStatistiche(Message messaggio, string[] comando, TelegramBotClient bot, StatManager statManager)
        {
            switch (comando[1])
            {
                case "audio":
                case "audi":
                case "vocali":
                    StatisticheAudio(statManager, bot, messaggio);
                    break;

                case "foto":
                case "immagini":
                case "photo":
                    StatisticheFoto(statManager, bot, messaggio);
                    break;

                case "messaggi":
                case "testo":
                case "testi":
                    StatisticheMessaggi(statManager, bot, messaggio);
                    break;
            }
        }

        private static void StatisticheAudio(StatManager statManager, ITelegramBotClient bot, Message messaggio)
        {
            var arrangedAudio = statManager.GetListaUser().OrderByDescending(x => x.ContAudio).ToList();
            var statisticaTxt = arrangedAudio.Aggregate("Ordine utenti per numero audio inviati \r \n  \r \n", (current, utente) => current + $"- {utente.Nome} {utente.Cognome} | n° audio: {utente.ContAudio} \r \n");
            bot.SendTextMessageAsync(messaggio.Chat.Id, statisticaTxt);
        }

        private static void StatisticheMessaggi(StatManager statManager, ITelegramBotClient bot, Message messaggio)
        {
            var arrangedAudio = statManager.GetListaUser().OrderByDescending(x => x.ContText).ToList();
            var statisticaTxt = arrangedAudio.Aggregate("Ordine utenti per numero messaggi inviati \r \n  \r \n", (current, utente) => current + $"-  {utente.Nome} {utente.Cognome} : {utente.ContText} \r \n");
            bot.SendTextMessageAsync(messaggio.Chat.Id, statisticaTxt);
        }

        private static void StatisticheFoto(StatManager statManager, ITelegramBotClient bot, Message messaggio)
        {
            var arrangedAudio = statManager.GetListaUser().OrderByDescending(x => x.ContImg).ToList();
            var statisticaTxt = arrangedAudio.Aggregate("Ordine utenti per numero foto inviate \r \n  \r \n", (current, utente) => current + $"- {utente.Nome} {utente.Cognome} | n° foto: {utente.ContImg} \r \n");
            bot.SendTextMessageAsync(messaggio.Chat.Id, statisticaTxt);
        }

        internal static void ComandoAnalizza(string[] comando, Message messaggio, TelegramBotClient bot, StatManager statManager)
        {

            if (comando.Length == 1)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, devi inserire il nome di qualcuno da analizzare");
                return;
            }

            if (comando.Length > 3)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, hai inserito troppi termini nel comando");
                return;
            }

            if (comando.Length == 2)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, hai non hai inseriro abbastanza termini nel comando");
            }

            if (comando.Length == 3)
            {
                switch (comando[1])
                {
                    case "nome":
                        AnalizzaPerNome(statManager, messaggio, bot, comando);
                        return;

                    case "username":
                        AnalizzaPerUsername(statManager, messaggio, bot, comando);
                        return;
                    default:
                        bot.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la sintassi corretta è analizza nome/username [nome/username]");
                        return;

                }

            }
        }

        private static void SendReportUser(UserStat utente, ITelegramBotClient bot, Message messaggio)
        {
            var messaggiTotali = utente.ContAudio + utente.ContText + utente.ContImg + utente.ContSticker;
            var percentualeMessaggi = (float)utente.ContText / messaggiTotali;
            var percentualeAudio = (float)utente.ContAudio / messaggiTotali;
            var percentualeImmagini = (float)utente.ContImg / messaggiTotali;
            var percentualeSticker = (float)utente.ContSticker / messaggiTotali;
            bot.SendTextMessageAsync(messaggio.Chat.Id, "Analisi utente \r \n \r \n" +
                                                                    $" Nome : {utente.Nome} \r \n" +
                                                                    $" Cognome : {utente.Cognome} \r \n" +
                                                                    $" Id : {utente.Id} \r \n" +
                                                                    $" Messaggi inviati : {utente.ContText}  ({percentualeMessaggi * 100}%) \r \n" +
                                                                    $" Foto inviate : {utente.ContImg}  ({percentualeImmagini * 100}%) \r \n" +
                                                                    $" Audio inviati: {utente.ContAudio } ({ percentualeAudio * 100}%) \r \n" +
                                                                    $" Stickers inviati: {utente.ContSticker} ({ percentualeSticker * 100}%) \r \n");


        }

        private static void AnalizzaPerNome(StatManager statManager, Message messaggio, ITelegramBotClient bot, IReadOnlyList<string> comando)
        {
            var listaUtenti = statManager.GetListaUser();
            UserStat utente;

            var userStats = listaUtenti as UserStat[] ?? listaUtenti.ToArray();
            try
            { 
                utente = userStats.Single(x => x.Nome.Equals(comando[2]));
            }
            catch (Exception)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la ricerca di {comando[1]} ha risultato 0 o più di un risultato, {userStats.Count(x => x.Nome.Equals(comando[2]))} risultati trovati");
                return;
            }

            SendReportUser(utente, bot, messaggio);

        }

        private static void AnalizzaPerUsername(StatManager statManager, Message messaggio, ITelegramBotClient bot, IReadOnlyList<string> comando)
        {

            var listaUtenti = statManager.GetListaUser();
            UserStat utente;

            try
            {
                utente = listaUtenti.Single(x => x.Nome.Equals(comando[1]));
            }
            catch (Exception)
            {
                bot.SendTextMessageAsync(messaggio.Chat.Id, $"Mi dispiace {messaggio.From.FirstName}, la ricerca di {comando[1]} ha risultato 0 o più di un risultato");
                return;
            }

            SendReportUser(utente, bot, messaggio);

        }

    }
}
