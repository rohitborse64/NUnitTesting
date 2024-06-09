using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public class AdvanceConcepts
    {
        public List<int> NumberRange = new List<int>();

        public int Discount = 15;

        public int OrderTotal { get; set; }

        public AdvanceConcepts() 
        {
            Discount = 20;
        }

        public List<int> GetOddRange(int min, int max)
        {
            NumberRange.Clear();
            for (int i = min; i <= max; i++)
            {
                if (i % 2 != 0)
                    NumberRange.Add(i);
            }
            return NumberRange;
        }

        // working with excpetions
        public string GetFullName(string firstName, string lastName)
        {
             
            // handle null exceptions
            if (string.IsNullOrEmpty(firstName))
                throw new ArgumentException("Empty First Name");

            return $"{firstName} {lastName}";
        }

        // use of Inheritance
        public CustomerType GetCustomerDetails()
        {
            if (OrderTotal < 100)
            {
                return new BasicCustomer();
            }
            return new PlatinumCustomer();
        }

    }


    // use of Inheritance
    public class CustomerType { }
    
    public class BasicCustomer : CustomerType { }

    public class PlatinumCustomer : CustomerType { }




}
