using System.ComponentModel.DataAnnotations;

namespace Decerialization.Models;

public class Car : Vehicle
{

    public Car()
    {
        
    }

    public Car(int TireCount, int id, string name, string description, DateTime releaseDate):base(id, name, description, releaseDate)
    {
        this.TireCount = TireCount;
    }

    [Range(2,10,ErrorMessage ="the tire count is not valid")]
    public int TireCount { get; set; }


}
