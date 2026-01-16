using System;
using System.Collections.Generic;

namespace HotelReservationRedesign
{
    // Change 1: Customer class to store customer info
    class Customer
    {
        public string Name { get; set; }
        public int Nights { get; set; }
        public string RoomService { get; set; }
        public double Cost { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tWelcome to Sydney Hotel");

            // Change 2: Used List<Customer> instead of arrays
            List<Customer> customers = new List<Customer>();

            while (true)
            {
                Customer customer = new Customer();

                // Taking user input
                Console.WriteLine("Enter Customer Name:");
                customer.Name = Console.ReadLine();

                Console.WriteLine("Enter Number of nights:");
                customer.Nights = GetValidNights(); // Change 4: Input validation function

                Console.WriteLine("Enter yes/no for room service:");
                customer.RoomService = Console.ReadLine().ToLower();

                // Change 3: Calculate cost using a function
                customer.Cost = CalculateCost(customer.Nights, customer.RoomService);

                Console.WriteLine($"Total price for {customer.Name} is ${customer.Cost}");

                customers.Add(customer);

                // Option to quit or continue
                Console.WriteLine("________________________________________");
                Console.WriteLine("Press q to exit or any other key to continue:");
                string choice = Console.ReadLine();
                if (choice.ToLower() == "q")
                {
                    break;
                }
                Console.WriteLine("________________________________________");
            }

            // Display summary table
            Console.WriteLine("\t\t\tSummary of Reservations");
            Console.WriteLine("Name\t\tNights\tRoom Service\tCharge");
            foreach (var cust in customers)
            {
                Console.WriteLine($"{cust.Name}\t\t{cust.Nights}\t{cust.RoomService}\t\t{cust.Cost}");
            }

            // Find highest spender
            Customer highest = customers[0];
            Customer lowest = customers[0];
            foreach (var cust in customers)
            {
                if (cust.Cost > highest.Cost) highest = cust;
                if (cust.Cost < lowest.Cost) lowest = cust;
            }

            Console.WriteLine($"\nCustomer spending the most is {highest.Name} ${highest.Cost}");
            Console.WriteLine($"Customer spending the least is {lowest.Name} ${lowest.Cost}");
        }

        // Change 3: Function to calculate cost
        static double CalculateCost(int nights, string roomService)
        {
            double cost = 0;
            if (nights >= 1 && nights <= 3) cost = nights * 100;
            else if (nights >= 4 && nights <= 10) cost = nights * 80.5;
            else cost = nights * 75.3;

            if (roomService == "yes") cost += cost * 0.10;
            return cost;
        }

        // Change 4: Input validation for number of nights
        static int GetValidNights()
        {
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int nights) && nights >= 1 && nights <= 20)
                    return nights;
                Console.WriteLine("Invalid input. Enter a number between 1 and 20:");
            }
        }
    }
}
