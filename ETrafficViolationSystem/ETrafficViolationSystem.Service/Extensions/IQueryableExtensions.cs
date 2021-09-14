using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using ETrafficViolationSystem.Entities.Mappings.PropertyMappings;

namespace ETrafficViolationSystem.Service.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source, string orderBy,
               Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            if (mappingDictionary == null)
            {
                throw new ArgumentNullException(nameof(mappingDictionary));
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                return source;
            }

            string orderByString = string.Empty;
            string[] orderByArray = orderBy.Split(',');
  
            foreach (var orderByClause in orderByArray)
            {
                string orderByClauseTrimmed = orderByClause.Trim(); 
                bool orderDescending = orderByClauseTrimmed.EndsWith(" desc");
                var indexOfFirstSpace = orderByClauseTrimmed.IndexOf(" ");
                var propertyName = indexOfFirstSpace == -1 ?
                    orderByClauseTrimmed : orderByClauseTrimmed.Remove(indexOfFirstSpace);

                if (!mappingDictionary.ContainsKey(propertyName))
                {
                    throw new ArgumentException($"Key mapping for {propertyName} is missing");
                }

                var propertyMappingValue = mappingDictionary[propertyName];

                if (propertyMappingValue == null)
                {
                    throw new ArgumentNullException("propertyMappingValue");
                }

                foreach (var destinationProperty in propertyMappingValue.DestinationProperties)
                {
                    if (propertyMappingValue.Revert)
                    {
                        orderDescending = !orderDescending;
                    }

                    orderByString = orderByString + (string.IsNullOrWhiteSpace(orderByString) ? string.Empty : ", ") + destinationProperty 
                                    + (orderDescending ? " descending" : " ascending");
                }
            }
            return source.OrderBy(orderByString);
        }
    }
}