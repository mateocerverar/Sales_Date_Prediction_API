SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE StoreSample_Queries
	@Option INT = NULL,
	@CustomerId INT = NULL
AS
BEGIN
	-- SALES DATE PREDICTION
	IF @Option = 1 
	BEGIN
		WITH previousdates AS (
			SELECT 
			o.custid,
			o.orderdate,
			ISNULL(LAG(o.orderdate) OVER (PARTITION BY o.custid ORDER BY o.orderdate),orderdate) AS previousdate
			FROM Sales.Orders o
		),
		averagedays AS (
			SELECT custid, 
			MAX(orderdate) as lastorderdate,
			AVG(DATEDIFF(DAY, previousdate, orderdate)) AS avgdays
			FROM previousdates
			GROUP BY custid
		)

		 SELECT 
		 c.custid,
		 c.companyname AS customername,
		 ad.lastorderdate,
		 DATEADD(DAY, ad.avgdays, ad.lastorderdate) AS nextpredictedorder
		 FROM averagedays ad
		 INNER JOIN Sales.Customers c ON ad.custid = c.custid
		 ORDER BY C.companyname;
	END
	-- ----------------------
	-- GET CLIENT ORDERS 
	ELSE IF @Option = 2
	BEGIN
		SELECT 
		o.orderid, o.requireddate, o.shippeddate, o.shipname, o.shipaddress, o.shipcity
		FROM Sales.Orders o
		WHERE o.custid = @CustomerId
	END
	-- ----------------------
	-- GET EMPLOYEES 
	ELSE IF @Option = 3
	BEGIN 
		SELECT 
		e.empid, CONCAT_WS(' ', e.firstname, e.lastname) AS fullname
		FROM HR.Employees e
	END
	-- ----------------------
	-- GET SHIPPERS
	ELSE IF @Option = 4
	BEGIN
		SELECT 
		s.shipperid, s.companyname
		FROM Sales.Shippers s
	END
	-- ----------------------
	-- ----------------------
	-- GET PRODUCTS
	ELSE IF @Option = 5
	BEGIN
		SELECT 
		p.productid, p.productname
		FROM Production.Products p
	END
	-- ----------------------
END
GO
