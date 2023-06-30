using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM
{
    class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Service { get; set; }
        public Guid Id { get; set; }

        public Customer(string firstName, string lastName, string email, string service)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Service = service;
            Id = Guid.NewGuid();
        }
    }
}
