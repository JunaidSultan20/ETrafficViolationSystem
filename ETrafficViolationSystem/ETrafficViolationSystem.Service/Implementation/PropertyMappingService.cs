using System;
using System.Collections.Generic;
using System.Linq;
using ETrafficViolationSystem.Entities.Dto;
using ETrafficViolationSystem.Entities.Mappings.PropertyMappings;
using ETrafficViolationSystem.Entities.Mappings.PropertyMappings.Implementation;
using ETrafficViolationSystem.Entities.Mappings.PropertyMappings.Interface;
using ETrafficViolationSystem.Entities.Models;
using ETrafficViolationSystem.Service.Interface;

namespace ETrafficViolationSystem.Service.Implementation
{
    public class PropertyMappingService : IPropertyMappingService
    {
        private readonly Dictionary<string, PropertyMappingValue> _infractionsPropertyMapping =
            new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
            {
                { "Penalty", new PropertyMappingValue(new List<string> { "Penalty" })},
                { "Points", new PropertyMappingValue(new List<string> { "Points" })}
            };
        private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingService()
        {
            _propertyMappings.Add(new PropertyMapping<InfractionsDto, Infractions>(_infractionsPropertyMapping));
        }

        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<TSource, TDestination>()
        {
            IEnumerable<PropertyMapping<TSource, TDestination>> matchingMapping =
                _propertyMappings.OfType<PropertyMapping<TSource, TDestination>>();

            if (matchingMapping.Count() == 1)
                return matchingMapping.First().MappingDictionary;
            
            throw new Exception($"Cannot find exact property mapping interface " +
                                $"for <{typeof(TSource)},{typeof(TDestination)}");
        }
    }
}