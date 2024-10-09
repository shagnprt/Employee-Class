using System;

namespace OperatorOverloading
{
    // Employee class with Id, FirstName, and LastName properties
    public class Employee
    {
        // Properties for Employee class
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Overloading the '==' operator to compare Employee objects by Id
        public static bool operator ==(Employee emp1, Employee emp2)
        {
            // If both objects are null, they are equal
            if (ReferenceEquals(emp1, null) && ReferenceEquals(emp2, null))
                return true;

            // If one object is null and the other is not, they are not equal
            if (ReferenceEquals(emp1, null) || ReferenceEquals(emp2, null))
                return false;

            // Compare the Id properties of both Employee objects
            return emp1.Id == emp2.Id;
        }

        // Overloading the '!=' operator as the opposite of '=='
        public static bool operator !=(Employee emp1, Employee emp2)
        {
            return !(emp1 == emp2);
        }

        // Override Equals method to maintain consistency with the overloaded operators
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            Employee emp = (Employee)obj;
            return Id == emp.Id;
        }

        // Override GetHashCode method to avoid compiler warning
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Instantiate two Employee objects and assign values to their properties
            Employee emp1 = new Employee { Id = 1, FirstName = "John", LastName = "Doe" };
            Employee emp2 = new Employee { Id = 2, FirstName = "Jane", LastName = "Smith" };

            // Compare the two Employee objects using the overloaded '==' operator
            bool areEqual = emp1 == emp2;
            Console.WriteLine($"Are emp1 and emp2 equal? {areEqual}");

            // Create another Employee object with the same Id as emp1
            Employee emp3 = new Employee { Id = 1, FirstName = "Mike", LastName = "Johnson" };

            // Compare emp1 and emp3 using the overloaded '==' operator
            bool areEqual2 = emp1 == emp3;
            Console.WriteLine($"Are emp1 and emp3 equal? {areEqual2}");
        }
    }
}
