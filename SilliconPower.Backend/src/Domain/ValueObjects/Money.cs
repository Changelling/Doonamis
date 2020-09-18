using SilliconPower.Backend.Domain.Common;
using SilliconPower.Backend.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SilliconPower.Backend.Domain.ValueObjects
{
    public class Money : ValueObject
    {
        public string Currency { get; }
        public decimal Amount { get; }

        private Money() { 

        }

        public Money(string currency, decimal amount)
        {
            Currency = currency;
            Amount = amount;
        }

        /// <summary>
        /// Create a Money based on 'Amount Currency' string:
        /// </summary>
        /// <exception cref="MoneyInvalidException">
        /// Thrown when the money are not in the correct format.
        /// </exception>
        public static Money For(string moneyStr)
        {
            try
            {
                var money = moneyStr.Split(" ");
                var ammount = decimal.Parse(money[0]);
                var currency = money[1];
                return new Money(currency, ammount);
            }
            catch (Exception ex)
            {
                throw new MoneyInvalidException(moneyStr, ex);
            }
        }

        public static implicit operator string(Money money)
        {
            return money.ToString();
        }

        public static explicit operator Money(string money)
        {
            return For(money);
        }

        public override string ToString()
        {
            return $"{Math.Round(Amount, 2)} {Currency.ToUpper()}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Currency.ToUpper();
            yield return Math.Round(Amount, 2);
        }
    }
}
