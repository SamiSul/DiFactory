namespace DiFactory.SecondApproach;

public static class Factory
{
    public static IServiceCollection AddFoodFactory(this IServiceCollection services)
    {
        services.AddTransient<Ramen>();
        services.AddTransient<Chips>();
        services.AddSingleton<IFoodFactory>(provider =>
        {
            var factories = new Dictionary<string, Func<IFood>>()
            {
                ["ramen"] = () => provider.GetService<Ramen>(),
                ["chips"] = () => provider.GetService<Chips>(),
            };
            return new FoodFactory(factories);
        });
        return services;
    }
}

public interface IFoodFactory
{
    IFood Create(Food type);
}

public class FoodFactory : IFoodFactory
{
    private readonly Dictionary<string, Func<IFood>> _factories;

    public FoodFactory(Dictionary<string, Func<IFood>> factories)
    {
        _factories = factories;
    }

    public IFood Create(Food type)
    {
        if (!_factories.TryGetValue(type.ToString().ToLower(), out var factory) || factory is null)
            throw new ArgumentOutOfRangeException(nameof(type), $"type '{type}' is not registered");
        return factory();
    }
}

public enum Food
{
    Ramen,
    Chips
}