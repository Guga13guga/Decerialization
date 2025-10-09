using System.ComponentModel.DataAnnotations;

namespace Decerialization.Models;

public class Vehicle
{

    public Vehicle()
    {
        
    }

    public Vehicle(int id, string name, string description, DateTime releaseDate)
    {
        Id = id;
        Name = name;
        Description = description;
        ReleaseDate = releaseDate;
    }

    [Range(0,10000)]
    public int Id { get; set; }

    [StringLength(10, MinimumLength = 3, ErrorMessage ="The Name must be 10 charecter")]
    public string Name { get; set; }

    [Required(ErrorMessage ="This parameter is required")]
    [StringLength(15,MinimumLength=5,ErrorMessage ="Size must be")]
    public required string Description { get; set; }

    public DateTime ReleaseDate { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Name: {Name}, Description: {Description}, Release Date: {ReleaseDate}.";
    }
}
