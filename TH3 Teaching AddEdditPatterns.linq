<Query Kind="Program">
  <Connection>
    <ID>4a64093b-073e-4c04-880b-df32840a19fb</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DisplayName>WestWind-2025-Jan-TH3-EFCORE</DisplayName>
    <Database>WestWind-2025-Jan-TH3</Database>
    <Server>.</Server>
    <UserName>DANNELPC/daran</UserName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <NuGetReference>BYSResults</NuGetReference>
  <RuntimeVersion>10.0</RuntimeVersion>
</Query>

// 	Lightweight result types for explicit success/failure 
//	 handling in .NET applications.
using BYSResults;

//NOTE: Remember to Change the Connection

void Main()
{

    
	#region Setup (DO NOT TOUCH)
	CodeBehind codeBehind = new CodeBehind(this); // “this” is LINQPad’s auto Context
	ResetInventory();
	#endregion
	
	#region Test Variables
	//Change to true to see resulting records.
	bool verbose = false;
	//Change any below to true once you have implemented the methods to run the tests
	bool runEmployeeTests = false;
	bool runProductTests = false;
	bool runGetOrderTests = false;
	bool runAddEditOrderTests = true;
	#endregion
	
	
	//DO NOT CHANGE ANY TEST OR YOUR MARK WILL BE 0
	//Reference the error Messages in the tests in order to have the tests pass
	#region GetEmployee Tests
	if(runEmployeeTests)
	{
		Console.WriteLine("*********************************************");
		Console.WriteLine("***********  Employee Tests (6)  ************");
		Console.WriteLine("*********************************************");

		codeBehind.GetEmployees("", "");
		if (codeBehind.ErrorDetails[0] == "Missing Information: A last name or phone number is required.")
		{
			Util.WithStyle("Pass - Empty Last Name and Phone", "color:green").Dump();
		}
		else
		{
			Util.WithStyle("Fail - No Error or incorrect error for Empty Last Name and Phone", "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.ErrorDetails.Dump();

		codeBehind.GetEmployees("", "780");
		if (codeBehind.ErrorDetails[0] == "No Employees: No employees were found.")
		{
			Util.WithStyle("Pass - Partial Phone Number Returned No Matches", "color:green").Dump();
		}
		else
		{
			Util.WithStyle("Fail - No Error or incorrect error for partial phone number search", "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.ErrorDetails.Dump();

		codeBehind.GetEmployees("", "(206) 555-1189");
		if (codeBehind.Employees.Count == 1 && codeBehind.Employees[0].EmployeeID == 8)
		{
			Util.WithStyle("Pass - Exact Phone Number Returned Correct Match", "color:green").Dump();
		}
		else
		{
			var errorMsg = "";
			if (codeBehind.Employees.Count > 1)
				errorMsg = "Fail - Exact Phone Number returned more than one match";
			else if (codeBehind.Employees.Count < 1)
				errorMsg = "Fail - Exact Phone Number did not return the expected one match";
			else if (codeBehind.Employees[0].EmployeeID != 8)
				errorMsg = "Fail - Exact Phone Number did not return the expected employee";

			Util.WithStyle(errorMsg, "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.Employees.Dump();


		codeBehind.GetEmployees("a", "");
		if (codeBehind.Employees.Count == 4 &&
				codeBehind.Employees[0].FullName == "Steven Buchanan" &&
				codeBehind.Employees[1].FullName == "Laura Callahan" &&
				codeBehind.Employees[2].FullName == "Margaret Peacock" &&
				codeBehind.Employees[3].FullName == "Michael Suyama")
		{
			Util.WithStyle("Pass - Partial Last Name Search 'a' Returned the 4 correct Employees", "color:green").Dump();
		}
		else
		{
			string errorMsg = "";
			if (codeBehind.Employees.Count > 4)
				errorMsg = $"Fail - Partial Last Name Search 'a' returned {codeBehind.Employees.Count()} employees when it should return 4.";
			else if (codeBehind.Employees[0].FullName != "Steven Buchanan" &&
						codeBehind.Employees[1].FullName != "Laura Callahan" &&
						codeBehind.Employees[2].FullName != "Margaret Peacock" &&
						codeBehind.Employees[3].FullName != "Michael Suyama")
				errorMsg = "Fail - Partial Last Name Search 'a' returned the incorrect Employees.";
			
			Util.WithStyle(errorMsg, "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.Employees.Dump();

		codeBehind.GetEmployees("", "(71) 555-4444");
		if (codeBehind.Employees[0].EmployeeID == 9
			&& codeBehind.Employees[0].Title == "Sales Representative"
			&& codeBehind.Employees[0].FullName == "Anne Dodsworth"
			&& codeBehind.Employees[0].Phone == "(71) 555-4444"
			&& codeBehind.Employees[0].Country == "UK"
			&& codeBehind.Employees[0].ReportTo == "Steven Buchanan"
			&& codeBehind.Employees[0].RemoveFromViewFlag == false
			&& codeBehind.Employees[0].SalesTerritories.Count == 7)
		{
			Util.WithStyle("Pass - Expected Employee 'Anne Dodsworth' returned with correct values", "color:green").Dump();
		}
		else
		{
			var errorMsg = "";
			if (codeBehind.Employees[0].EmployeeID != 9)
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' employee ID incorrectly returned";
			else if (codeBehind.Employees[0].FullName != "Anne Dodsworth")
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' full name incorrectly returned";
			else if (codeBehind.Employees[0].Phone != "(71) 555-4444")
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' phone number incorrectly returned";
			else if (codeBehind.Employees[0].Country != "UK")
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' country incorrectly returned";
			else if (codeBehind.Employees[0].ReportTo != "Steven Buchanan")
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' reports to incorrectly returned";
			else if (codeBehind.Employees[0].RemoveFromViewFlag != false)
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' remove from view flag incorrectly returned";
			else if (codeBehind.Employees[0].SalesTerritories.Count != 7)
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' number of sale territories incorrectly returned";

			Util.WithStyle(errorMsg, "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.Employees.Dump();

		codeBehind.GetEmployees("", "(71) 555-4444");
		if (codeBehind.Employees[0].SalesTerritories[0].TerritoryDescription.Trim() == "Bloomfield Hills"
			&& codeBehind.Employees[0].SalesTerritories[1].TerritoryDescription.Trim() == "Hollis"
			&& codeBehind.Employees[0].SalesTerritories[2].TerritoryDescription.Trim() == "Minneapolis"
			&& codeBehind.Employees[0].SalesTerritories[3].TerritoryDescription.Trim() == "Portsmouth"
			&& codeBehind.Employees[0].SalesTerritories[4].TerritoryDescription.Trim() == "Roseville"
			&& codeBehind.Employees[0].SalesTerritories[5].TerritoryDescription.Trim() == "Southfield"
			&& codeBehind.Employees[0].SalesTerritories[6].TerritoryDescription.Trim() == "Troy")
		{
			Util.WithStyle("Pass - Expected Employee 'Anne Dodsworth' returned with correct Territories in the correct order", "color:green").Dump();
		}
		else
		{
			var errorMsg = "";
			if (codeBehind.Employees[0].SalesTerritories.Count != 7)
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' sales territories returned the incorrect amount (7 expected)";
			else
				errorMsg = "Fail - Expected Employee 'Anne Dodsworth' sales territories were not returned in the correct order";

			Util.WithStyle(errorMsg, "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.Employees[0].SalesTerritories.Dump();
	}
	#endregion

	#region Get Product Tests
	if (runProductTests)
	{
		Console.WriteLine("******************************************");
		Console.WriteLine("***********  Product Tests (3)  ***********");
		Console.WriteLine("******************************************");

		codeBehind.GetProduct(0);
		if (codeBehind.ErrorDetails[0] == "Missing Information: Please provide a product id.")
		{
			Util.WithStyle("Pass - Product ID '0' not accepted", "color:green").Dump();
		}
		else
		{
			Util.WithStyle("Fail - Incorrect Error Message or product found when Product ID '0' given", "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.ErrorDetails.Dump();

		codeBehind.GetProduct(3);
		if (codeBehind.ErrorDetails[0] == "No Product: No product was found with ID: 3.")
		{
			Util.WithStyle("Pass - Product ID '3' correctly returns no results", "color:green").Dump();
		}
		else
		{
			Util.WithStyle("Fail - Incorrect Error Message or product found when Product ID '3' given (Note: Product is removed from view)", "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.ErrorDetails.Dump();

		codeBehind.GetProduct(1);
		if (codeBehind.ErrorDetails.Count == 0
				&& codeBehind.Product.ProductID == 1
				&& codeBehind.Product.ProductName == "Chai"
				&& codeBehind.Product.SupplierID == 1
				&& codeBehind.Product.CategoryID == 1
				&& codeBehind.Product.QuantityPerUnit == "10 boxes x 20 bags"
				&& codeBehind.Product.UnitPrice == 18.0000m
				&& codeBehind.Product.UnitsInStock == 1000
				&& codeBehind.Product.UnitsOnOrder == 0
				&& codeBehind.Product.ReorderLevel == 10
				&& codeBehind.Product.Discontinued == false
				&& codeBehind.Product.RemoveFromViewFlag == false)
		{
			Util.WithStyle("Pass - Product ID '1' correctly returns with correct values", "color:green").Dump();
		}
		else
		{
			var errorMsg = "";
			if (codeBehind.Product.ProductID != 1)
				errorMsg = "Fail - Expected Product product ID incorrectly returned";
			else if (codeBehind.Product.ProductName != "Chai")
				errorMsg = "Fail - Expected Product product name incorrectly returned";
			else if (codeBehind.Product.SupplierID != 1)
				errorMsg = "Fail - Expected Product SupplierID incorrectly returned";
			else if (codeBehind.Product.CategoryID != 1)
				errorMsg = "Fail - Expected Product CategoryID incorrectly returned";
			else if (codeBehind.Product.QuantityPerUnit != "10 boxes x 20 bags")
				errorMsg = "Fail - Expected Product Quantity Per Unit incorrectly returned";
			else if (codeBehind.Product.UnitPrice != 18.0000m)
				errorMsg = "Fail - Expected Product Unit Price incorrectly returned";
			else if (codeBehind.Product.UnitsInStock != 1000)
				errorMsg = "Fail - Expected Product Units In Stock incorrectly returned";
			else if (codeBehind.Product.UnitsOnOrder != 0)
				errorMsg = "Fail - Expected Product Units On Order incorrectly returned";
			else if (codeBehind.Product.ReorderLevel != 10)
				errorMsg = "Fail - Expected Product Reorder Level incorrectly returned";
			else if (codeBehind.Product.Discontinued != false)
				errorMsg = "Fail - Expected Product Discontinued flag incorrectly returned";
			else if (codeBehind.Product.RemoveFromViewFlag != false)
				errorMsg = "Fail - Expected Product Remove From View Flag incorrectly returned";
			else if(codeBehind.ErrorDetails.Count > 0)
				errorMsg = "Fail - Expected Product '1' returned an error message when product should have been returned";
	
			Util.WithStyle(errorMsg, "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.Product.Dump();
	}
	#endregion

    #region Get Order Tests
    if (runGetOrderTests)
    {
        Console.WriteLine("*********************************************");
        Console.WriteLine("***********  Get Order Tests (4)  ***********");
        Console.WriteLine("*********************************************");

        codeBehind.GetOrder(0);
        if (codeBehind.ErrorDetails[0] == "Missing Information: Please provide a invoice id.")
        {
            Util.WithStyle("Pass - Order ID '0' not accepted", "color:green").Dump();
        }
        else
        {
            Util.WithStyle("Fail - Incorrect Error Message or order found when Order ID '0' given", "color:red; font-weight: bold").Dump();
        }
        if (verbose)
            codeBehind.ErrorDetails.Dump();

        codeBehind.GetOrder(10249);
        if (codeBehind.ErrorDetails[0] == "No Order: No order was found with ID: 10249.")
        {
            Util.WithStyle("Pass - Order ID '10249' correctly returns no results", "color:green").Dump();
        }
        else
        {
            Util.WithStyle("Fail - Incorrect Error Message or order found when Order ID '10249' given (Note: Order is removed from view)", "color:red; font-weight: bold").Dump();
        }
        if (verbose)
            codeBehind.ErrorDetails.Dump();

        codeBehind.GetOrder(10248);
        if (codeBehind.Order.OrderID == 10248
            && codeBehind.Order.CustomerID == "VINET"
            && codeBehind.Order.EmployeeID == 5
            && codeBehind.Order.OrderDate == new DateTime(2021, 7, 4)
            && codeBehind.Order.RequiredDate == new DateTime(2021, 8, 1)
            && codeBehind.Order.ShippedDate == new DateTime(2021, 7, 16)
            && codeBehind.Order.ShipVia == 3
            && codeBehind.Order.Freight == 32.38m
            && codeBehind.Order.ShipName == "Vins et alcools Chevalier"
            && codeBehind.Order.ShipAddress == "59 rue de l'Abbaye"
            && codeBehind.Order.ShipCity == "Reims"
            && codeBehind.Order.ShipRegion == null
            && codeBehind.Order.ShipPostalCode == "51100"
            && codeBehind.Order.ShipCountry == "France"
            && codeBehind.Order.SubTotal == 440.00m
            && codeBehind.Order.Tax == 22.00m
            && codeBehind.Order.RemoveFromViewFlag == false)
        {
            Util.WithStyle("Pass - Order ID '10248' correctly returns with correct values", "color:green").Dump();
        }
        else
        {
            var errorMsg = "";
            if (codeBehind.Order.OrderID != 10248)
                errorMsg = "Fail - Expected Order OrderID incorrectly returned";
            else if (codeBehind.Order.CustomerID != "VINET")
                errorMsg = "Fail - Expected Order CustomerID incorrectly returned";
            else if (codeBehind.Order.EmployeeID != 5)
                errorMsg = "Fail - Expected Order EmployeeID incorrectly returned";
            else if (codeBehind.Order.OrderDate != new DateTime(2021, 7, 4))
                errorMsg = "Fail - Expected Order Order Date incorrectly returned";
            else if (codeBehind.Order.RequiredDate != new DateTime(2021, 8, 1))
                errorMsg = "Fail - Expected Order Required Date incorrectly returned";
            else if (codeBehind.Order.ShippedDate != new DateTime(2021, 7, 16))
                errorMsg = "Fail - Expected Order Shipped Date incorrectly returned";
            else if (codeBehind.Order.ShipVia != 3)
                errorMsg = "Fail - Expected Order Ship Via incorrectly returned";
            else if (codeBehind.Order.Freight != 32.38m)
                errorMsg = "Fail - Expected Order Freight incorrectly returned";
            else if (codeBehind.Order.ShipName != "Vins et alcools Chevalier")
                errorMsg = "Fail - Expected Order Ship Name incorrectly returned";
            else if (codeBehind.Order.ShipAddress != "59 rue de l'Abbaye")
                errorMsg = "Fail - Expected Order Ship Address incorrectly returned";
            else if (codeBehind.Order.ShipCity != "Reims")
                errorMsg = "Fail - Expected Order Ship City incorrectly returned";
            else if (codeBehind.Order.ShipRegion != null)
                errorMsg = "Fail - Expected Order Ship Region incorrectly returned";
            else if (codeBehind.Order.ShipPostalCode != "51100")
				errorMsg = "Fail - Expected Order Ship Postal Code incorrectly returned";
			else if (codeBehind.Order.ShipCountry != "France")
				errorMsg = "Fail - Expected Order Ship Country incorrectly returned";
			else if (codeBehind.Order.SubTotal != 440.00m)
				errorMsg = "Fail - Expected Order SubTotal incorrectly returned";
			else if (codeBehind.Order.Tax != 22.00m)
				errorMsg = "Fail - Expected Order Tax incorrectly returned";
			else if (codeBehind.Order.RemoveFromViewFlag != false)
				errorMsg = "Fail - Expected Order Remove From View Flag incorrectly returned";
			else if (codeBehind.ErrorDetails.Count > 0)
				errorMsg = "Fail - Expected Order '10248' returned an error message when order should have been returned";

			Util.WithStyle(errorMsg, "color:red; font-weight: bold").Dump();
		}
		if (verbose)
			codeBehind.Order.Dump();

		if(codeBehind.Order.OrderDetails.Count != 3)
		{
			Util.WithStyle("Fail - Order '10248' returned the incorrect number of order details", "color:red; font-weight: bold").Dump();
		}
		else if (codeBehind.Order.OrderDetails[0].OrderDetailID != 3
			&& codeBehind.Order.OrderDetails[1].OrderDetailID != 1
			&& codeBehind.Order.OrderDetails[2].OrderDetailID != 2)
		{
			Util.WithStyle("Fail - Order '10248' returned the incorrect order detail records", "color:red; font-weight: bold").Dump();
		}
		else
		{
			Util.WithStyle("Pass - Order '10248' returned the correct number of order detail records and the correct records", "color:green").Dump();
		}
		if (verbose)
			codeBehind.Order.OrderDetails.Dump();
	}
	#endregion

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

#region Code Behind Methods (DO NOT EDIT)
public class CodeBehind(TypedDataContext context)
{
	// NOTE: DO NOT CHANGE THIS CODEBEHIND
	#region Supporting Members (Do not modify)
	// exposes the collected error details
	public List<string> ErrorDetails => errorDetails;

	private readonly OrderService OrderService = new OrderService(context);
	private readonly EmployeeService EmployeeService = new EmployeeService(context);
	private readonly ProductService ProductService = new ProductService(context);
	#endregion

	#region Fields from Blazor Page Code-Behind
	// feedback message to display to the user.
	private string feedbackMessage = string.Empty;
	// collected error details.
	private List<string> errorDetails = new();
	// general error message.
	private string errorMessage = string.Empty;
	#endregion

	#region Fields to hold resulting data (DO NOT MAKE YOUR OWN)
	public List<EmployeeView> Employees = [];
	public ProductView Product = new();
	public OrderView Order = new();
	#endregion

	public void GetEmployees(string lastName, string phone)
	{
		errorDetails.Clear();
		errorMessage = string.Empty;
		feedbackMessage = string.Empty;

		try
		{
			var result = EmployeeService.GetEmployees(lastName, phone);
			if (result.IsSuccess)
				Employees = result.Value;
			else
				errorDetails = GetErrorMessages(result.Errors.ToList());
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
		}

	}
	
	public void GetProduct(int productID)
	{
		errorDetails.Clear();
		errorMessage = string.Empty;
		feedbackMessage = string.Empty;

		try
		{
			var result = ProductService.GetProduct(productID);
			if (result.IsSuccess)
				Product = result.Value;
			else
				errorDetails = GetErrorMessages(result.Errors.ToList());
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
		}
	}

	public void GetOrder(int orderID)
	{
		errorDetails.Clear();
		errorMessage = string.Empty;
		feedbackMessage = string.Empty;

		try
		{
			var result = OrderService.GetOrder(orderID);
			if (result.IsSuccess)
				Order = result.Value;
			else
				errorDetails = GetErrorMessages(result.Errors.ToList());
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
		}
	}

	public OrderView AddEditOrder(OrderView orderView)
	{
		errorDetails.Clear();
		errorMessage = string.Empty;
		feedbackMessage = String.Empty;

		try
		{
			var result = OrderService.AddEditOrder(orderView);
			if (result.IsSuccess)
				return result.Value;
			else
			{
				errorDetails = GetErrorMessages(result.Errors.ToList());
				return null;
			}
				
		}
		catch (Exception ex)
		{
			errorMessage = ex.Message;
			return null;
		}
	}
}
#endregion

#region Take Home #3 Methods (EDIT THIS PORTION OF THE FILE)
public class EmployeeService
{
	#region Data Context Setup
	// The LINQPad auto-generated TypedDataContext instance used to query and manipulate data.
	private readonly TypedDataContext _context;

	// The TypedDataContext provided by LINQPad for database access.
	// Store the injected context for use in library methods
	// NOTE:  This constructor is simular to the constuctor in your service
	public EmployeeService(TypedDataContext context)
	{
		_context = context
					?? throw new ArgumentNullException(nameof(context));
	}
    #endregion
    // Add Code for the following method:
    // GetEmployees

    public Result<List<EmployeeView>> GetEmployees(string lastName, string phone)
    {
        var result = new Result<List<EmployeeView>>();
        //Busniness rules (I foger to add)
        //rules: at least on input is required (and return error message)
        if (string.IsNullOrWhiteSpace(lastName) && string.IsNullOrWhiteSpace(phone))
        {
            result.AddError(new Error("Missing Information", "A last name or phone number is required.")); // i modify this because i want it to run it on blazor 
            //exit early nothing to search with
            return result;
        }
        
        
        //Busines rules phone number must be an exact match it cannot be a partial match
        // only active employees are retrieved.
        var employees = _context.Employees
        
            .Where(e => (string.IsNullOrWhiteSpace(lastName) //if lastname is empty 
             || e.LastName.ToUpper().Contains(lastName.ToUpper())) && (string.IsNullOrWhiteSpace(phone) || e.HomePhone == phone)
            && !e.RemoveFromViewFlag //same that se it out to false. is not delted
            )
            //Represents employee details. Each employee may have multiple assigned territories. Order By lastname
            
            .OrderBy(e => e.LastName)
            //map() only fieldsneeded for the view
            .Select(e => new EmployeeView
            {
                EmployeeID = e.EmployeeID,
                Title = e.Title,
                FullName = e.FirstName + " " + e.LastName,
                Phone = e.HomePhone,
                Country = e.Country,
                ReportTo = e.ReportsToEmployee.FirstName + " " + e.ReportsToEmployee.LastName, //i could add string.Empty but this pass so its ok !=null ? : string.Empty (ask james)
                RemoveFromViewFlag = e.RemoveFromViewFlag,
                //using navigation properties and matching the picture from the pdf
                SalesTerritories = e.EmployeeTerritories.Select(t => new TerritoryView
                {
                    TerritoryID = t.TerritoryID,
                    TerritoryDescription = t.Territory.TerritoryDescription,
                    RegionDescription = t.Territory.Region.RegionDescription,
                    RemoveFromViewFlag = t.RemoveFromViewFlag
                })
                .OrderBy(t => t.TerritoryDescription)
                .ToList()
            })
            .ToList();
            //.Dump(); activate verbose insetad of do this 
            // if no employees were found, return an error
       if (employees == null || employees.Count == 0)
       {
           result.AddError(new Error("No Employees", "No employees were found."));
            // exit early - no results to return
           return result;
       }
       // return the result with the list of employees
        return result.WithValue(employees);
    }
  
}

public class ProductService
{
	#region Data Context Setup
	// The LINQPad auto-generated TypedDataContext instance used to query and manipulate data.
	private readonly TypedDataContext _context;

	// The TypedDataContext provided by LINQPad for database access.
	// Store the injected context for use in library methods
	// NOTE:  This constructor is simular to the constuctor in your service
	public ProductService(TypedDataContext context)
	{
		_context = context
					?? throw new ArgumentNullException(nameof(context));
	}
    #endregion
    // Add Code for the following method:
    // GetProduct

    public Result<ProductView> GetProduct(int productID)
    {
        var result = new Result<ProductView>();
        //(readme get product part 1 )
        //product ID is required if is not valid and error (i will copy the exact error from the unit test ) is provided
        // rule: productID must be valid (greater than zero)
        if (productID <= 0)
        {
            result.AddError(new Error("Missing Information: Please provide a product id."));
            return result;
        }
        //return result;

         //Now i will query the DB to get only actives products retrieved (readme get product method part 2 )
         //Searching my 
         var product = _context.Products
         .Where(p => p.ProductID == productID && !p.RemoveFromViewFlag)
         .Select(p => new ProductView
          {
                    ProductID = p.ProductID,
                    ProductName = p.ProductName,
                    
                    SupplierID = p.SupplierID, //coascaling operator because in the DB SupplierdID is (int32?) HOWEVERRRRRRR IF I WRITE "?" OM MY VIEW MODEL I DONT NEED THE COALESCALING STUF CATCH ITTTTTTT
                    CategoryID = p.CategoryID ?? 0, //same 
                    QuantityPerUnit = p.QuantityPerUnit, // string 
                    UnitPrice = p.UnitPrice ?? 0, // decimal nullable ??
                    UnitsInStock = p.UnitsInStock ?? 0, // int16? 
                    UnitsOnOrder = p.UnitsOnOrder ?? 0, // int 16?
                    ReorderLevel = p.ReorderLevel ?? 0, // int16?
                    Discontinued = p.Discontinued, // boolean one or another 
                    RemoveFromViewFlag  = p.RemoveFromViewFlag
         }).FirstOrDefault();
        
        //no product
        if (product == null)
        {
            result.AddError(new Error("No Product", $"No product was found with ID: {productID}."));
            return result;
        }
        return result.WithValue(product);
          
    }

}
public class OrderService
{
    #region Data Context Setup
    // The LINQPad auto-generated TypedDataContext instance used to query and manipulate data.
    private readonly TypedDataContext _context;

    // The TypedDataContext provided by LINQPad for database access.
    // Store the injected context for use in library methods
    // NOTE:  This constructor is simular to the constuctor in your service
    public OrderService(TypedDataContext context)
    {
        _context = context
                    ?? throw new ArgumentNullException(nameof(context));
    }
    #endregion

    // Add Code for the following methods:
    // GetOrder
    // AddEditOrder
    public Result<OrderView> GetOrder(int orderID)
    {
        var result = new Result<OrderView>();
        if (orderID <= 0)
        {
            result.AddError(new Error("Missing Information", "Please provide a invoice id."));
            return result;
        }

        //return result;

        //query to match the pdf and 
        var order = _context.Orders // only active ones in the . where 
        .Where(o => o.OrderID == orderID && !o.RemoveFromViewFlag)
        .Select(o => new OrderView
        {
            OrderID = o.OrderID,
            CustomerID = o.CustomerID,
            CompanyName = o.Customer.CompanyName,
            EmployeeID = o.EmployeeID ?? 0,
            EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName,
            OrderDate = o.OrderDate,
            RequiredDate = o.RequiredDate,
            ShippedDate = o.ShippedDate,
            ShipVia = o.ShipVia ?? 0,
            Freight = o.Freight ?? 0,
            ShipName = o.ShipName,
            ShipAddress = o.ShipAddress,
            ShipCity = o.ShipCity,
            ShipRegion = o.ShipRegion,
            ShipPostalCode = o.ShipPostalCode,
            ShipCountry = o.ShipCountry,
            // this parenthesis was subjested byh linqpad : is squiggggle
            // logic only active order details !od.RemoveFromViewFlag,
            //orderbyname (just in case) 

            OrderDetails = o.OrderDetails //(List<OrderDetailView>)
                                          //.Where(od => !od.RemoveFromViewFlag) // this could be at the end 
                                          //.OrderBy(od => od.Product.ProductName) // this could be at the end but it doesnt really matter because im using a new placeholder od.
                                          //james always write these stuff at the end but i always do at the beggining 
                            .Select(od => new OrderDetailView
                            {
                                OrderDetailID = od.OrderDetailID,
                                OrderID = od.OrderID,
                                ProductID = od.ProductID,
                                Name = od.Product.ProductName,
                                UnitPrice = od.UnitPrice,
                                Quantity = od.Quantity,
                                Discount = od.Discount,
                                UnitsInStock = od.Product.UnitsInStock ?? 0,
                                RemoveFromViewFlag = od.RemoveFromViewFlag
                            })
                            .Where(od => !od.RemoveFromViewFlag) // JT METHOD
                            .OrderBy(od => od.Name) //JT METHOD
                            .ToList(),
            //The question is how to get the subtotal 
            // sub total is the sum of price * quantity * (1 - discount) Discount  in (decimal) always
            // SubTotal = sum of (price * qty * (1 - discount))
            SubTotal = o.OrderDetails
                                .Where(od => !od.RemoveFromViewFlag)
                                .Sum(od => od.UnitPrice * od.Quantity),

            // Tax = 5% of subtotal
            Tax = o.OrderDetails
                                .Where(od => !od.RemoveFromViewFlag)
                                .Sum(od => od.UnitPrice * od.Quantity) * 0.05m,
            RemoveFromViewFlag = o.RemoveFromViewFlag,
        }).FirstOrDefault();

        //If no order found
        if (order == null)
        {
            result.AddError(new Error("No Order", $"No order was found with ID: {orderID}.")); //inter$$$ no concat

            return result;
        }

        return result.WithValue(order);
    }




    public Result<OrderView> AddEditOrder(OrderView orderView)
    {
        var result = new Result<OrderView>();
        // === PHASE 1: General Order Rules ===
        if (orderView == null)
        {
            return result.AddError(new Error("Missing Information", "No order was supplied."));
        }
        if ((string.IsNullOrWhiteSpace(orderView.CustomerID)))
        {
            result.AddError(new Error("Missing Information", "Customer is required."));
        }
        if (orderView.EmployeeID < 1)
        {
            result.AddError(new Error("Missing Information", "Employee is required."));
        }
        if (result.IsFailure)
        {
            return result; //exit collecting both errors 
        }

        if (orderView.OrderDetails.Count == 0)
        {
            result.AddError(new Error("Missing Information", "Order details are required."));
            return result;
        }

        // === PHASE 2: Order Line Validation ===
        foreach (var orderDetail in orderView.OrderDetails)
        {
            //rule 5 ProductID check
            if (orderDetail.ProductID == 0)
            {
                return result.AddError(new Error("Missing Information", "Missing product ID."));
            }
            //rule 6 unit price must be no negative and return productName 
            string productName = _context.Products
                        .Where(p => p.ProductID == orderDetail.ProductID)
                        .Select(p => p.ProductName).FirstOrDefault();
            if (orderDetail.UnitPrice < 0)
            {
                result.AddError(new Error("Invalid Data", $"Product {productName} has a price that is less than zero."));
            }
            if (orderDetail.Quantity < 1)
            {
                result.AddError(new Error("Invalid Data", $"Product {productName} has a quantity that is less than one."));
            }
            
        }

        //Rule 8 no duplicate products across order lines 
        
               var duplicateOrders = orderView.OrderDetails
                        .GroupBy(od => od.ProductID)
                        .Where(g => g.Count() > 1);
                        
        foreach (var duplicateOrder in duplicateOrders)
        {
            var productName = _context.Products 
                .Where(p => p.ProductID == duplicateOrder.Key)
                .Select(p => p.ProductName)
                .FirstOrDefault();
                
            result.AddError(new Error("Invalid Data", $"Product {productName} can only be added to the order lines once."));
        }     
                   
                    

        // === PHASE 3: Order Processing ===

        // === PHASE 4: Final Validation and Save ===

        return result; // ← temporary, keeps compiler happy
    }
}
    #endregion

    #region View Models (EDIT THIS PORTION OF THE FILE)
    //EmployeeView 
    public class EmployeeView
    {
     public int EmployeeID { get; set; }  
     public string Title { get; set; }
     public string FullName { get; set; }
     public string Phone { get; set; }
     public string Country { get; set; }
     public string ReportTo { get; set; }
     public bool RemoveFromViewFlag { get; set; }
        public List<TerritoryView> SalesTerritories { get; set; } 
        = new List<TerritoryView>();
    }
//TerritoryView 
    public class TerritoryView 
    {
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public string RegionDescription { get; set; }
        public bool RemoveFromViewFlag { get; set; }
    }

//ProductView 
    public class ProductView
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? SupplierID { get; set; }
        public int CategoryID { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public bool RemoveFromViewFlag { get; set; } 
    }

//OrderView

public class OrderView
{ 
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public int EmployeeID { get; set; }
    public string EmployeeName { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? RequiredDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public int ShipVia { get; set; }
    public decimal? Freight { get; set; }
    public string ShipName { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipRegion { get; set; }
    public string ShipPostalCode { get; set; }
    public string ShipCountry { get; set; }
    public List<OrderDetailView> OrderDetails { get; set; } = new List<OrderDetailView>(); 
    public decimal? SubTotal { get; set; }
    public decimal? Tax { get; set; }
    public bool RemoveFromViewFlag { get; set; }  
}

public class OrderDetailView
{ 
    public int OrderDetailID { get; set; }
    public int OrderID { get; set; }
    public int ProductID { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; } // i get rid of the ?
    public short Quantity { get; set; } // i changes this too 
    public Single Discount { get; set; }
    public int UnitsInStock { get; set; }
    public bool RemoveFromViewFlag { get; set; }
    
    
}







#endregion

#region Support Methods (DO NOT EDIT)
// Converts a list of error objects into their string representations.
public static List<string> GetErrorMessages(List<Error> errorMessage)
{
	// Initialize a new list to hold the extracted error messages
	List<string> errorList = new();

	// Iterate over each Error object in the incoming list
	foreach (var error in errorMessage)
	{
		// Convert the current Error to its string form and add it to errorList
		errorList.Add(error.ToString());
	}

	// Return the populated list of error message strings
	return errorList;
}
public void ResetInventory()
{
	var inventories = Products.OrderBy(x => x.ProductID)
					.Take(100)
					.Select(x => x).ToList();
	foreach (Products inv in Products)
	{
		inv.UnitsInStock = 1000;
		Products.Update(inv);
	}
	SaveChanges();
}
#endregion