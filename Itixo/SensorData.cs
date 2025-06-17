using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

public class SensorData
{
    [Key]
    public int Id { get; set; }
    public int SensorID { get; set; }
    public string? SensorName { get; set; }
    public string? SensorType { get; set; }
    public double? Value { get; set; }
    public bool IsOnline { get; set; }
    public DateTime? Timestamp { get; set; }
    public string? ErrorMessages { get; set; }
}
public class AvDayData
{
    [Key]
    public int Id { get; set; }
    public DateTime today { get; set; }
    public string Sunrise { get; set; }
    public string Sunset { get; set; }
    public string CivStart { get; set; }
    public string CivEnd { get; set; }
    public string NautStart { get; set; }
    public string NautEnd { get; set; }
    public string AstroStart { get; set; }
    public string AstroEnd { get; set; }
    public string DayLen { get; set; }
    public string CivLen { get; set; }
    public string NautLen { get; set; }
    public string AstroLen { get; set; }
    public int MoonPhase { get; set; }
    public int IsDay { get; set; }
    public int Bio { get; set; }
    public double PressureOld { get; set; }
    public double TemperatureAvg { get; set; }
    public int Agl { get; set; }
    public int Fog { get; set; }
    public int Lsp { get; set; }
}

[XmlRoot("input")]
public class InputSensors
{
    [XmlElement("sensor")]
    public List<RawData> Sensors { get; set; }
}

public class RawData
{
    [XmlElement("id")]
    public int SensorID { get; set; }
    [XmlElement("name")]
    public string SensorName { get; set; }
    [XmlElement("type")]
   public string SensorType { get; set; }
    [XmlElement("value")]
    public string Value { get; set; }

}

[XmlRoot("variable")]
public class RawDayData
{
    [XmlElement("sunrise")]
    public string Sunrise { get; set; }
    [XmlElement("sunset")]
    public string Sunset { get; set; }
    [XmlElement("civstart")]
    public string CivStart { get; set; }
    [XmlElement("civend")]
    public string CivEnd { get; set; }
    [XmlElement("nautstart")]
    public string NautStart { get; set; }
    [XmlElement("nautend")]
    public string NautEnd { get; set; }
    [XmlElement("astrostart")]
    public string AstroStart { get; set; }
    [XmlElement("astroend")]
    public string AstroEnd { get; set; }
    [XmlElement("daylen")]
    public string DayLen { get; set; }
    [XmlElement("civlen")]
    public string CivLen { get; set; }
    [XmlElement("nautlen")]
    public string NautLen { get; set; }
    [XmlElement("astrolen")]
    public string AstroLen { get; set; }
    [XmlElement("moonphase")]
    public int MoonPhase { get; set; }
    [XmlElement("isday")]
    public int IsDay { get; set; }
    [XmlElement("bio")]
    public int Bio { get; set; }
    [XmlElement("pressure_old")]
    public double PressureOld { get; set; }
    [XmlElement("temperature_avg")]
    public double TemperatureAvg { get; set; }
    [XmlElement("agl")]
    public int Agl { get; set; }
    [XmlElement("fog")]
    public int Fog { get; set; }
    [XmlElement("lsp")]
    public int Lsp { get; set; }
}