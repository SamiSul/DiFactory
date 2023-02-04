namespace DiFactory.FirstApproach;

public interface IDrink
{
    public string Type { get; set; }
}

public class Tea : IDrink
{
    public string Type { get; set; } = "Black";
}

public class Coffee : IDrink
{
    public string Type { get; set; } = "Americano";
}