* **GetEmployee Tests**

  * Code: "Missing Information" | Message: "A last name or phone number is required."
  * Code: "No Employees"        | Message: "No employees were found."

* **Get Product Tests**

  * Code: "Missing Information" | Message: "Please provide a product id."
  * Code: "No Product"          | Message: "No product was found with ID: 3."

* **Get Order Tests**

  * Code: "Missing Information" | Message: "Please provide a invoice id."
  * Code: "No Order"            | Message: "No order was found with ID: 10249."

* **Add/Edit Order Tests**

  * Code: "Missing Information" | Message: "No order was supplied."
  * Code: "Missing Information" | Message: "Customer is required."
  * Code: "Missing Information" | Message: "Employee is required."
  * Code: "Missing Information" | Message: "Order details are required."
  * Code: "Missing Information" | Message: "Missing product ID."
  * Code: "Invalid Data"        | Message: "Product **Chai** can only be added to the order lines once."
  * Code: "Invalid Data"        | Message: "Product **Chai** has a price that is less than zero."
  * Code: "Invalid Data"        | Message: "Product **Chai** has a quantity that is less than one."

**NOTE:** "**Chai**" is the product currently being edited. Make sure you do not hard-code this value in your error results; otherwise, you will receive a zero for the three error checks.
