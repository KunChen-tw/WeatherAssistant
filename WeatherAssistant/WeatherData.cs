namespace WeatherAssistant
{
    public class WeatherData
    {
        public string RawData { get; }
        public int LocationCode { get; set; }
        public string DateTimeString { get; set; }
        public DateTime DateTime { get; set; }
        public double WindSpeed { get; set; }
        public double Pressure { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Sunlight { get; set; }
        public double Power { get; set; }

        public string Serial => $"{DateTime:yyyyMMddHHmm}{LocationCode:D2}";

        public WeatherData(string csvLine)
        {
            RawData = csvLine;
            var values = csvLine.Split(',');
            LocationCode = int.Parse(values[0]);
            DateTime = DateTime.Parse(values[1]);
            DateTimeString = values[1];
            WindSpeed = double.Parse(values[2]);
            Pressure = double.Parse(values[3]);
            Temperature = double.Parse(values[4]);
            Humidity = double.Parse(values[5]);
            Sunlight = double.Parse(values[6]);
            Power = double.Parse(values[7]);
        }
        public int GetMonth()
        {
            return DateTime.Month;
        }
        public int GetDay()
        {
            return DateTime.Day;
        }
        public int GetHour()
        {
            return DateTime.Hour;
        }
        public int GetMinute()
        {
            return DateTime.Minute;
        }

        public void SetMinute(int minute)
        {
            DateTime = new DateTime(DateTime.Year, DateTime.Month, DateTime.Day, DateTime.Hour, minute, DateTime.Second);
        }
    }
}