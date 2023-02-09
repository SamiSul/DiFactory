namespace DiFactory.NormalApproach;

public interface IVehicle
{
    public string Name { get; set; }
}

public class Car : IVehicle
{
    public string Name { get; set; } = "Ford";
}

public class Boat : IVehicle
{
    public string Name { get; set; } = "Avid";
}