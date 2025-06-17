using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

public class WeatherContext : DbContext
{
    public DbSet<SensorData> WeatherData { get; set; }
    public DbSet<AvDayData> DayData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=weatherdata.db");
    }

}