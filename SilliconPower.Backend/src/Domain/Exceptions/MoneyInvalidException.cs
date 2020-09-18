using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.Exceptions
{
    public class MoneyInvalidException : Exception
    {
        public MoneyInvalidException(string money, Exception ex)
            : base($"Money {money} is invalid. The format must be like (Amount Currency). ie: '10 USD'", ex)
        {
        }
    }
}
