namespace CloudSalesSystem.Infrastructure.Migrations.Seeding;

internal static class SeedingHelper
{
    internal static void SetProperty<TChild>(this TChild entity, string propertyName, object value)
        where TChild : class
    {
        var property = entity.GetType().GetProperty(propertyName);
        if (property != null && property.SetMethod != null)
        {
            property.SetValue(entity, value, null);
        }
        else
        {
            throw new FieldAccessException(propertyName);
        }
    }
}