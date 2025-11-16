// Devin Leugers - CST-250 Activity 4
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PizzaMakerClassLibrary.Models
{
    // Holds all info for a single pizza
    public class PizzaModel
    {
        public string ClientName { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> StrangeAddOns { get; set; }

        // Core choices
        public string Crust { get; set; }
        public int SauceAmount { get; set; }
        public int CheeseAmount { get; set; }

        // Extras
        public DateTime DeliveryTime { get; set; }
        public Color PizzaBoxColor { get; set; }

        // Final price for this pizza
        public decimal Price { get; set; }

        // Aliases to match any older code if needed
        public string CrustType
        {
            get => Crust;
            set => Crust = value;
        }

        public int SauceQuantity
        {
            get => SauceAmount;
            set => SauceAmount = value;
        }

        public int CheeseQuantity
        {
            get => CheeseAmount;
            set => CheeseAmount = value;
        }

        public PizzaModel()
        {
            ClientName = "";
            Ingredients = new List<string>();
            StrangeAddOns = new List<string>();
            Crust = "";
            SauceAmount = 0;
            CheeseAmount = 0;
            DeliveryTime = DateTime.Now;
            PizzaBoxColor = Color.White;
            // Base price will be set/updated by PizzaLogic
            Price = 15.00m;
        }
    }
}




