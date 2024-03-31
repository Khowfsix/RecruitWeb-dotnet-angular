using System.Linq.Expressions;
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
        var property = entityType.GetProperty(fieldName) ?? throw new ArgumentException($"Property {fieldName} not found on type {entityType.Name}");
        var parameter = Expression.Parameter(entityType, "x");

        var propertyAccess = Expression.MakeMemberAccess(parameter, property);

        var orderByExp = Expression.Lambda(propertyAccess, parameter);

        var methodName = sortValue == "ASC" ? "OrderBy" : "OrderByDescending";

        var orderByMethod = typeof(Queryable).GetMethods().Single(
            method => method.Name == methodName
                && method.IsGenericMethodDefinition
                && method.GetGenericArguments().Length == 2
                && method.GetParameters().Length == 2)
            .MakeGenericMethod(entityType, property.PropertyType);

        return (IQueryable<T>)orderByMethod.Invoke(null, new object[] { query, orderByExp })!;
    }
}