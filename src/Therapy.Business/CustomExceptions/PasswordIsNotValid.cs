namespace Therapy.Business.CustomExceptions;

public class PasswordIsNotValid : Exception
{
    public string PropertyName { get; set; }
    public PasswordIsNotValid()
    {

    }
    public PasswordIsNotValid(string propertyName, string message) : base(message) { PropertyName = propertyName; }
}
