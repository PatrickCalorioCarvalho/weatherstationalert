using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WeatherStationAlert.Models
{
    public class WeatherStations
    {
        [Key]
        public int ID { get; set; }

        public int Setor { get; set; }

        public float Pluviosidade { get; set; }

        public float Temperatura { get; set; }

        public float Umidade  { get; set; }

        public DateTime Inclusao { get; set; }
    }
}