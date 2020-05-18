using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using RepositoryManager;

namespace Application
{
    public class Query : App
    {
        #region Properties and Constructor

        public Query(
            IRepositoryManager repositoryManager,
            IMapper mapper
        ) : base(repositoryManager, mapper)
        {}

        #endregion

        #region Protected Methods

        public List<SeekedData> Fetch<SeekedData>(object[] values, int length=0, int index=0)
            where SeekedData : class, new()
        {
            List<SeekedData> returnList = new List<SeekedData>();
            /*Type selectorType = typeof(SeekedData).GetNestedType("Selector");
            Type entity = selectorType.GetCustomAttribute<EntityFetched>().Type;

            IEnumerable selectors = _repository.GetType()
                .GetMethod("Select")
                .MakeGenericMethod(selectorType)
                .Invoke(_repository, new object[] {
                    selectorType.GetMethod("Predicate").Invoke(null, new object[] { values }),
                    selectorType.GetMethod("Expression").Invoke(null, new object[] { }),
                    length, index
                }) as IEnumerable;
            IEnumerator enumerator = selectors.GetEnumerator();

            foreach (PropertyInfo prop in selectorType.GetProperties())
            {
                bool isList = typeof(IList).IsAssignableFrom(prop.PropertyType);
                bool isSeekedData = typeof(ISeekedData).IsAssignableFrom(prop.PropertyType);

                if (isList || isSeekedData)
                {
                    while (enumerator.MoveNext())
                    {
                        object result = null;
                        if (isList)
                        {
                            Type seekedData = prop.PropertyType.GetGenericArguments()[0];
                            Type childSelector = seekedData.GetNestedType("Selector");
                            object wantedPropsName = childSelector.GetMethod("GetWantedPropsName").Invoke(null, new object[] { });
                            object[] propsValue = (enumerator.Current as DataSelector).GetValuesOfProp(wantedPropsName as string[]);
                            result = GetType().GetMethod("Fetch").MakeGenericMethod(seekedData).Invoke(this, new object[] { propsValue, 0, 0 });
                        }
                        else if (isSeekedData)
                        {
                            Type seekedData = prop.PropertyType;
                            Type childSelector = seekedData.GetNestedType("Selector");
                            object wantedPropsName = childSelector.GetMethod("GetWantedPropsName").Invoke(null, new object[] { });
                            object[] propsValue = (enumerator.Current as DataSelector).GetValuesOfProp(wantedPropsName as string[]);
                            result = (GetType().GetMethod("Fetch").MakeGenericMethod(seekedData).Invoke(this, new object[] { propsValue, 0, 0 }) as IList)[0];
                        }
                        prop.SetValue(enumerator.Current, result);
                    }
                    enumerator.Reset();
                }
            }

            while(enumerator.MoveNext())
                returnList.Add(_mapper.Map<SeekedData>(enumerator.Current));*/

            return returnList;
        }

        #endregion
    }

    public class EntityFetched : Attribute
    {
        public Type Type { get; set; }

        public EntityFetched(Type type)
        {
            Type = type;
        }
    }

    public interface ISeekedDataMapping { }

    public abstract class DataSelector
    {
        public object[] GetValuesOfProp(string[] propNames)
        {
            List<object> values = new List<object>();
            foreach (string propName in propNames)
            {
                foreach (PropertyInfo prop in GetType().GetProperties())
                    if (prop.Name == propName)
                        values.Add(prop.GetValue(this));
            }
            return values.ToArray();
        }
    }
}
