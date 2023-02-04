namespace DiFactory.FirstApproach;

public static class Factory
{
    public static void AddDrinkFactory(this IServiceCollection services)
    {
        services.AddTransient<IDrink,Tea>();
        services.AddTransient<IDrink, Coffee>();
        
        services.AddSingleton<Func<IEnumerable<IDrink>>>(serviceProvider =>
        {
            var factoryToBeInjected = () => { return serviceProvider.GetService<IEnumerable<IDrink>>(); };
            return factoryToBeInjected;
        });

        services.AddSingleton<IDrinkFactory, DrinkFactory>();
    }
}

public interface IDrinkFactory
{
    IDrink Get(string filter);
}

public class DrinkFactory : IDrinkFactory
{
    private readonly Func<IEnumerable<IDrink>> _factory;

    public DrinkFactory(Func<IEnumerable<IDrink>> factory)
    {
        _factory = factory;
    }
    
    public IDrink Get(string filter)
    {
        var services = _factory();
        var service = services.FirstOrDefault();
        return service;
    }
}