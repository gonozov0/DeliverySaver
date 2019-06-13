using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class ProductViewData
    {
        public ProductViewData(ProductModel productModel, List<IndicationModel> indications)
        {
            Name = productModel.Name;
            var temperutureVars = indications.Select(indication => indication.Temperature);
            var humidityVars = indications.Select(indication => indication.Humidity);
            if (temperutureVars.Count() > 0)
                AverangeTemperature = temperutureVars.Average();
            if (humidityVars.Count() > 0)
                AverangeHumidity = humidityVars.Average();
            if (AverangeHumidity <= productModel.UpperHumidityLevel && AverangeHumidity >= productModel.LowerHumidityLevel &&
                AverangeTemperature <= productModel.UpperTemperatureLevel && AverangeTemperature >= productModel.LowerTemperatureLevel)
                IsNorm = true;
            else
                IsNorm = false;
            TemperatureBounds = productModel.LowerTemperatureLevel + "-" + productModel.UpperTemperatureLevel;
            HumidityBounds = productModel.LowerHumidityLevel + "-" + productModel.UpperHumidityLevel;
        }

        public string Name { get; set; }
        public string TemperatureBounds { get; set; }
        public string HumidityBounds { get; set; }
        public double AverangeTemperature { get; set; }
        public double AverangeHumidity { get; set; }
        public bool IsNorm { get; set; }
    }
}
