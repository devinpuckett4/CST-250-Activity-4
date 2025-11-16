using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PizzaMakerClassLibrary.Models;

namespace PizzaMakerClassLibrary.Services.DataAccessLayer
{
    public class PizzaDAO
    {
        private readonly List<PizzaModel> _pizzaOrder;

        public PizzaDAO()
        {
            _pizzaOrder = new List<PizzaModel>();
        }

        /// Add a pizza, return count
        public int AddPizzaToOrder(PizzaModel pizza)
        {
            _pizzaOrder.Add(pizza);
            return _pizzaOrder.Count;
        }

        /// <summary>Return a copy of the current order.</summary>
        public List<PizzaModel> GetPizzaOrder() => _pizzaOrder.ToList();

        /// <summary>Write order to App_Data/PizzaOrder.txt</summary>
        public bool WriteOrderToFile()
        {
            string baseDir = AppDomain.CurrentDomain.BaseDirectory;
            string dataDir = Path.Combine(baseDir, "App_Data");
            Directory.CreateDirectory(dataDir);
            string filePath = Path.Combine(dataDir, "PizzaOrder.txt");

            try
            {
                using var sw = new StreamWriter(filePath, false);
                foreach (var p in _pizzaOrder)
                {
                    string line =
                        $"Name: {p.ClientName} | Crust: {p.Crust} | Sauce: {p.SauceAmount} | Cheese: {p.CheeseAmount} | " +
                        $"Ingredients: {string.Join(", ", p.Ingredients)} | AddOns: {string.Join(", ", p.StrangeAddOns)} | " +
                        $"Delivery: {p.DeliveryTime:MM/dd/yyyy HH:mm} | Price: ${p.Price:0.00}";
                    sw.WriteLine(line);
                }
                return true;
            }
            catch { return false; }
        }
    }
}