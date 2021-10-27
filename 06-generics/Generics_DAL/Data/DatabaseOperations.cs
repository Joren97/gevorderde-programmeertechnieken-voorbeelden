using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_DAL.Data
{
    public static class DatabaseOperations
    {

        public static List<Klant> OphalenKlanten()
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities()) 
            {
                return entities.Klanten.ToList();
            }
        }
        public static List<Order> OphalenOrders()
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                return entities.Orders.ToList();
            }
        }
        public static List<Product> OphalenProducten()
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                return entities.Producten.ToList();
            }
        }
        public static int ToevoegenOrder(Order order)
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                entities.Orders.Add(order);
                return entities.SaveChanges();
            }
        }
        public static int ToevoegenProduct(Product product)
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                entities.Producten.Add(product);
                return entities.SaveChanges();
            }
        }
        public static int AanpassenOrder(Order order)
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                entities.Entry(order).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }
        public static int AanpassenProduct(Product product)
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                entities.Entry(product).State = EntityState.Modified;
                return entities.SaveChanges();
            }
        }
        public static int VerwijderenOrder(Order order)
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                entities.Entry(order).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }
        public static int VerwijderenProduct(Product product)
        {
            using (VerkoopBeheerEntities entities = new VerkoopBeheerEntities())
            {
                entities.Entry(product).State = EntityState.Deleted;
                return entities.SaveChanges();
            }
        }
    }
}
