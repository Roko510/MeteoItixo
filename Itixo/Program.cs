using System.Xml.Linq;
using Microsoft.Extensions.Configuration;
using System.Globalization;
using System.Xml.Serialization;


class Program
{
    static Timer? timerWeather;
    static Timer? timerDay;
    static async Task Main()
    {        
        timerWeather = new Timer(async _ =>
        {
            await WeatherSave();
        }, null, TimeSpan.Zero, TimeSpan.FromHours(1));

        timerDay = new Timer(async _ =>
        {
            await DaySave();
        }, null, TimeSpan.Zero, TimeSpan.FromDays(1));

        Console.ReadLine();
    }
    static async Task DaySave()
    {
        Console.WriteLine("Saving Day Data: " + DateTime.Now);
        var config = new ConfigurationBuilder()
     .AddJsonFile("config.json")
     .Build();
        string url = config["MeteoSettings:DataUrl"];

        var inputDayData = await DownloadDayData(url);
        await SaveDayToDatabase(inputDayData);
    }

    static async Task WeatherSave()
    {
        Console.WriteLine("Saving: " + DateTime.Now);

        var config = new ConfigurationBuilder()
            .AddJsonFile("config.json")
            .Build();

        string url = config["MeteoSettings:DataUrl"];

        var inputData = await DownloadMeteoData(url);
        await SaveToDatabase(inputData.Sensors);
    }
    public static async Task<InputSensors?> DownloadMeteoData(string url)
    {
        try
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
               
            var xmlString = await response.Content.ReadAsStringAsync();

            var doc = XDocument.Parse(xmlString);

            var inputElement = doc.Root.Element("input");
            if (inputElement == null)
            {
                return null;
            }
                
            var serializer = new XmlSerializer(typeof(InputSensors));
            using var reader = inputElement.CreateReader();
            var inputSensors = serializer.Deserialize(reader) as InputSensors;
            return inputSensors;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
    public static async Task SaveToDatabase(List<RawData> sensors, bool isOnline = false, string? errorMessage = null)
    {
        using var context = new WeatherContext();
        context.Database.EnsureCreated();

        var now = DateTime.UtcNow;

        foreach (var sensor in sensors)
        {
            if (sensor.SensorType == "ping" || sensor.Value == "INACTIVE")
            {
                var errorRecord = new SensorData
                {
                    SensorID = sensor.SensorID,
                    IsOnline = false,
                    Timestamp = now,
                    ErrorMessages = errorMessage ?? "Station offline or no data"
                };
                context.WeatherData.Add(errorRecord);
            }
            else
            {
                if (double.TryParse(sensor.Value, NumberStyles.Any, CultureInfo.InvariantCulture, out double val));

                var record = new SensorData
                {
                    SensorID = sensor.SensorID,
                    SensorName = sensor.SensorName,
                    SensorType = sensor.SensorType,
                    Value = val,
                    IsOnline = true,
                    Timestamp = now
                };
                
                context.WeatherData.Add(record);                
            }
        }
        await context.SaveChangesAsync();
    }

    public static async Task<RawDayData?> DownloadDayData(string url)
    {
        try
        {
            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            { 
                return null;
            }
            
            var xmlString = await response.Content.ReadAsStringAsync();
            var doc = XDocument.Parse(xmlString);

            var inputElement = doc.Root.Element("variable");
            if (inputElement == null)
            {
                return null;
            }
                

            var serializer = new XmlSerializer(typeof(RawDayData));
            using var reader = inputElement.CreateReader();
            var inputSensors = serializer.Deserialize(reader) as RawDayData;
            return inputSensors;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static async Task SaveDayToDatabase(RawDayData data)
    {
        using var context = new WeatherContext();
        context.Database.EnsureCreated();

        var now = DateTime.UtcNow;

        var record = new AvDayData
        {
            today = now,
            Sunrise = data.Sunrise,
            Sunset = data.Sunset,
            CivStart = data.CivStart,
            CivEnd = data.CivEnd,
            NautStart = data.NautStart,
            NautEnd = data.NautEnd,
            AstroStart = data.AstroStart,
            AstroEnd = data.AstroEnd,
            DayLen = data.DayLen,
            CivLen = data.CivLen,
            NautLen = data.NautLen,
            AstroLen = data.AstroLen,
            MoonPhase = data.MoonPhase,
            IsDay = data.IsDay,
            Bio = data.Bio,
            PressureOld = data.PressureOld,
            TemperatureAvg = data.TemperatureAvg,
            Agl = data.Agl,
            Fog = data.Fog,
            Lsp = data.Lsp,

        };

        context.DayData.Add(record);     
        await context.SaveChangesAsync();
    }
}