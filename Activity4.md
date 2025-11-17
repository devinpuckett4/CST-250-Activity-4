[Devin Puckett]

[CST-250 Programming in C#2]

[Grand Canyon University]

[11/09/2025]

[Activity 4]

[https://github.com/devinpuckett4/CST-250-Activity-4/blob/main/Activity4.md]

[https://www.loom.com/share/fba174d2660b451baff641808fb84d23]






FLOW CHART
 
Figure 1: Flow chart Activity 5 PizzaMaker
This flowchart shows the full path of a pizza order through my layered PizzaMaker app. It starts when the app launches and Program.cs creates the PizzaLogic object and main FrmPizzaMaker form. The user selects their options on FrmPizzaMaker, then clicks Create Pizza, which triggers validation in the BtnCreatePizzaClick event and calls PizzaLogic.AddPizzaToOrder. If required fields are missing, the left branch shows a message and sends the user back to fix the form; if the pizza is valid, the right branch uses PizzaDAO to store the order and reset for the next one. The lower steps show the user clicking See Full Order to open FrmOrderDetails and then Save Order, where PizzaDAO writes all pizzas to the file, confirming the complete flow from UI to business layer to data layer.

UML Class Diagram
 
Figure 2: UML Diagram PizzaMaker

This screenshot shows the UML diagram for my FrmPizzaMaker form, which is the main user interface for building pizzas. At the top it lists the key fields, including the shared PizzaLogic object, the current PizzaModel, and all of the controls like the name box, ingredient groups, list box, trackbars, labels, and buttons. The operations section at the bottom outlines how the form behaves, such as enabling the create button, updating the price, resetting the form, and collecting the selected options into a PizzaModel. It also includes the event handlers that respond when I click Create Pizza, Reset, or See Full Order, tying the UI directly into the business logic.


 
Figure 3: UML Diagram For PizzaModel

This screenshot shows the UML diagram for my PizzaModel class, which holds all the details for each custom pizza. It includes the client’s name, selected ingredients, strange add-ons, crust type, sauce and cheese amounts, delivery time, pizza box color, and final price. The PizzaModel constructor at the bottom is used to set up a new pizza with default values when an order starts. Keeping everything in this one model makes it easy for my form, business logic, and file saving code to work with the same pizza data.




Figure 4: Method Of PizzaLogic
 
This screenshot shows my PizzaLogic class handling the rules for adding and saving pizzas. The AddPizzaToOrder method first checks that the name, crust, ingredients, sauce, and cheese are all set the way the guide requires. If anything is missing, it returns false and does not add the pizza. When the pizza is valid, it calls the DAO to store it and returns true along with the updated count. The GetPizzaOrder method gives the full list back to the forms, and WriteOrderToFile passes the order to the DAO to be written out to the text file. This keeps all the validation and order management in the business layer instead of in the UI.

 
Figure 5: Functionality of PizzaMaker App

This screenshot shows my PizzaMaker form in use with a sample custom order filled out. The customer name is entered, several ingredients are selected, and a couple of Strange Add Ons are highlighted to show how flexible the toppings can be. A stuffed crust option is chosen, the sliders are set to higher sauce and cheese levels, and the delivery time has been picked. The large colored box on the right represents the selected pizza box color that will be saved with the order. This screen demonstrates that all main inputs work together before I create and store the pizza.
 
Figure 6: PizzaLogic Methods

This code creates a PizzaLogic class that uses a PizzaDAO object to handle saving orders. The CalculatePrice method starts each pizza at $15.00, then adds $0.50 for each regular ingredient and each strange add-on, and adds $1.00 more if a gluten-free crust is selected. This keeps all pricing rules in the business layer instead of in the form.



Figure 7: Method Of PizzaLogic
 
This screenshot shows my PizzaLogic class handling the rules for adding and saving pizzas. The AddPizzaToOrder method first checks that the name, crust, ingredients, sauce, and cheese are all set the way the guide requires. If anything is missing, it returns false and does not add the pizza. When the pizza is valid, it calls the DAO to store it and returns true along with the updated count. The GetPizzaOrder method gives the full list back to the forms, and WriteOrderToFile passes the order to the DAO to be written out to the text file. This keeps all the validation and order management in the business layer instead of in the UI.


Figure 8: Part PizzaMaker App Running
 This screenshot shows my main PizzaMaker form where the user builds a custom pizza order. There’s a spot at the top for the customer’s name, a list of standard ingredients on the left, and a Strange Add Ons list so I can include fun extra toppings. The Crust group lets the user choose one crust style, and the sliders at the bottom control how much sauce and cheese they want. On the right, the delivery time picker is ready, and there’s a box reserved for showing the selected pizza box color and final price. The Create, Reset, and See Full buttons along the bottom will be used to submit the pizza, clear the form, or view the full order once everything is filled out correctly.

 
Figure 9: Functionality of PizzaMaker App

This screenshot shows my PizzaMaker form in use with a sample custom order filled out. The customer name is entered, several ingredients are selected, and a couple of Strange Add Ons are highlighted to show how flexible the toppings can be. A stuffed crust option is chosen, the sliders are set to higher sauce and cheese levels, and the delivery time has been picked. The large colored box on the right represents the selected pizza box color that will be saved with the order. This screen demonstrates that all main inputs work together before I create and store the pizza.


 
Figure 10: Reset Button Working

This screenshot shows the PizzaMaker form right after using the Reset button. The customer name box is cleared, all ingredient checkboxes are unchecked, Strange Add Ons are unselected, and the sauce and cheese sliders are returned to their starting positions. The crust options are reset, the pizza box color area is blank, and the Pizza Price is set back to the base $15.00. This confirms the reset logic is working by returning the form to a clean, ready-for-a-new-order state without leftover selections from the previous pizza.


Figure 11: Saved Order 
 
This screenshot shows the formatted output for Pizza #1 inside my order details label. It lists the customer’s name, the chosen stuffed crust, and the selected ingredients and strange add-ons in a clean, readable layout. This confirms that my FrmOrderDetails form is correctly pulling data from each PizzaModel and displaying the full pizza information back to the user. It also shows that the data passed from the main PizzaMaker form through the business layer is accurate and organized before I save it to the file.

Figure 12: Order Saved

 
This screenshot shows my Pizza Order Details form confirming that the order was successfully saved. The background window displays the formatted details for Pizza #1, including the customer’s choices from the main form. On top, the “Order saved to file.” message box pops up when I click Save, showing that my PizzaLogic and PizzaDAO classes worked together to write the order to PizzaOrder.txt. This confirms the full flow from building a pizza to saving the order is working correctly.

Figure 13: Error Handling

 
This screenshot shows the validation popup that appears when the user tries to create a pizza without all required choices. The message clearly explains what is missing: a name, a crust selection, at least one ingredient, and sauce and cheese above zero. This helps guide the user to fix their order instead of silently failing. It also proves that my PizzaLogic rules are being enforced before a pizza can be added.






ADD ON



1.	What was challenging?
The most challenging part of this project was getting all the layers to talk to each other the right way without mixing responsibilities. I had to be careful that the FrmPizzaMaker form only handled the UI, while PizzaLogic handled validation and rules, and PizzaDAO dealt with saving the order to the file. Making sure the price, ingredients, crust, and other selections were tracked correctly in the PizzaModel and then showed up right in the Order Details form took a lot of testing. A small mistake in wiring a control or forgetting to update the model would break the flow, so I had to slow down and trace each step.

2.	What did you learn?
I learned how important separation of concerns really is in a real project. Keeping the UI, business logic, and data access in their own classes made it easier to debug and update pieces without breaking everything. I also got more comfortable using models like PizzaModel to hold all the data in one place instead of passing random values around. On top of that, I saw how validation in the business layer can protect the app by making sure a pizza is complete before it gets saved. This helped me better understand layered architecture instead of just hearing about it in theory.

3.	How would you improve on the project?
If I had more time, I would improve the user experience and make the app feel more like a real ordering system. I’d add clearer error messages when something is missing, maybe highlight required fields, and show live updates of the pizza price as the user selects options. I’d also like to display a list of all saved pizzas in a grid so the user can review their whole order at once. Another improvement would be to save the orders in a more flexible format like JSON or a database so it’s easier to load and manage larger orders in the future.

4.	How can you use what you learned on the job?
What I learned in this project connects directly to real-world applications. Most business apps use the same idea of models, logic, and data layers working together behind a user-friendly form or webpage. Understanding how to validate input, avoid hard-coding rules in the UI, and save data cleanly will help me when I work on inventory systems, order forms, scheduling tools, or any internal company software. This project also showed me how important it is to write code that other people can follow, since clear structure and layered design make it easier for a team to update or expand the app later.


