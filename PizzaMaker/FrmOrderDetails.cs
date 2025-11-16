using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PizzaMakerClassLibrary.Models;
using PizzaMakerClassLibrary.Services.BusinessLogicLayer;

namespace PizzaMaker
{
    // This form shows the list of pizzas in the current order
    // and lets the user save the order to a file.
    public class FrmOrderDetails : Form
    {
        // List of pizzas that were created on FrmPizzaMaker
        private readonly List<PizzaModel> _pizzaOrders;

        // Shared business logic object used to save the order
        private readonly PizzaLogic _pizzaLogic;

        // Controls on this form
        private Label lblOrderDetails;
        private Button btnSaveOrder;
        private Button btnBack;

        // Constructor
        // It receives the list of pizzas and the PizzaLogic from FrmPizzaMaker,
        public FrmOrderDetails(List<PizzaModel> pizzaOrders, PizzaLogic pizzaLogic)
        {
            // Basic window setup
            Text = "Pizza Order Details";
            StartPosition = FormStartPosition.CenterParent;
            ClientSize = new Size(600, 460);

            // Store references so other methods can use them
            _pizzaOrders = pizzaOrders ?? new List<PizzaModel>();
            _pizzaLogic = pizzaLogic;

            // Build the label and buttons on the form
            BuildControls();

            // Fill the label with the pizza details
            DisplayPizzas();
        }

        // BuildControls
        // Creates and positions the label and buttons on the form.
        private void BuildControls()
        {
            // Label to show all pizzas in the order
            lblOrderDetails = new Label
            {
                AutoSize = false,
                Location = new Point(20, 20),
                Size = new Size(560, 280),
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Consolas", 10),
                BackColor = Color.White,
                Padding = new Padding(8),
                AutoEllipsis = true
            };
            Controls.Add(lblOrderDetails);

            // Save Order button
            btnSaveOrder = new Button
            {
                Text = "Save Order",
                Location = new Point(20, 320),
                Size = new Size(120, 30)
            };
            // Hook up the click event to our handler
            btnSaveOrder.Click += BtnSaveOrderClickEH;
            Controls.Add(btnSaveOrder);

            // Back/Close button
            btnBack = new Button
            {
                Text = "Back",
                Location = new Point(160, 320),
                Size = new Size(120, 30)
            };
            // When clicked, just close this window
            btnBack.Click += (s, e) => this.Close();
            Controls.Add(btnBack);
        }

        // DisplayPizzas
        // Builds a formatted string showing every pizza in the order
        public void DisplayPizzas()
        {
            var sb = new StringBuilder();

            if (_pizzaOrders.Count == 0)
            {
                sb.AppendLine("No pizzas in this order yet.");
            }
            else
            {
                int i = 1;
                foreach (var p in _pizzaOrders)
                {
                    string ing = (p.Ingredients != null && p.Ingredients.Count > 0)
                        ? string.Join(", ", p.Ingredients)
                        : "(none)";

                    string weird = (p.StrangeAddOns != null && p.StrangeAddOns.Count > 0)
                        ? string.Join(", ", p.StrangeAddOns)
                        : "(none)";

                    sb.AppendLine($"Pizza #{i}");
                    sb.AppendLine($" Name: {p.ClientName}");
                    sb.AppendLine($" Crust: {p.Crust}");
                    sb.AppendLine($" Ingredients: {ing}");
                    sb.AppendLine($" Strange Add Ons: {weird}");
                    sb.AppendLine($" Sauce Amount: {p.SauceAmount}");
                    sb.AppendLine($" Cheese Amount: {p.CheeseAmount}");
                    sb.AppendLine($" Delivery Time: {p.DeliveryTime:MM/dd/yyyy HH:mm}");
                    sb.AppendLine($" Box Color (ARGB): {p.PizzaBoxColor.ToArgb()}");
                    sb.AppendLine($" Price: ${p.Price:0.00}");
                    sb.AppendLine(new string('-', 40));
                    sb.AppendLine();
                    i++;
                }
            }

            lblOrderDetails.Text = sb.ToString();
        }

        // Uses PizzaLogic to write the order to the text file
        // and shows a simple message based on success/failure.
        private void BtnSaveOrderClickEH(object sender, EventArgs e)
        {
            bool ok = _pizzaLogic.WriteOrderToFile();
            if (ok)
                MessageBox.Show("Order saved to file.", "Saved");
            else
                MessageBox.Show("Failed to save order.", "Error");
        }
    }
}