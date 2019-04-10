using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WeatherStationAlert.Models;

namespace WeatherStationAlert.Controllers
{
    public class WeatherStationsController : ApiController
    {
        private WeatherStationAlertContext db = new WeatherStationAlertContext();

        // POST: api/WeatherStations
        [ResponseType(typeof(WeatherStations))]
        public IHttpActionResult PostWeatherStations(WeatherStations weatherStations)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            weatherStations.Inclusao = DateTime.Now;
            db.WeatherStations.Add(weatherStations);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = weatherStations.ID }, weatherStations);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}