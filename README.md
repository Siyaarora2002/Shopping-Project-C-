# Shopping-Project-C-
a shopping solution that has both client side and server side

Server-side
• A console application should be enough, it prints each response to the output window before sending back to the client-side(s).
• When it first runs, at least five pre-defined products with random quantities (1-3) should be initialized. Which means products should be the same every time the server starts, and the quantities for each product should be randomized.
• At least 3 accounts should be created, each account has an account number and user’s name.
• When the server is active, it should store ordering information to variable(s) (e.g., dictionaries, lists). The server does not have to store the ordering information to the local system, so once you shutdown the server, all information can be disposed.
• Server should send back appropriate response depending on the client’s command. 
• The handler code should be separated from the user interface 
• The server must be able to talk with multiple clients at the same time


Client-side
• The client-side should be a Windows Forms application, with an appropriate user interface. The user can select one product, then make the purchase. (quantity as one)
• When it first opens, a login form should appear with two input fields: hostname/IP and the account number. (localhost as the default value for the hostname)
• If the server cannot be found, the application should display an error message; if the server is active but login failed, a different error message should be displayed.
• Once the user successfully connected to the server, the application should get all products information (names and quantities), then show all information on the GUI.
• The user must be able to gracefully disconnect from the server. Upon disconnecting, the application should close. The application should gracefully disconnect when the form is closed.
• When the user making the purchase, if the product is not available, the application should display an appropriate message stating that the product is no longer available.
• The application should be able to show current purchase orders.
• The server handler code should be separated from the user interface
