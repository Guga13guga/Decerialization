using Decerialization.Services;

var folder = @"C:\Users\teacher\Desktop\Test";

var file = "Text.json";

var fullPath = Path.Combine(folder, file);

if(!Directory.Exists(folder))
{
    Directory.CreateDirectory(folder);
}

if(!File.Exists(fullPath))
{
    File.Create(fullPath).Close();
}


CarService carService = new CarService(fullPath);

//carService.AddCar(new Car
//{
//    Description = "Test",
//    ReleaseDate = DateTime.Now,
//    Id = 1,
//    Name = "Test",
//    TireCount = 4,
//});

var getall = carService.GetCars();

foreach(var car in getall)
{
    Console.WriteLine(car);
}

//using var writer = new StreamWriter(fullPath);

//writer.WriteLine("This is Line 1");
//writer.WriteLine("This is Line 4");
//writer.WriteLine("This is Line 5");
//writer.WriteLine("This is Line 6");

