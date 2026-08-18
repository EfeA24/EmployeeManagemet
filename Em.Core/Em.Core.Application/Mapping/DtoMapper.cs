using System.Reflection;

namespace Em.Core.Application.Mapping
{
    public static class DtoMapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
            where TDestination : class, new()
        {
            var destination = new TDestination();
            MapTo(source, destination);
            return destination;
        }

        public static void MapTo<TSource, TDestination>(TSource source, TDestination destination)
            where TDestination : class
        {
            if (source is null || destination is null)
                return;

            var sourceProperties = typeof(TSource).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var destinationProperties = typeof(TDestination)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(property => property.CanWrite)
                .ToDictionary(property => property.Name);

            foreach (var sourceProperty in sourceProperties)
            {
                if (!destinationProperties.TryGetValue(sourceProperty.Name, out var destinationProperty))
                    continue;

                if (destinationProperty.PropertyType != sourceProperty.PropertyType)
                    continue;

                destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
            }
        }
    }
}
