using System;
using System.Collections.Generic;
using ETrafficViolationSystem.Entities.Mappings.PropertyMappings.Interface;

namespace ETrafficViolationSystem.Entities.Mappings.PropertyMappings.Implementation
{
    public class PropertyMapping<TSource, TDestination> : IPropertyMapping
    {
        public Dictionary<string, PropertyMappingValue> MappingDictionary { get; private set; }

        public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            MappingDictionary = mappingDictionary ?? throw new ArgumentNullException(nameof(mappingDictionary));
        }
    }
}