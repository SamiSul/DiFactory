namespace DiFactory.NormalApproach;

public static class VehicleDi
{
    public static IServiceCollection AddScopedVehicle(this IServiceCollection services)
    {
        services.AddScoped<IVehicle, Car>();
        return services;
    }
}