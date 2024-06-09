using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class Customer
    {
        
        public string GreetMessage { get; set; }

        public string GreetAndCombineNames(string firstName, string lastName) 
        {
            // handle null exceptions
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("Empty First Name");


            GreetMessage = $"Hello, {firstName} {lastName}";
            return GreetMessage;
        }


        public string CustomerIdWithFullName(string customerId, string fullName)
        {
            return $"{customerId} {fullName}";
        }

    }

    
}
