namespace Therapy.Business.CustomExceptions;

public class ContentTypeNotValidException : Exception
{
    public string PropertyName { get; set; }
    public ContentTypeNotValidException()
    {

    }
    public ContentTypeNotValidException(string propertyName, string message) : base(message) { PropertyName = propertyName; }
}
