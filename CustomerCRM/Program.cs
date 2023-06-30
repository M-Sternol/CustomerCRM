using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CustomerCRM
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            customerManager.Run();
        }
    }
}