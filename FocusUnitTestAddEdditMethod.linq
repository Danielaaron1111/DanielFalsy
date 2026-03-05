<Query Kind="Statements" />

#region Add/Edit Order Tests
if (runAddEditOrderTests)
{
    Console.WriteLine("***************************************************");
    Console.WriteLine("***********  Add/Edit Order Tests (13)  ***********");
    Console.WriteLine("***************************************************");

    OrderView newOrder;

    //rule: Order cannot be null
    newOrder = codeBehind.AddEditOrder(null);
    if (codeBehind.ErrorDetails[0] == "Missing Information: No order was supplied.")
    {
        Util.WithStyle("Pass - Correct Error Message returned when Order supplied is null", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error message or incorrect error message when Order supplied is null", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }

    OrderView orderView = new();

    //rule: Customer & Employee ID must be provided
    newOrder = codeBehind.AddEditOrder(orderView);
    if (codeBehind.ErrorDetails[0] == "Missing Information: Customer is required."
        && codeBehind.ErrorDetails[1] == "Missing Information: Employee is required.")
    {
        Util.WithStyle("Pass - Correct Error Messages returned when Order supplied has no EmployeeID or CustomerID", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error messages or incorrect error messages when Order supplied has no Employee, Customer, or OrderDetails", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }

    orderView.CustomerID = "ALFKI";
    orderView.EmployeeID = 2;

    //rule: Order must have at least one order line
    newOrder = codeBehind.AddEditOrder(orderView);
    if (codeBehind.ErrorDetails[0] == "Missing Information: Order details are required.")
    {
        Util.WithStyle("Pass - Correct Error Message returned when Order supplied has no OrderDetails", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error messages or incorrect error messages when Order supplied has no OrderDetails", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }


    OrderDetailView orderDetailView = new();
    orderView.OrderDetails.Add(orderDetailView);

    //rule: Each order line must have a product
    newOrder = codeBehind.AddEditOrder(orderView);
    if (codeBehind.ErrorDetails[0] == "Missing Information: Missing product ID.")
    {
        Util.WithStyle("Pass - Correct Error Message returned when Order supplied has OrderDetail with no Product ID", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error messages or incorrect error messages when Order supplied has OrderDetail with no Product ID", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }

    orderView.OrderDetails[0].ProductID = 1;
    orderView.OrderDetails[0].UnitPrice = 22.99m;
    orderView.OrderDetails[0].Quantity = 14;
    OrderDetailView secondOrderDetail = orderView.OrderDetails[0];
    orderView.OrderDetails.Add(secondOrderDetail);

    //rule: Product cannot be duplicated in multiple order lines
    newOrder = codeBehind.AddEditOrder(orderView);
    if (codeBehind.ErrorDetails[0] == "Invalid Data: Product Chai can only be added to the order lines once.")
    {
        Util.WithStyle("Pass - Correct Error Message returned when Order supplied has duplicate OrderDetails", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error messages or incorrect error messages when Order supplied has duplicate OrderDetails", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }

    orderView = new();
    orderView.CustomerID = "ALFKI";
    orderView.EmployeeID = 2;
    orderView.OrderDetails.Add(orderDetailView);
    orderView.OrderDetails[0].ProductID = 1;
    orderView.OrderDetails[0].UnitPrice = -9.99m;
    orderView.OrderDetails[0].Quantity = 2;

    //rule: Unit price cannot be negative
    newOrder = codeBehind.AddEditOrder(orderView);
    if (codeBehind.ErrorDetails[0] == "Invalid Data: Product Chai has a price that is less than zero.")
    {
        Util.WithStyle("Pass - Correct Error Message returned when OrderDetail has negative price", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error messages or incorrect error messages when OrderDetail has negative price", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }

    orderView.OrderDetails[0].UnitPrice = 25.00m;
    orderView.OrderDetails[0].Quantity = 0;

    //rule: Quantity must be at least one
    newOrder = codeBehind.AddEditOrder(orderView);
    if (codeBehind.ErrorDetails[0] == "Invalid Data: Product Chai has a quantity that is less than one.")
    {
        Util.WithStyle("Pass - Correct Error Message returned when OrderDetail has a quantity of 0", "color:green").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail - No error messages or incorrect error messages when OrderDetail has a quantity of 0", "color:red; font-weight: bold").Dump();
        if (verbose)
            codeBehind.ErrorDetails.Dump();
    }

    orderView = new()
    {
        CustomerID = "ALFKI",
        EmployeeID = 2
    };
    orderView.Freight = 12.55m;
    orderView.RequiredDate = DateTime.Now.AddDays(5);
    orderView.ShippedDate = DateTime.Now.AddDays(2);
    orderView.ShipAddress = "Side of the Road";
    orderView.ShipCity = "Nowhere";
    orderView.ShipCountry = "Canada";
    orderView.ShipName = "UPS";
    orderView.ShipPostalCode = "T5Q1X2";
    orderView.ShipRegion = "Up There";
    orderView.ShipVia = 2;

    orderDetailView = new();
    orderDetailView.ProductID = 4;  // Chef Anton's Cajun Seasoning
    orderDetailView.UnitPrice = 19.00m;
    orderDetailView.Quantity = 17;
    orderDetailView.Discount = 0.13f;
    orderDetailView.RemoveFromViewFlag = false;
    orderView.OrderDetails.Add(orderDetailView);

    orderDetailView = new();
    orderDetailView.ProductID = 5;  // Chef Anton's Gumbo Mix
    orderDetailView.UnitPrice = 21.35m;
    orderDetailView.Quantity = 112;
    orderDetailView.Discount = 0f;
    orderDetailView.RemoveFromViewFlag = false;
    orderView.OrderDetails.Add(orderDetailView);

    newOrder = codeBehind.AddEditOrder(orderView);

    //rule: Order must have a valid OrderID
    if (newOrder.OrderID != 0)
        Util.WithStyle("Pass - New Order has a valid OrderID", "color:green").Dump();
    else
        Util.WithStyle("Fail - New Order does not have a valid OrderID", "color:red; font-weight: bold").Dump();
    if (verbose)
        newOrder.Dump();

    //rule: Order date must be created for new orders only.
    if (DateOnly.FromDateTime(newOrder.OrderDate.Value) == DateOnly.FromDateTime(DateTime.Now))
        Util.WithStyle("Pass - New Order was provided a valid Date", "color:green").Dump();
    else
        Util.WithStyle("Fail - New Order was not given today's date", "color:red; font-weight: bold").Dump();
    if (verbose)
        newOrder.Dump();

    //rule: Order must have the correct data added for it (Customer, Employee, etc.)
    if (newOrder.OrderID != 0
        && newOrder.CustomerID == "ALFKI"
        && newOrder.CompanyName == "Alfreds Futterkiste"
        && newOrder.EmployeeID == 2
        && newOrder.EmployeeName == "Andrew Fuller"
        && DateOnly.FromDateTime(newOrder.OrderDate.Value) == DateOnly.FromDateTime(DateTime.Now)
        && DateOnly.FromDateTime(newOrder.RequiredDate.Value) == DateOnly.FromDateTime(DateTime.Now.AddDays(5))
        && DateOnly.FromDateTime(newOrder.ShippedDate.Value) == DateOnly.FromDateTime(DateTime.Now.AddDays(2))
        && newOrder.ShipVia == 2
        && newOrder.Freight == 12.55m
        && newOrder.ShipName == "UPS"
        && newOrder.ShipAddress == "Side of the Road"
        && newOrder.ShipCity == "Nowhere"
        && newOrder.ShipRegion == "Up There"
        && newOrder.ShipPostalCode == "T5Q1X2"
        && newOrder.ShipCountry == "Canada"
        && newOrder.SubTotal == 2714.20m
        && newOrder.Tax == 135.71m
        && newOrder.RemoveFromViewFlag == false
        && newOrder.OrderDetails.Count == 2)
    {
        Util.WithStyle("Pass 1/2 - New Order added with all correct information", "color:green").Dump();
    }
    else
    {
        Util.WithStyle("Fail 1/2 - New Order did not add with all the correct information", "color:red; font-weight: bold").Dump();
    }
    if (verbose)
        newOrder.Dump();

    if (newOrder.OrderDetails[0].OrderDetailID != 0
        && newOrder.OrderDetails[0].OrderID == newOrder.OrderID
        && newOrder.OrderDetails[0].ProductID == 4
        && newOrder.OrderDetails[0].Name == "Chef Anton's Cajun Seasoning"
        && newOrder.OrderDetails[0].UnitPrice == 19.0000m
        && newOrder.OrderDetails[0].Quantity == 17
        && newOrder.OrderDetails[0].Discount == 0.13f
        && newOrder.OrderDetails[0].UnitsInStock == 983
        && newOrder.OrderDetails[0].RemoveFromViewFlag == false
        && newOrder.OrderDetails[1].OrderDetailID != 0
        && newOrder.OrderDetails[1].OrderID == newOrder.OrderID
        && newOrder.OrderDetails[1].ProductID == 5
        && newOrder.OrderDetails[1].Name == "Chef Anton's Gumbo Mix"
        && newOrder.OrderDetails[1].UnitPrice == 21.3500m
        && newOrder.OrderDetails[1].Quantity == 112
        && newOrder.OrderDetails[1].Discount == 0.00f
        && newOrder.OrderDetails[1].UnitsInStock == 888
        && newOrder.OrderDetails[1].RemoveFromViewFlag == false)
    {
        Util.WithStyle("Pass 2/2 - New Order Added with correct Order Detail information", "color:green").Dump();
        if (verbose)
            newOrder.OrderDetails.Dump();
    }
    else
    {
        Util.WithStyle("Fail 2/2 - New Order did not add with the correct Order Detail information", "color:red; font-weight: bold").Dump();
        if (verbose)
            newOrder.OrderDetails.Dump();
    }

    newOrder.EmployeeID = 7;
    orderDetailView = new();
    orderDetailView.ProductID = 6;  // Grandma's Boysenberry Spread
    orderDetailView.UnitPrice = 24.50m;
    orderDetailView.Quantity = 291;
    orderDetailView.Discount = 0.02f;
    orderDetailView.RemoveFromViewFlag = false;
    newOrder.OrderDetails.Add(orderDetailView);

    OrderView editOrder;
    editOrder = codeBehind.AddEditOrder(newOrder);

    //rule: Existing order data must be updated correctly
    if (editOrder.EmployeeID == 7
        && editOrder.EmployeeName == "Robert King"
        && editOrder.OrderDetails.Count == 3
        && editOrder.OrderDetails[2].OrderDetailID != 0
        && editOrder.OrderDetails[2].OrderID == editOrder.OrderID
        && editOrder.OrderDetails[2].ProductID == 6
        && editOrder.OrderDetails[2].Name == "Grandma's Boysenberry Spread"
        && editOrder.OrderDetails[2].UnitPrice == 24.5000m
        && editOrder.OrderDetails[2].Quantity == 291
        && editOrder.OrderDetails[2].Discount == 0.02f
        && editOrder.OrderDetails[2].UnitsInStock == 709
        && editOrder.OrderDetails[2].RemoveFromViewFlag == false)
    {
        Util.WithStyle("Pass - Edit Order correctly updated", "color:green").Dump();
    }
    else
    {
        Util.WithStyle("Fail - Edit Order not correctly updated", "color:red; font-weight: bold").Dump();
    }
    if (verbose)
        editOrder.Dump();

    //rule: Updated order must retain correct subtotal and tax calculations
    if (editOrder.SubTotal == 9843.7000m
        && editOrder.Tax == 492.185000m)
        Util.WithStyle("Pass - Edit Order Subtotal and Tax correctly updated", "color:green").Dump();
    else
        Util.WithStyle("Fail - Edit Order Subtotal and Tax not correctly updated", "color:red; font-weight: bold").Dump();
    if (verbose)
        editOrder.Dump();

    //rule: Units in stock must be updated correctly
    if (editOrder.OrderDetails[0].UnitsInStock == 983
        && editOrder.OrderDetails[1].UnitsInStock == 888
        && editOrder.OrderDetails[2].UnitsInStock == 709)
        Util.WithStyle("Pass - Edit Order Inventory Levels correctly updated", "color:green").Dump();
    else
        Util.WithStyle("Fail - Edit Order Inventory Levels not correctly updated", "color:red; font-weight: bold").Dump();
    if (verbose)
        editOrder.Dump();
}
	#endregion
}