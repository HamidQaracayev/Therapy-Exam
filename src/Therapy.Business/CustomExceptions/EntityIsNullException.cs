namespace Therapy.Business.CustomExceptions;

public class EntityIsNullException : Exception
{
    public string PropertyName { get; set; }
	public EntityIsNullException()
	{

	}
	public EntityIsNullException(string propertyName, string message) : base(message) { PropertyName = propertyName; }
	
}
