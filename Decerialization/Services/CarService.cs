namespace Decerialization.Services;
using Decerialization.Models;
using System.Text.Json;

public class CarService
{
    protected List<Car> _cars;
    private string FileUrl;

    public CarService(string fileUrl)
    {
        FileUrl = fileUrl;
        _cars = LoadFromFile();
    }

    public void AddCar(Car car)
    {
        //foreach (var item in _cars)
        //{
        //    if (item.Id != car.Id)
        //    {
        //        _cars.Add(car);
        //    } else
        //    {
        //        Console.WriteLine("The car is in the list already");
        //    }
        //}

        Car carThatExists = _cars.FirstOrDefault(x => x.Id == car.Id);

        if (carThatExists != null)
        {
            Console.WriteLine("The car is in the list already");
        } else
        {
            _cars.Add(car);
            SaveChanges();
        }

    }

    public List<Car> GetCarByName(string name)
    {
        //foreach (var car in _cars)
        //{
        //    if (car.Name == name)
        //    {
        //        cars.Add(car);
        //    }
        //}

        //return cars;

        return _cars.Where(x => x.Name == name).ToList();

    }

    public void DeleteCar(int carId)
    {

        var car = _cars.FirstOrDefault(x => x.Id == carId);

        if (car != null)
        {
            _cars.Remove(car);
            SaveChanges();
        } else
        {
            Console.WriteLine("The car doesnt exist!!!!!!!!!!!!!!!!!!!!");
        }

    }

    public List<Car> GetCars()
    {
        return _cars;
    }


    private void SaveChanges()
    {
        var JsonFormated=JsonSerializer.Serialize<List<Car>>(_cars);
        if(!File.Exists(FileUrl))
        {
            File.Create(FileUrl).Close();
        }
        using var writer = new StreamWriter(FileUrl);
        writer.WriteLine(JsonFormated);
    }

    private List<Car> LoadFromFile()
    {
        if (!File.Exists(FileUrl))
        {
            Console.WriteLine("Faili ar arsebobs");
            throw new FileNotFoundException(FileUrl);
        }
        else
        {
            using var reader = new StreamReader(FileUrl);
            var allText=reader.ReadToEnd();
            if(allText.Length ==0)
            {
                return  new List<Car>();
            }
            var cars = JsonSerializer.Deserialize<List<Car>>(allText);
            return cars ?? new List<Car>();
        }
    }
}
