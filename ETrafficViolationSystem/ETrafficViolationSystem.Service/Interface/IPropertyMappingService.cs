using System.Collections.Generic;
using ETrafficViolationSystem.Entities.Mappings.PropertyMappings;

namespace ETrafficViolationSystem.Service.Interface
{
    public interface IPropertyMappingService
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>();

        bool ValidMappingExists<TSource, TDestination>(string fields);
    }
}