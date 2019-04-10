using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherStationAlert.Models;

namespace WeatherStationAlert.Controllers
{
    public class HomeController : Controller
    {
        private WeatherStationAlertContext db = new WeatherStationAlertContext();

        public ActionResult Index()
        {
            ViewBag.Dia = DateTime.Now.ToString("dddd, dd MMMM yyyy");
            ViewBag.Temperatura = db.WeatherStations.OrderByDescending(x => x.ID).FirstOrDefault().Temperatura;
            ViewBag.Umidade = db.WeatherStations.OrderByDescending(x => x.ID).FirstOrDefault().Umidade;
            ViewBag.Pluviosidade = db.WeatherStations.OrderByDescending(x => x.ID).FirstOrDefault().Pluviosidade;
            ViewBag.Leituras = db.WeatherStations.Count();
            ViewBag.Data = db.WeatherStations.OrderByDescending(x => x.ID).FirstOrDefault().Inclusao.AddHours(4);
            return View(); 
        }
    }
}