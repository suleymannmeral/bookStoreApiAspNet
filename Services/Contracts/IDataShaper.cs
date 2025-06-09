using System.Dynamic;


namespace Services.Contracts
{
    public interface IDataShaper<T>
    {
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entitites,string fieldsString);
        ExpandoObject ShapeData(T entity, string fieldsString);
    }
}
