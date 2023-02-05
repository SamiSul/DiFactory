namespace DiFactory.SecondApproach;

public interface IFood
{
    public string Name { get; set; }
}

public class Ramen : IFood
{
    public string Name { get; set; } = "Instant";
}

public class Chips : IFood
{
    public string Name { get; set; } = "Lays";
}