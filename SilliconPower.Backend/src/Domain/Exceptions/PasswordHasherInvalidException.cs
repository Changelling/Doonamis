using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Exceptions
{
    public class PasswordHasherInvalidException : Exception
    {
        public PasswordHasherInvalidException(string password, Exception ex)
            : base($"Password Hasher {password} is invalid.", ex)
        {
        }
    }

}
