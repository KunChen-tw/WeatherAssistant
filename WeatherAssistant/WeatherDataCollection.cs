using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace WeatherAssistant
{
    internal class WeatherDataCollection : Collection<WeatherData>
    {
        public string GetAverageWindSpeed()
        {
            if (Count == 0) return "0.00";

            double average = this.Average(data => data.WindSpeed);
            return Math.Round(average, 2).ToString();
        }

        public string GetAveragePressure()
        {
            if (Count == 0) return "0.00";

            double average = this.Average(data => data.Pressure);
            return Math.Round(average, 2).ToString();
        }

        public string GetAverageTemperature()
        {
            if (Count == 0) return "0.00";

            double average = this.Average(data => data.Temperature);
            return Math.Round(average, 2).ToString();
        }

        public string GetAverageHumidity()
        {
            if (Count == 0) return "0.00";

            double average = this.Average(data => data.Humidity);
            return Math.Round(average, 2).ToString();
        }

        public string GetAverageSunlight()
        {
            if (Count == 0) return "0.00";

            double average = this.Average(data => data.Sunlight);
            return Math.Round(average, 2).ToString();
        }

        public string GetAveragePower()
        {
            if (Count == 0) return "0.00";

            double average = this.Average(data => data.Power);
            return Math.Round(average, 2).ToString();
        }

        public string GetAverageCSV() {
            if (Count == 0) return null;

            WeatherData newData = new WeatherData(this[0].RawData);
            int minute = newData.GetMinute();
            newData.SetMinute(minute / 10 * 10); // 將分鐘值取十進位，個位數設成0

            return $"{newData.Serial},{GetAverageWindSpeed()},{GetAveragePressure()},{GetAverageTemperature()},{GetAverageHumidity()},{GetAverageSunlight()},{GetAveragePower()}";
        }
    }
}
