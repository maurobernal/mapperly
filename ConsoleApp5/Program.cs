Log.Logger = new LoggerConfiguration()
    .WriteTo.Console(theme: AnsiConsoleTheme.Literate)
    .CreateLogger();

var carFromDb = GetCarsFromDb().FirstOrDefault()?? new CarEntity();



Console.WriteLine("\n--- 1) Basic Mapping (may lack info due to different names/types) ---");
var mapper1 = new CarMapper1();
CarDto basicDto = mapper1.MapCarToDto(carFromDb);
PrintCarDto(basicDto);
Console.WriteLine("\n------------------------------------------------------------");


Console.WriteLine("\n--- 2) List Mapping ---");
var carListFromDb = GetCarsFromDb();
var mapper2 = new CarMapper2();
List<CarDto> dtoList = mapper2.MapCarList(carListFromDb); 
Console.WriteLine($"Mapped {dtoList.Count} cars.");
foreach (CarDto item in dtoList) PrintCarDto(item);
Console.WriteLine("\n------------------------------------------------------------");


Console.WriteLine("\n--- 3) Mapping Ignoring Properties ([MapperIgnore]) ---");
// This mapping lacks [MapProperty] for names, only ignores LastServiceDate
var mapper3 = new CarMapper3();
CarDto ignoredDto = mapper3.MapIgnoringProperties(carFromDb);
PrintCarDto(ignoredDto);
Console.WriteLine("\n------------------------------------------------------------");


Console.WriteLine("\n--- 4) Mapping with Renames ([MapProperty]) ---");
var mapper4 = new CarMapper4();
CarDto renamedDto = mapper4.MapCarToDtoWithRenames(carFromDb);
PrintCarDto(renamedDto);
Console.WriteLine("\n------------------------------------------------------------");


Console.WriteLine("\n--- 5) Mapping with Conversion and Formatting ([MapProperty] + StringFormat) ---");
var mapper5 = new CarMapper5();
CarDto convertedDtoSF = mapper5.MapCarToDtoWithConversions(carFromDb);
PrintCarDto(convertedDtoSF);
Console.WriteLine("\n------------------------------------------------------------");


Console.WriteLine("\n--- 6) Mapping with Custom Method ([MapProperty] + Use) ---");
var mapper6 = new CarMapper6();
CarDto convertedDtoUDM = mapper6.MapCarWithCustomEngineMapping(carFromDb);
PrintCarDto(convertedDtoUDM);
Console.WriteLine("\n------------------------------------------------------------");







// Helper to print
static void PrintCarDto(CarDto dto)
{
    Log.Information(System.Text.Json.JsonSerializer.Serialize(dto,  options:  System.Text.Json.JsonSerializerOptions.Web));
}


// Generate from BD

static List<CarEntity> GetCarsFromDb()
{
    return new List<CarEntity>
    {
        new CarEntity
        {
            Id = 1,
            InternalCode="TOYCOR-1",
            Manufacturer = "Toyota",
            ModelName = "Corolla",
            YearOfProduction = 2020,
            EngineVolume = 1.8,
            Temperature = new(50),
            LastServiceDate = DateTime.Now.AddMonths(-6)
        },
        new CarEntity
        {
            Id = 2,
            InternalCode="HONCIV-2",
            Manufacturer = "Honda",
            ModelName = "Civic",
            YearOfProduction = 2019,
            EngineVolume = 2.0,
            Temperature = new(30),
            LastServiceDate = DateTime.Now.AddMonths(-3)
        },
         new CarEntity
        {
            Id = 2,
            InternalCode="CHECOR-3",
            Manufacturer = "Chevrolet",
            ModelName = "Corsa",
            YearOfProduction = 2022,
            EngineVolume = 1.6,
            Temperature = new(46),
            LastServiceDate = DateTime.Now.AddMonths(-5)
        }
    };
}