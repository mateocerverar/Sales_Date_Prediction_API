SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE StoreSample_Commands
	@Option INT = NULL,

	-- CREATE ORDER
	@CustId INT = NULL,
	@EmpId INT = NULL,
	@OrderDate DATETIME = NULL,
	@RequiredDate DATETIME = NULL,
	@ShippedDate DATETIME = NULL,
	@ShipperId INT = NULL,
	@Freight MONEY = NULL,
	@ShipName NVARCHAR(40) = NULL,
	@ShipAddress NVARCHAR(60) = NULL,
	@ShipCity NVARCHAR(15) = NULL,
	@ShipCountry NVARCHAR(15) = NULL,

	-- CREATE ORDER DETAIL
	@ProductId INT = NULL,
	@UnitPrice MONEY = NULL,
	@Quantity SMALLINT = NULL,
	@Discount NUMERIC(4,3) = NULL
AS
BEGIN
	IF @Option = 1
	BEGIN
        BEGIN TRY
            BEGIN TRANSACTION;
            INSERT INTO Sales.Orders 
			(custid, empid, orderdate, requireddate, shippeddate, shipperid, freight, shipname, shipaddress, shipcity, shipcountry)
			VALUES
			(@CustId, @EmpId, @OrderDate, @RequiredDate, @ShippedDate, @ShipperId, @Freight, @ShipName, @ShipAddress, @ShipCity, @ShipCountry)

			DECLARE @OrderId INT = SCOPE_IDENTITY() 

			INSERT INTO Sales.OrderDetails 
			(orderid,productid, unitprice, qty, discount)
			VALUES 
			(@OrderId, @ProductId, @UnitPrice, @Quantity, @Discount)
            IF @@TRANCOUNT > 0
                COMMIT;
			SELECT @OrderId
        END TRY
        BEGIN CATCH
            IF @@TRANCOUNT > 0
                ROLLBACK;
            --SELECT ERROR_NUMBER() AS ErrorNumber;
            --SELECT ERROR_MESSAGE() AS ErrorMessage;
			SELECT NULL
        END CATCH;
    END;
END
GO
