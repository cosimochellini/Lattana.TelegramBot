using System.Web.Http;

using System;

//using WeatherApp.DataAccessLayer;

namespace Api.ApiExample
{
    public class ValuesController : ApiController
    {
        //[HttpGet]
        //[ResponseType(typeof(JsonArrayAttribute))]
        ////[Route("api/dammituttiivalori")]

        [HttpGet]
        [Route("api/weather")]
        //[ResponseType(typeof(WheaterForecast))]
        public IHttpActionResult GeWeather()
        {
            //var geoInfo = MapsController.GetGeoInfo(city);
            //var lat = geoInfo.Data.results[0].geometry.location.lat;
            //var lng = geoInfo.Data.results[0].geometry.location.lng;

            try
            {
                //return Ok(DarkSkyManager.GetWheaterForecast(lat, lng));
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        //[HttpGet]
        //[Route("api/weather")]
        //[ResponseType(typeof(WheaterForecast))]
        //public IHttpActionResult GeWeather([FromUri]string city, string date)
        //{
        //    var geoInfo = MapsController.GetGeoInfo(city);
        //    var lat = geoInfo.Data.results[0].geometry.location.lat;
        //    var lng = geoInfo.Data.results[0].geometry.location.lng;

        //    try
        //    {
        //        return Ok(DarkSkyManager.GetWheaterForecast(lat, lng, date));
        //    }
        //    catch (Exception ex)
        //    {
        //        return InternalServerError(ex);
        //    }
        //}

    }
}
