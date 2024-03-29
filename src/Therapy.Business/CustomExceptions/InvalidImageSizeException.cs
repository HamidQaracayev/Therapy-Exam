﻿namespace Therapy.Business.CustomExceptions;

public class InvalidImageSizeException : Exception
{
    public string PropertyName { get; set; }
    public InvalidImageSizeException()
    {

    }
    public InvalidImageSizeException(string propertyName, string message) : base(message) { PropertyName = propertyName; }
}
