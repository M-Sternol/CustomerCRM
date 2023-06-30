using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCRM
{
    class CustomerManager
    {
        private List<Customer> customers = new List<Customer>();

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("===== Zarządzanie klientami (CRM) =====" + "\n");
                Console.WriteLine("1. Dodaj klienta");
                Console.WriteLine("2. Wyświetl wszystkich klientów");
                Console.WriteLine("3. Wyszukaj klienta");
                Console.WriteLine("4. Wyjdź z aplikacji" + "\n");

                Console.Write("Wybierz opcję: ");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        AddCustomer();
                        break;
                    case "2":
                        DisplayCustomers();
                        break;
                    case "3":
                        seachCustomer();
                        break;
                    case "4":
                        Console.WriteLine("\n" + "Do zobaczenia!");
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Nieprawidłowa opcja. Spróbuj ponownie.");
                        break;
                }

                Console.WriteLine();
            }
        }

        private void AddCustomer()
        {
            Console.Clear();
            Console.WriteLine("===== Dodaj klienta =====" + "\n");
            Console.Write("Podaj imię: ");
            string firstName = Console.ReadLine();

            Console.Write("Podaj nazwisko: ");
            string lastName = Console.ReadLine();

            string email;
            while (true)
            {
                Console.Write("Podaj adres e-mail: ");
                email = Console.ReadLine();

                if (email.Contains("@"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy adres e-mail. Spróbuj ponownie.");
                }
            }

            Console.Write("Podaj usługę: ");
            string service = Console.ReadLine();

            Customer customer = new Customer(firstName, lastName, email, service);
            customer.Id = Guid.NewGuid();
            customers.Add(customer);

            Console.WriteLine("\n" + "Klient dodany pomyślnie!");
        }
        private void DisplayCustomers()
        {
            Console.Clear();
            Console.WriteLine("===== Lista klientów =====" + "\n");

            foreach (Customer customer in customers)
            {
                string maxId = MAXIDcustomer(customer.Id.ToString(), 8);
                Console.WriteLine("ID klienta: " + maxId + "\n");
                Console.WriteLine($"Imię: {customer.FirstName}" + "\n" + $"Nazwisko: {customer.LastName}" +"\n" + $"Email: {customer.Email}" + "\n" + $"Usługa: {customer.Service}");
                Console.WriteLine("=============================" + "\n");
            }

            int total = customers.Count;
            Console.WriteLine("\n" + "ŁĄCZNA LICZBA KLIENÓW - " + total + "\n");
        }

        private string MAXIDcustomer(string id, int maxLength)
        {
            if (id.Length <= maxLength)
                return id;

            return id.Substring(0, maxLength);
        }
        private void seachCustomer()
        {
            Console.Clear();
            Console.WriteLine("===== Wyszukiwarka klientów =====" + "\n");
            Console.Write("Imię: ");
            string firstName = Console.ReadLine();
            Console.Write("Nazwisko: ");
            string lastName = Console.ReadLine();
            string email;
            while (true)
            {
                Console.Write("Adres e-mail: ");
                email = Console.ReadLine();

                if (email.Contains("@"))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy adres e-mail. Spróbuj ponownie.");
                }
            }
            Console.Write("Usługa: ");
            string service = Console.ReadLine();

            List<Customer> foundCustomers = FindCustomersByFirstName(customers, firstName, lastName, email, service);

            if (foundCustomers.Count > 0)
            {
                Console.WriteLine("\n" + "Znaleziono klientów:" + "\n");

                foreach (Customer customer in foundCustomers)
                {
                    string maxId = MAXIDcustomer(customer.Id.ToString(), 8);
                    Console.WriteLine("Imię: " + customer.FirstName);
                    Console.WriteLine("Nazwisko: " + customer.LastName);
                    Console.WriteLine("Email: " + (customer.Email.Contains("@") ? customer.Email : "Nieprawidłowy adres e-mail - Brak znaku @ "));
                    Console.WriteLine("Usługa: " + customer.Service);
                    Console.WriteLine("ID Klienta: " + maxId);
                    Console.WriteLine("=============================");
                    Console.WriteLine("\n");
                }
                int total = customers.Count;
                Console.WriteLine("\n"+"Ilość znalezionych: " + total + "\n");
            }
            else
            {
                Console.WriteLine("\n" + "Nie znaleziono klientów");
            }
        }
        private List<Customer> FindCustomersByFirstName(List<Customer> customers, string firstName, string lastName, string email, string service)
        {
            List<Customer> foundCustomers = new List<Customer>();

            foreach (Customer customer in customers)
            {
                if (customer.FirstName.Equals(firstName, StringComparison.OrdinalIgnoreCase) ||
                    customer.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase) ||
                    customer.Service.Equals(service, StringComparison.OrdinalIgnoreCase))
                {
                    foundCustomers.Add(customer);
                }
                if (customer.Email.Contains("@") && customer.Email.Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    foundCustomers.Add(customer);
                }

            }

            return foundCustomers;
        }


    }
}


