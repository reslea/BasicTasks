using System;

namespace UnderstandingHttp
{
    public class Forecast
    {
        public DateTime Date { get; set; }

        public decimal TemperatureC { get; set; }
        
        public decimal TemperatureF { get; set; }

        public string Summary { get; set; }
    }
}