using System.Configuration;
using RestSharp;

namespace TelegramBotDemo.Manager
{
    public static class IftttManager
    {
        private const string BaseUrl = "https://maker.ifttt.com/trigger/";

        private static readonly string IftttKey = ConfigurationManager.AppSettings["webHoockKey"];

        private const string IftttApplet = "LattanaException";

        public static void SendException(string exception)
        {
            var webReequest = new RestClient(BaseUrl + IftttApplet + "/with/key/" + IftttKey);
            var webHooksParameters = new RestRequest(Method.GET);
            webHooksParameters.AddQueryParameter("value1", exception);

            webReequest.Execute<ResponseStatus>(webHooksParameters);
        }
    }
}