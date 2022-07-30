using System;

namespace Account.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, object key) 
            : base($"Entity {name} with id {key} not found.")
        {
        }
    }
}
