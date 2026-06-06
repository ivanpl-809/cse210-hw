using System;
class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "123 Main St",
            "Dallas",
            "Texas",
            "USA");
        Customer customer1 = new Customer(
            "John Smith",
            address1);
        Order order1 = new Order(customer1);
        order1.AddProduct(new Product(
            "Keyboard",
            "K101",
            45.99,
            1));
        order1.AddProduct(new Product(
            "Mouse",
            "M205",
            19.99,
            2));
        order1.AddProduct(new Product(
            "Monitor",
            "MN300",
            199.99,
            1));

        Address address2 = new Address(
            "Av. Universidad 100",
            "Queretaro",
            "Queretaro",
            "Mexico");
        Customer customer2 = new Customer(
            "Maria Garcia",
            address2);
        Order order2 = new Order(customer2);
        order2.AddProduct(new Product(
            "Headphones",
            "H500",
            59.99,
            1));
        order2.AddProduct(new Product(
            "Webcam",
            "W210",
            39.99,
            2));
        Console.WriteLine("===== ORDER 1 =====");
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine(
            $"\nTotal Cost: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n---------------------------\n");

        Console.WriteLine("===== ORDER 2 =====");
        Console.WriteLine("\nPacking Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine(
            $"\nTotal Cost: ${order2.CalculateTotalCost():F2}");
    }
}