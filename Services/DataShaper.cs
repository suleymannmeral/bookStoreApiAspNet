using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection;

namespace Services
{
    public class DataShaper<T> : IDataShaper<T>
        where T : class
    {
        public DataShaper()
        {
            Properties = typeof(T)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance);
        }

        public PropertyInfo[] Properties { get; set; }
        public IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entitites, string fieldsString)
        {
            var requiredFields= GetRequiredProperties(fieldsString);
            return FetchData(entitites, requiredFields);
         
        }

        public ExpandoObject ShapeData(T entity, string fieldsString)
        {
            var requiredProperties= GetRequiredProperties(fieldsString);
            return FetchDataForEntity(entity, requiredProperties);
        }

        private IEnumerable<PropertyInfo>GetRequiredProperties(string fieldsString)
        {
            var requiredFileds= new List<PropertyInfo>();
            if(!string.IsNullOrEmpty(fieldsString))
            {
                var fields= fieldsString.Split(',',
                    StringSplitOptions.RemoveEmptyEntries);

                foreach(var field in fields)
                {
                    var property= Properties
                        .FirstOrDefault(pi=>pi.Name.Equals(field.Trim(),
                        StringComparison.InvariantCultureIgnoreCase));

                    if (property is null)
                        continue;
                    requiredFileds.Add(property);
                }
            }
            else
            {
                requiredFileds = Properties.ToList();
            }

            return requiredFileds;

        }
        
        private ExpandoObject FetchDataForEntity(T entity,
            IEnumerable<PropertyInfo>requiredProperties)
        {
            var shapedObject= new ExpandoObject();

            foreach(var property in requiredProperties)
            {
                var objectPropertyValue=property.GetValue(entity);
                shapedObject.TryAdd(property.Name, objectPropertyValue);
            }
            return shapedObject;
        }

        private IEnumerable<ExpandoObject>FetchData(IEnumerable<T>entities,
            IEnumerable<PropertyInfo>requiredProperties)
        {
            var shapedData= new List<ExpandoObject>();
            foreach(var entity in entities)
            {
                var shapedObject=FetchDataForEntity(entity,requiredProperties);
                shapedData.Add(shapedObject);
            }
            return shapedData;
        }
    }
}
