namespace ConsoleApp5;
public class CarEntity
{
    public int Id { get; set; }
    public string InternalCode { get; set; } = string.Empty;
    public string Manufacturer { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public int YearOfProduction { get; set; }
    public double EngineVolume { get; set; }
    public Temperature Temperature { get; set; } = new (0);
    public DateTime LastServiceDate { get; set; }
}
