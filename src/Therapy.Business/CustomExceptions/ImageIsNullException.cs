namespace Therapy.Business.CustomExceptions;

public class ImageIsNullException : Exception
{
    public string PropertyName { get; set; }
    public ImageIsNullException()
    {

    }
    public ImageIsNullException(string propertyName, string message) : base(message) { PropertyName = propertyName; }
}
