using System.Linq.Expressions;
using System.Reflection;
namespace Data.Sorting;

public class Sort<T>
{
    public string sortString { get; set; }

    public Sort(string sortString)
    {
        this.sortString = sortString;
    }

    public IQueryable<T> getSort(IQueryable<T> query)
    {
        var sortList = this.sortString.Split('_');
        if (sortList.Length != 2)
        {
            return query;
        }

        string fieldName = sortList[0];
        string sortValue = sortList[1];

        var entityType = typeof(T);
        var property = entityType.GetProperty(fieldName);

        if (property == null)
        {
            throw new ArgumentException($"Property {fieldName} not found on type {entityType.Name}");
        }

        // Create the lambda expression parameter
        var parameter = Expression.Parameter(entityType, "x");

        // Create the property access expression
        var propertyAccess = Expression.MakeMemberAccess(parameter, property);

        // Create the sorting lambda expression
        var orderByExp = Expression.Lambda(propertyAccess, parameter);

        // Determine if it's Ascending or Descending order
        var methodName = sortValue == "ASC" ? "OrderBy" : "OrderByDescending";

        // Get the generic method definition for OrderBy/OrderByDescending
        var orderByMethod = typeof(Queryable).GetMethods().Single(
            method => method.Name == methodName
                && method.IsGenericMethodDefinition
                && method.GetGenericArguments().Length == 2
                && method.GetParameters().Length == 2)
            .MakeGenericMethod(entityType, property.PropertyType);

        // Invoke OrderBy/OrderByDescending method with the expression
        return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { query, orderByExp });
    }


    //public IQueryable<T> getSort(IQueryable<T> query)
    //{
    //    var sortList = sortString.Split('_');
    //    if (sortList.Length != 2)
    //    {
    //        return query;
    //    }

    //    string fieldName = sortList[0];
    //    string sortValue = sortList[1];
    //    switch (sortValue)
    //    {
    //        case "ASC":
    //            {
    //                return query.OrderBy(x => GetPropertyValue(x, fieldName));
    //            }
    //        case "DESC":
    //            {
    //                return query.OrderByDescending(x => GetPropertyValue(x, fieldName));
    //            }
    //        default:
    //            {
    //                return query;
    //            }
    //    }
    //}

    //public static object GetPropertyValue(object obj, string propertyName)
    //{
    //    PropertyInfo propertyInfo = obj.GetType().GetProperty(propertyName);

    //    if (propertyInfo != null)
    //    {
    //        return propertyInfo.GetValue(obj);
    //    }

    //    return null;
    //}
}