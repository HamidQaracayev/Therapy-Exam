namespace Therapy.Business.CustomExceptions;

public class IdBelowZero : Exception
{
    public string PropertyName { get; set; }
    public IdBelowZero()
    {

    }
    public IdBelowZero(string propertyName, string message) : base(message) { PropertyName = propertyName; }
}
