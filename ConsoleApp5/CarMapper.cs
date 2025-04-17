namespace ConsoleApp5;

[Mapper] 
public partial class CarMapper1
{    
    // --- Basic Mapping ---
    public partial CarDto MapCarToDto(CarEntity car);
}


[Mapper]
public partial class CarMapper2
{
  
    // --- Collection Mapping ---
    public partial List<CarDto> MapCarList(List<CarEntity> cars);


}



[Mapper]
public partial class CarMapper3
{
    // --- Configuration: Ignoring Properties ---
    [MapperIgnoreSource(nameof(CarEntity.LastServiceDate))]
    [MapperIgnoreSource(nameof(CarEntity.InternalCode))]
    public partial CarDto MapIgnoringProperties(CarEntity car);

}



[Mapper]
public partial class CarMapper4
{
    // --- Configuration: Different Names ---
    [MapProperty(nameof(CarEntity.Manufacturer), nameof(CarDto.Make))]
    [MapProperty(nameof(CarEntity.ModelName), nameof(CarDto.Model))]
    [MapProperty(nameof(CarEntity.YearOfProduction), nameof(CarDto.ProductionYear))]
    public partial CarDto MapCarToDtoWithRenames(CarEntity car);

   
}

[Mapper]
public partial class CarMapper5
{
    // --- Configuration: Type Conversion and Formatting ---
    [MapProperty(nameof(CarEntity.Manufacturer), nameof(CarDto.Make))]
    [MapProperty(nameof(CarEntity.ModelName), nameof(CarDto.Model))]
    [MapProperty(nameof(CarEntity.YearOfProduction), nameof(CarDto.ProductionYear))]
    [MapProperty(nameof(CarEntity.EngineVolume), nameof(CarDto.EngineSize), StringFormat = "F1")] // IFormattable
    [MapProperty(nameof(CarEntity.Temperature), nameof(CarDto.Temperature), StringFormat = "K")] // IFormattable
    public partial CarDto MapCarToDtoWithConversions(CarEntity car);
}



[Mapper]
public partial class CarMapper6
{
    // --- Configuration: User Defined Mapping ---
    // Helper method - can be private or protected in a class
    private string MapEngineVolumeToString(double volume) => $"{volume:F3}L";

    [MapProperty(nameof(CarEntity.Manufacturer), nameof(CarDto.Make))]
    [MapProperty(nameof(CarEntity.ModelName), nameof(CarDto.Model))]
    [MapProperty(nameof(CarEntity.YearOfProduction), nameof(CarDto.ProductionYear))]
    [MapProperty(nameof(CarEntity.EngineVolume), nameof(CarDto.EngineSize), Use = nameof(MapEngineVolumeToString))]
    public partial CarDto MapCarWithCustomEngineMapping(CarEntity car);
    
}

