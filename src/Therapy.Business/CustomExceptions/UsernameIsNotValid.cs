namespace Therapy.Business.CustomExceptions;

public class UsernameIsNotValid :Exception
{
    public string PropertyName { get; set; }
    public UsernameIsNotValid()
    {

    }
    public UsernameIsNotValid(string propertyName, string message) : base(message) { PropertyName = propertyName; }
}
