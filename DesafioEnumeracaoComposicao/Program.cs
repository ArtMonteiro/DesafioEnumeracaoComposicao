using System;
using DesafioEnumeracaoComposicao.Entities.Enums;
using DesafioEnumeracaoComposicao.Entities;
using System.Globalization;

namespace DesafioEnumeracaoComposicao
{
    class Program
    {
        static void Main(string[] args)
        {
 
            Console.WriteLine("Enter client data:");
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Client client = new Client(name, email, birthDate);
            Console.WriteLine();
            Console.WriteLine("Enter Order data: ");
            Console.Write("Status (PENDING_PAYMENT / PROCESSING / SHIPPED / DELIVERED): ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            DateTime momment = DateTime.Now;
            Order order = new Order(momment, status, client);
            Console.Write("How many itens to this order? ");
            int i = int.Parse(Console.ReadLine());

            for(int j = 1; j <= i; j++)
            {
                Console.WriteLine($"Enter #{j} item data: ");
                Console.Write("Product name: ");
                string nameItem = Console.ReadLine();
                Console.Write("Product price: ");
                double price = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                Product product = new Product(nameItem, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);
                order.AddItem(orderItem);

            }
            Console.WriteLine(order);



        }
    }
}