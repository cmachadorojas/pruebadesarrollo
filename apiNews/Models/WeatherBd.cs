using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiNews.Models
{
    public class WeatherBd
    {
        [Key]
        public int id { get; set; }

        public DateTime observation_time { get; set; }

        public int temperature { get; set; }

        public string weather_descriptions { get; set; }

        public int wind_speed { get; set; }

        public int wind_degree { get; set; }

        public string wind_dir { get; set; }

        public int pressure { get; set; }

        public int precip { get; set; }

        public int humidity { get; set; }

        public int cloudcover { get; set; }

        public int feelslike { get; set; }

        public int uv_index { get; set; }

        public int visibility { get; set; }

        public string city { get; set; }


    }
}
