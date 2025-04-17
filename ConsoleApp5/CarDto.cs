namespace ConsoleApp5;

public class CarDto
{
    public int Id { get; set; }
    public string InternalCode { get; set; } = string.Empty;
    public string Make { get; set; } = string.Empty; 
    public string Model { get; set; } = string.Empty; 
    public int ProductionYear { get; set; } 
    public string? EngineSize { get; set; } 
    public string Temperature { get; set; } = string.Empty;
}
