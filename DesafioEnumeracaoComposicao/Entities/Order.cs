using DesafioEnumeracaoComposicao.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioEnumeracaoComposicao.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Item { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {

        }
        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }
        public void AddItem(OrderItem item)
        {
            Item.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Item.Remove(item);
        }
        public double Total()
        {
            double total =0,total1 = 0, total2 =0;
            foreach(OrderItem item in Item)
            {
                total1 = item.Quantity;
                total2 = item.Price;
                total += total1 * total2;
            }
            
            return total;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY: ");
            sb.AppendLine("Order Moment: "+ Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Status: " + Status);
            sb.AppendLine("Client: " + Client.Name + " ("+Client.BirthDate.ToString("dd/MM/yyyy")+") "+"- "+Client.Email);
            sb.AppendLine("Order Itens: ");
            foreach(OrderItem item in Item)
            {
                sb.AppendLine(item.Product.Name + ", $" + item.Product.Price.ToString("F2",CultureInfo.InvariantCulture) + " Quantity: " + item.Quantity + ", Subtotal: " + item.SubTotal());
            }
            sb.AppendLine("Total: " + Total());
            return sb.ToString();

                
        }
    }
}
